
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
            try
            {
                while (true)
                {
                    Zahtev zahtev = serializer.Recieve<Zahtev>();
                    if (zahtev == null) break;
                    serverFrm?.DodajLog($"Stigao zahtev: {zahtev.Operacija}");
                    Odgovor odgovor;
                    OperacijaBaze operacija = KreirajOperaciju(zahtev.Operacija);
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

        private OperacijaBaze KreirajOperaciju(Operacija op)
        {
            switch (op)
            {
                case Operacija.PrijaviStanodavac:
                    return new PrijaviStanodavacOp(server, klijentskiSocket);
                case Operacija.KreirajZakupac:
                    return new KreirajZakupacOp();

                case Operacija.VratiSvaMesta:
                    return new VratiSvaMestaOp();

                case Operacija.VratiSveZakupce:
                    return new VratiSveZakupceOp();

                case Operacija.PretraziZakupac:
                    return new PretraziZakupacOp();

                case Operacija.PromeniZakupac:
                    return new PromeniZakupacOp();

                case Operacija.ObrisiZakupac:
                    return new ObrisiZakupacOp();

                case Operacija.VratiSveStanove:
                    return new VratiSveStanoveOp();

                case Operacija.KreirajUgovor:
                    return new KreirajUgovorOp();

                case Operacija.PretraziUgovor:
                    return new PretraziUgovorOpcs();

                case Operacija.VratiSveUgovore:
                    return new VratiSveUgovoreOp();

                case Operacija.VratiUgovorSaStavkama:
                    return new VratiUgovorSaStavkamaOp();

                case Operacija.PromeniUgovor:
                    return new PromeniUgovorOp();

                case Operacija.UbaciTerminIznajmljivanja:
                    return new UbaciTerminIznajmljivanjaOp();

                default:
                    return null;
            }
        }

    }
}