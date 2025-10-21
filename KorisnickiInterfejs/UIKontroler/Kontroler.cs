using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Zajednicki;

namespace KorisnickiInterfejs.UIKontroler
{
    internal class Kontroler
    {
        private static Kontroler instance;
        private Socket socket;
        private static readonly object lockObj = new object();
        private Kontroler()
        {

        }
        public static Kontroler Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Kontroler();
                }
                return instance;
            }
        }
        private JsonNetworkSerializer serializer;
        public void Connect()
        {
            try
            {
                if (socket != null && socket.Connected)
                {
                    return;
                }
                if (socket != null)
                {
                    socket.Close();
                    socket = null;
                }
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                socket.Connect("127.0.0.1", 9999);
                serializer = new JsonNetworkSerializer(socket);
            }
            catch (Exception ex)
            {
                throw new Exception("Greska prilikom povezivanja na server! (" + ex.Message + ")");
            }
        }
        //SK-ovi
        public Stanodavac Login(Stanodavac stanodavac)
        {
            Zahtev zahtev = new Zahtev
            {
                Operacija = Operacija.PrijaviStanodavac,
                Podaci = stanodavac
            };
            serializer.Send(zahtev);
            Odgovor odgovor = serializer.Recieve<Odgovor>();
            if (odgovor.Signal == true)
            {
                return JsonSerializer.Deserialize<Stanodavac>((JsonElement)odgovor.Podaci);
            }
            else
            {
               throw new Exception(odgovor.Poruka);
            }
        }

        public void KreirajZakupac(Zakupac zakupac)
        {
            Zahtev zahtev = new Zahtev
            {
                Operacija = Operacija.KreirajZakupac,
                Podaci = zakupac
            };
            serializer.Send(zahtev);
            Odgovor odgovor = serializer.Recieve<Odgovor>();
            if (odgovor.Signal == false)
            {
                throw new Exception(odgovor.Poruka);
            }
        }
        public List<Zakupac> PretraziZakupac(string email, string ime, string prezime, int? mestoId)
        {
            ZakupacSearchParametri parametriObj = new ZakupacSearchParametri()
            {
                Email = email,
                Ime = ime,
                Prezime = prezime,
                MestoId = mestoId
            };
            Zahtev zahtev = new Zahtev
            {
                Operacija = Operacija.PretraziZakupac,
                Podaci = parametriObj
            };
            serializer.Send(zahtev);
            Odgovor odgovor = serializer.Recieve<Odgovor>();
            if (odgovor.Signal == true)
            {
                return JsonSerializer.Deserialize<List<Zakupac>>((JsonElement)odgovor.Podaci);
            }
            else
            {
                throw new Exception(odgovor.Poruka);
            }
        }
        public void PromeniZakupac(Zakupac zakupac)
        {
            Zahtev zahtev = new Zahtev
            {
                Operacija = Operacija.PromeniZakupac,
                Podaci = zakupac
            };
            serializer.Send(zahtev);
            Odgovor odgovor = serializer.Recieve<Odgovor>();
            if (odgovor.Signal == false)
            {
                throw new Exception(odgovor.Poruka);
            }
        }
        public void ObrisiZakupac(int zakupacId)
        {
            Zahtev zahtev = new Zahtev
            {
                Operacija = Operacija.ObrisiZakupac,
                Podaci = zakupacId
            };
            serializer.Send(zahtev);
            Odgovor odgovor = serializer.Recieve<Odgovor>();
            if (odgovor.Signal == false)
            {
                throw new Exception(odgovor.Poruka);
            }
        }
        public void KreirajUgovor(Ugovor ugovor)
        {
            Zahtev zahtev = new Zahtev
            {
                Operacija = Operacija.KreirajUgovor,
                Podaci = ugovor
            };
            serializer.Send(zahtev);
            Odgovor odgovor = serializer.Recieve<Odgovor>();
            if (odgovor.Signal == false)
            {
                throw new Exception(odgovor.Poruka);
            }
        }
        public List<Ugovor> PretraziUgovor(DateTime? datumOd, DateTime? datumDo, int? idZakupac, int? idStanodavac)
        {
            UgovorSearchParametri parametri = new UgovorSearchParametri()
            {
                datumDo = datumDo,
                datumOd = datumOd,
                idStanodavac = idStanodavac,
                idZakupac = idZakupac
            };
            Zahtev zahtev = new Zahtev()
            {
                Operacija = Operacija.PretraziUgovor,
                Podaci = parametri
            };
            serializer.Send(zahtev);
            Odgovor odgovor = serializer.Recieve<Odgovor>();
            if (odgovor.Signal == true)
            {
                return JsonSerializer.Deserialize<List<Ugovor>>((JsonElement)odgovor.Podaci);
            }
            else
            {
                throw new Exception(odgovor.Poruka);
            }
        }

        public void PromeniUgovor(Ugovor ugovor)
        {
            Zahtev zahtev = new Zahtev
            {
                Operacija = Operacija.PromeniUgovor,
                Podaci = ugovor
            };
            serializer.Send(zahtev);
            Odgovor odgovor = serializer.Recieve<Odgovor>();
            if (odgovor.Signal == false)
            {
                throw new Exception(odgovor.Poruka);
            }
        }

        public void UbaciTerminIznajmljivanja(TerminIznajmljivanja termin, int idStanodavac, string opisStatusa)
        {
            UbaciTerminIzinajmljivanjaPodaci podaci = new UbaciTerminIzinajmljivanjaPodaci
            {
                idStanodavac = idStanodavac,
                opisStatusa = opisStatusa,
                terminIznajmljivanja = termin
            };
            Zahtev zahtev = new Zahtev
            {
                Operacija = Operacija.UbaciTerminIznajmljivanja,
                Podaci = podaci
            };
            serializer.Send(zahtev);
            Odgovor odgovor = serializer.Recieve<Odgovor>();
            if (odgovor.Signal == false)
            {
                throw new Exception(odgovor.Poruka);
            }
        }
        //POMOCNE METODE///
        public Ugovor VratiUgovorSaStavkama(int idUgovor)
        {
            Zahtev zahtev = new Zahtev
            {
                Operacija = Operacija.VratiUgovorSaStavkama,
                Podaci = idUgovor
            };
            serializer.Send(zahtev);
            Odgovor odgovor = serializer.Recieve<Odgovor>();
            if (odgovor.Signal == true)
            {
                return JsonSerializer.Deserialize<Ugovor>((JsonElement)odgovor.Podaci);
            }
            else
            {
                throw new Exception(odgovor.Poruka);
            }
        }
        public List<Ugovor> VratiSveUgovore()
        {
            Zahtev zahtev = new Zahtev
            {
                Operacija = Operacija.VratiSveUgovore,
                Podaci = null
            };
            serializer.Send(zahtev);
            Odgovor odgovor = serializer.Recieve<Odgovor>();
            if (odgovor.Signal == true)
            {
                return JsonSerializer.Deserialize<List<Ugovor>>((JsonElement)odgovor.Podaci);
            }
            else
            {
                throw new Exception(odgovor.Poruka);
            }
        }

        public List<Stan> VratiSveStanove()
        {
            Zahtev zahtev = new Zahtev
            {
                Operacija = Operacija.VratiSveStanove,
                Podaci = null
            };
            serializer.Send(zahtev);
            Odgovor odgovor = serializer.Recieve<Odgovor>();
            if (odgovor.Signal == true)
            {
                return JsonSerializer.Deserialize<List<Stan>>((JsonElement)odgovor.Podaci);
            }
            else
            {
                throw new Exception(odgovor.Poruka);
            }
        }
        public List<Zakupac> VratiSveZakupce()
        {
            Zahtev zahtev = new Zahtev
            {
                Operacija = Operacija.VratiSveZakupce,
                Podaci = null
            };
            serializer.Send(zahtev);
            Odgovor odgovor = serializer.Recieve<Odgovor>();
            if (odgovor.Signal == true)
            {
                return JsonSerializer.Deserialize<List<Zakupac>>((JsonElement)odgovor.Podaci);
            }
            else
            {
                throw new Exception(odgovor.Poruka);
            }
        }
        public List<Mesto> VratiSvaMesta()
        {
            Zahtev zahtev = new Zahtev
            {
                Operacija = Operacija.VratiSvaMesta,
                Podaci = null
            };
            serializer.Send(zahtev);
            Odgovor odgovor = serializer.Recieve<Odgovor>();
            if (odgovor.Signal == true)
            {
                return JsonSerializer.Deserialize<List<Mesto>>((JsonElement)odgovor.Podaci);
            }
            else
            {
                throw new Exception(odgovor.Poruka);
            }
        }
        public void Disconnect()
        {
            if (socket != null && socket.Connected)
            {
                try
                {
                    socket.Shutdown(SocketShutdown.Both);
                    socket.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("Greska prilikom prekida veze! (" + ex.Message + ")");
                }
                finally
                {
                    socket = null;
                    instance = null;
                }
            }
            else
            {
                throw new Exception("Niste povezani na server!");
            }
        }
    }
}
