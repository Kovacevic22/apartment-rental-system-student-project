
using BrokerBazePodataka;
using Domen;
using Server.Operacije;
using System.Net.Sockets;
using System.Text.Json;
using Zajednicki;

namespace Server
{
    public class ClientHandler
    {
        private Socket klijentskiSocket;
        private ServerFrm serverFrm;
        private Server server;
        public ClientHandler(Socket klijentskiSocket, ServerFrm serverFrm, Server server)
        {
            this.klijentskiSocket = klijentskiSocket;
            this.serverFrm = serverFrm;
            this.server = server;
        }
        public void Handle()
        {
            serverFrm?.DodajLog($"Klijent povezan: {klijentskiSocket.RemoteEndPoint}");
            JsonNetworkSerializer serializer = new JsonNetworkSerializer(klijentskiSocket);
            BrokerBP broker = new BrokerBP();
            try
            {
                while (true)
                {
                    Zahtev zahtev = serializer.Recieve<Zahtev>();
                    if (zahtev == null) break;
                    serverFrm?.DodajLog($"Stigao zahtev: {zahtev.Operacija}");
                    Odgovor odgovor;
                    OperacijaBaze operacija = KreirajOperaciju(zahtev.Operacija, broker);
                    if(operacija != null)
                    {
                        odgovor = operacija.Izvrsi(zahtev, serverFrm);
                    }else
                    {
                        odgovor = new Odgovor
                        {
                            Signal = false,
                            Poruka = "Nepoznata operacija",
                            Podaci = null
                        };
                        serverFrm?.DodajLog($"Signal {odgovor.Signal}: {odgovor.Poruka}");
                    }
                    serializer.Send(odgovor);
                }
            }
            catch (Exception ex)
            {
                //serverFrm?.DodajLog("Greska u komunikaciji sa klijentom: " + ex.Message);
            }
            finally
            {
                string endpoint = "nepoznat";
                try
                {
                    server?.UkloniPrijavljenogKorisnika(klijentskiSocket);
                    endpoint = klijentskiSocket?.RemoteEndPoint?.ToString() ?? "nepoznat";
                    klijentskiSocket?.Shutdown(SocketShutdown.Both);
                    klijentskiSocket?.Close();
                    server?.UkloniSocket(klijentskiSocket);
                    serverFrm?.DodajLog($"Klijent diskonektovan: {endpoint}");
                }
                catch { }
            }
        }

        private OperacijaBaze KreirajOperaciju(Operacija op, BrokerBP broker)
        {
            switch (op)
            {
                case Operacija.PrijaviStanodavac:
                    return new PrijaviStanodavacOp(broker, server, klijentskiSocket);
                case Operacija.KreirajZakupac:
                    return new KreirajZakupacOp(broker);

                case Operacija.VratiSvaMesta:
                    return new VratiSvaMestaOp(broker);

                case Operacija.VratiSveZakupce:
                    return new VratiSveZakupceOp(broker);

                case Operacija.PretraziZakupac:
                    return new PretraziZakupacOp(broker);

                case Operacija.PromeniZakupac:
                    return new PromeniZakupacOp(broker);

                case Operacija.ObrisiZakupac:
                    return new ObrisiZakupacOp(broker);

                case Operacija.VratiSveStanove:
                    return new VratiSveStanoveOp(broker);

                case Operacija.KreirajUgovor:
                    return new KreirajUgovorOp(broker);

                case Operacija.PretraziUgovor:
                    return new PretraziUgovorOpcs(broker);

                case Operacija.VratiSveUgovore:
                    return new VratiSveUgovoreOp(broker);

                case Operacija.VratiUgovorSaStavkama:
                    return new VratiUgovorSaStavkamaOp(broker);

                case Operacija.PromeniUgovor:
                    return new PromeniUgovorOp(broker);

                case Operacija.UbaciTerminIznajmljivanja:
                    return new UbaciTerminIznajmljivanjaOp(broker);

                default:
                    return null;
            }
        }

    }
}