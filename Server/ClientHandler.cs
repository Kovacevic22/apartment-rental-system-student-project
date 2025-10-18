
using BrokerBazePodataka;
using Domen;
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
                    serverFrm?.DodajLog($"Zahtev: {zahtev.Operacija}");
                    Odgovor odgovor;
                    switch (zahtev.Operacija)
                    {
                        case Operacija.PrijaviStanodavac:
                            try
                            {
                                Stanodavac trazen = JsonSerializer.Deserialize<Stanodavac>((JsonElement)zahtev.Podaci);
                                Stanodavac pronadjen = broker.Login(trazen.Email, trazen.Password);
                                if (pronadjen != null)
                                {
                                    if (server.DaliJeKorisnikPrijavljen(pronadjen.IdStanodavac))
                                    {
                                        odgovor = new Odgovor()
                                        {
                                            Signal = false,
                                            Poruka = "Korisnik je vec ulogovan.",
                                            Podaci = null
                                        };
                                    }
                                    else
                                    {
                                        server.DodajPrijavljenogKorisnika(pronadjen.IdStanodavac, klijentskiSocket);
                                        odgovor = new Odgovor()
                                        {
                                            Signal = true,
                                            Poruka = "Korisnicko ime i sifra su ispravni.",
                                            Podaci = pronadjen
                                        };
                                    }
                                }
                                else
                                {
                                    // Login nije uspeo
                                    odgovor = new Odgovor()
                                    {
                                        Signal = false,
                                        Poruka = "Korisnicko ime i sifra nisu ispravni.",
                                        Podaci = null
                                    };
                                }
                                serializer.Send(odgovor);
                                serverFrm?.DodajLog($"Signal {odgovor.Signal}: {odgovor.Poruka}");
                            }
                            catch (Exception ex)
                            {
                                odgovor = new Odgovor()
                                {
                                    Signal = false,
                                    Poruka = ex.Message,
                                    Podaci = null
                                };
                                serializer.Send(odgovor);
                                serverFrm?.DodajLog($"Signal {odgovor.Signal}: {odgovor.Poruka}");
                            }
                            break;
                        case Operacija.KreirajZakupac:
                            try
                            {
                                Zakupac noviZakupac = JsonSerializer.Deserialize<Zakupac>((JsonElement)zahtev.Podaci);
                                broker.KreirajZakupac(noviZakupac);
                                odgovor = new Odgovor()
                                {
                                    Signal = true,
                                    Poruka = "Sistem je zapamtio zakupca.",
                                    Podaci = null
                                };
                                serializer.Send(odgovor);
                                serverFrm?.DodajLog($"Signal {odgovor.Signal}: {odgovor.Poruka}");
                                break;
                            }
                            catch (Exception ex)
                            {
                                odgovor = new Odgovor()
                                {
                                    Signal = false,
                                    Poruka = ex.Message,
                                    Podaci = null
                                };
                                serializer.Send(odgovor);
                                serverFrm?.DodajLog($"Signal {odgovor.Signal}: {odgovor.Poruka}");
                                break;
                            }
                        case Operacija.VratiSvaMesta:
                            try
                            {
                                List<Mesto> mesta = broker.VratiSvaMesta();
                                odgovor = new Odgovor()
                                {
                                    Signal = true,
                                    Poruka = "Sistem je ucitao sva mesta.",
                                    Podaci = mesta
                                };
                                serializer.Send(odgovor);
                                serverFrm?.DodajLog($"Signal {odgovor.Signal}: {odgovor.Poruka}");
                            }
                            catch (Exception ex)
                            {
                                odgovor = new Odgovor()
                                {
                                    Signal = false,
                                    Poruka = ex.Message,
                                    Podaci = null
                                };
                                serializer.Send(odgovor);
                                serverFrm?.DodajLog($"Signal {odgovor.Signal}: {odgovor.Poruka}");
                            }
                            break;
                        case Operacija.VratiSveZakupce:
                            try
                            {
                                List<Zakupac> zakupci = broker.VratiSveZakupce();
                                odgovor = new Odgovor()
                                {
                                    Signal = true,
                                    Poruka = "Sistem je ucitao sve zakupce.",
                                    Podaci = zakupci
                                };
                                serializer.Send(odgovor);
                                serverFrm?.DodajLog($"Signal {odgovor.Signal}: {odgovor.Poruka}");
                            }
                            catch (Exception ex)
                            {
                                odgovor = new Odgovor()
                                {
                                    Signal = false,
                                    Poruka = ex.Message,
                                    Podaci = null
                                };
                                serializer.Send(odgovor);
                                serverFrm?.DodajLog($"Signal {odgovor.Signal}: {odgovor.Poruka}");
                            }
                            break;
                        case Operacija.PretraziZakupac:
                            try
                            {
                                ZakupacSearchParametri kriterijumPretrage = JsonSerializer.Deserialize<ZakupacSearchParametri>((JsonElement)zahtev.Podaci);
                                List<Zakupac> zakupciPretraga = broker.PretraziZakupac(kriterijumPretrage.Email, kriterijumPretrage.Ime, kriterijumPretrage.Prezime, kriterijumPretrage.MestoId);
                                odgovor = new Odgovor()
                                {
                                    Signal = true,
                                    Poruka = zakupciPretraga.Count > 1 ? "Sistem je nasao zakupce po zadatim kriterijumima" : "Sistem je nasao zakupca",
                                    Podaci = zakupciPretraga,
                                };
                                serializer.Send(odgovor);
                                serverFrm?.DodajLog($"Signal {odgovor.Signal}: {odgovor.Poruka}");
                            }
                            catch (Exception ex)
                            {
                                odgovor = new Odgovor
                                {
                                    Signal = false,
                                    Poruka = ex.Message,
                                    Podaci = null
                                };
                                serializer.Send(odgovor);
                                serverFrm?.DodajLog($"Signal {odgovor.Signal}: {odgovor.Poruka}");
                            }
                            break;
                        case Operacija.PromeniZakupac:
                            try
                            {
                                Zakupac izmenjenZakupac = JsonSerializer.Deserialize<Zakupac>((JsonElement)zahtev.Podaci);
                                broker.PromeniZakupac(izmenjenZakupac);
                                odgovor = new Odgovor
                                {
                                    Signal = true,
                                    Poruka = "Sistem je zapamtio zakupca.",
                                    Podaci = null
                                };
                                serializer.Send(odgovor);
                                serverFrm?.DodajLog($"Signal {odgovor.Signal}: {odgovor.Poruka}");
                            }
                            catch (Exception ex)
                            {
                                odgovor = new Odgovor
                                {
                                    Signal = false,
                                    Poruka = ex.Message,
                                    Podaci = null
                                };
                                serializer.Send(odgovor);
                                serverFrm?.DodajLog($"Signal {odgovor.Signal}: {odgovor.Poruka}");
                            }
                            break;
                        case Operacija.ObrisiZakupac:
                            try
                            {
                                int idZakupac = JsonSerializer.Deserialize<int>((JsonElement)zahtev.Podaci);
                                broker.ObrisiZakupac(idZakupac);
                                odgovor = new Odgovor
                                {
                                    Signal = true,
                                    Poruka = "Sistem je obrisao zakupca.",
                                    Podaci = null
                                };
                                serializer.Send(odgovor);
                                serverFrm?.DodajLog($"Signal {odgovor.Signal}: {odgovor.Poruka}");
                            }
                            catch (Exception ex)
                            {
                                odgovor = new Odgovor
                                {
                                    Signal = false,
                                    Poruka = ex.Message,
                                    Podaci = null
                                };
                                serializer.Send(odgovor);
                                serverFrm?.DodajLog($"Signal {odgovor.Signal}: {odgovor.Poruka}");
                            }
                            break;
                        case Operacija.VratiSveStanove:
                            try
                            {
                                List<Stan> stanovi = broker.VratiListuStanova();
                                odgovor = new Odgovor
                                {
                                    Signal = true,
                                    Poruka = "Sistem je ucitao sve stanove.",
                                    Podaci = stanovi
                                };
                                serializer.Send(odgovor);
                                serverFrm?.DodajLog($"Signal {odgovor.Signal}: {odgovor.Poruka}");
                            }
                            catch (Exception ex)
                            {
                                odgovor = new Odgovor
                                {
                                    Signal = false,
                                    Poruka = ex.Message,
                                    Podaci = null
                                };
                                serializer.Send(odgovor);
                                serverFrm?.DodajLog($"Signal {odgovor.Signal}: {odgovor.Poruka}");
                            }
                            break;
                        case Operacija.KreirajUgovor:
                            try
                            {
                                Ugovor noviUgovor = JsonSerializer.Deserialize<Ugovor>((JsonElement)zahtev.Podaci);
                                broker.KreirajUgovor(noviUgovor);
                                odgovor = new Odgovor
                                {
                                    Signal = true,
                                    Poruka = "Sistem je zapamtio ugovor.",
                                    Podaci = null
                                };
                                serializer.Send(odgovor);
                                serverFrm?.DodajLog($"Signal {odgovor.Signal}: {odgovor.Poruka}");
                            }
                            catch (Exception ex)
                            {
                                odgovor = new Odgovor
                                {
                                    Signal = false,
                                    Poruka = ex.Message,
                                    Podaci = null
                                };
                                serializer.Send(odgovor);
                                serverFrm?.DodajLog($"Signal {odgovor.Signal}: {odgovor.Poruka}");
                            }
                            break;
                        case Operacija.PretraziUgovor:
                            try
                            {
                                UgovorSearchParametri parametri = JsonSerializer.Deserialize<UgovorSearchParametri>((JsonElement)zahtev.Podaci);
                                List<Ugovor> ugovorPretraga = broker.PretraziUgovor(parametri.datumOd, parametri.datumDo, parametri.idZakupac, parametri.idStanodavac);
                                odgovor = new Odgovor
                                {
                                    Signal = true,
                                    Podaci = ugovorPretraga,
                                    Poruka = "Sistem je nasao ugovore po zadatim kriterijumima"
                                };
                                serializer.Send(odgovor);
                                serverFrm?.DodajLog($"Signal {odgovor.Signal}: {odgovor.Poruka}");
                            }
                            catch (Exception ex)
                            {
                                odgovor = new Odgovor
                                {
                                    Signal = false,
                                    Poruka = ex.Message,
                                    Podaci = null
                                };
                                serializer.Send(odgovor);
                                serverFrm?.DodajLog($"Signal {odgovor.Signal}: {odgovor.Poruka}");
                            }
                            break;
                        case Operacija.VratiSveUgovore:
                            try
                            {
                                List<Ugovor> ugovori = broker.VratiSveUgovore();
                                odgovor = new Odgovor
                                {
                                    Signal = true,
                                    Poruka = "Sistem je ucitao sve ugovore",
                                    Podaci = ugovori
                                };
                                serializer.Send(odgovor);
                                serverFrm?.DodajLog($"Signal {odgovor.Signal}: {odgovor.Poruka}");
                            }
                            catch (Exception ex)
                            {
                                odgovor = new Odgovor
                                {
                                    Signal = false,
                                    Poruka = ex.Message,
                                    Podaci = null
                                };
                                serializer.Send(odgovor);
                                serverFrm?.DodajLog($"Signal {odgovor.Signal}: {odgovor.Poruka}");
                            }
                            break;
                        case Operacija.VratiUgovorSaStavkama:
                            try
                            {
                                int idUgovor = JsonSerializer.Deserialize<int>((JsonElement)zahtev.Podaci);
                                Ugovor ugovor = broker.VratiUgovorSaStavkama(idUgovor);
                                odgovor = new Odgovor
                                {
                                    Signal = true,
                                    Podaci = ugovor,
                                    Poruka = "Sistem je vratio ugovore sa stavkama"
                                };
                                serializer.Send(odgovor);
                                serverFrm?.DodajLog($"Signal {odgovor.Signal}: {odgovor.Poruka}");
                            }
                            catch (Exception ex)
                            {
                                odgovor = new Odgovor
                                {
                                    Signal = false,
                                    Poruka = ex.Message,
                                    Podaci = null
                                };
                                serializer.Send(odgovor);
                                serverFrm?.DodajLog($"Signal {odgovor.Signal}: {odgovor.Poruka}");
                            }
                            break;
                        case Operacija.PromeniUgovor:
                            try
                            {
                                Ugovor izmenjenUgovor = JsonSerializer.Deserialize<Ugovor>((JsonElement)zahtev.Podaci);
                                broker.PromeniUgovor(izmenjenUgovor);
                                odgovor = new Odgovor
                                {
                                    Signal = true,
                                    Poruka = "Sistem je zapamtio ugovor",
                                    Podaci = zahtev.Podaci
                                };
                                serializer.Send(odgovor);
                                serverFrm?.DodajLog($"Signal {odgovor.Signal}: {odgovor.Poruka}");
                            }
                            catch (Exception ex)
                            {
                                odgovor = new Odgovor
                                {
                                    Signal = false,
                                    Poruka = ex.Message,
                                    Podaci = null
                                };
                                serializer.Send(odgovor);
                                serverFrm?.DodajLog($"Signal {odgovor.Signal}: {odgovor.Poruka}");
                            }
                            break;
                        case Operacija.UbaciTerminIznajmljivanja:
                            try
                            {
                                UbaciTerminIzinajmljivanjaPodaci podaci = JsonSerializer.Deserialize<UbaciTerminIzinajmljivanjaPodaci>((JsonElement)zahtev.Podaci);
                                broker.UbaciTerminIznajmljivnja(podaci.terminIznajmljivanja, podaci.idStanodavac, podaci.opisStatusa);
                                odgovor = new Odgovor
                                {
                                    Signal = true,
                                    Poruka = "Sistem je zapamtio termin iznajmljivanja.",
                                    Podaci = null
                                };
                                serializer.Send(odgovor);
                                serverFrm?.DodajLog($"Signal {odgovor.Signal}: {odgovor.Poruka}");
                            }
                            catch (Exception ex)
                            {
                                odgovor = new Odgovor
                                {
                                    Signal = false,
                                    Poruka = ex.Message,
                                    Podaci = null
                                };
                                serializer.Send(odgovor);
                                serverFrm?.DodajLog($"Signal {odgovor.Signal}: {odgovor.Poruka}");
                            }
                            break;
                        default:
                            odgovor = new Odgovor()
                            {
                                Signal = false,
                                Poruka = "Nepoznata operacija!",
                                Podaci = null
                            };
                            serializer.Send(odgovor);
                            serverFrm?.DodajLog($"{odgovor.Poruka}");
                            break;
                    }
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
    }
}