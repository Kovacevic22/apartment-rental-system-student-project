using BrokerBazePodataka;
using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Server.Operacije
{
    public class PrijaviStanodavacOp : OperacijaBaze
    {
        private BrokerBP broker;
        private Server server;
        private Socket socket;
        public PrijaviStanodavacOp(BrokerBP broker, Server server, Socket socket)
        {
            this.broker = broker;
            this.server = server;
            this.socket = socket;
        }
        protected override object DeserijalizujPodatke(object podaci)
        {
            return JsonSerializer.Deserialize<Stanodavac>((JsonElement)podaci);
        }
        protected override object IzvrsiOperaciju(object podaci)
        {
            Stanodavac trazen = (Stanodavac)podaci;
            Stanodavac pronadjen = broker.Login(trazen);
            if(pronadjen == null)
            {
                throw new Exception("Korisnicko ime ili sifra nisu ispravni.");
            }
            if(server.DaliJeKorisnikPrijavljen(pronadjen.IdStanodavac))
            {
                throw new Exception("Korisnik je vec ulogovan.");
            }
            server.DodajPrijavljenogKorisnika(pronadjen.IdStanodavac, socket);
            return pronadjen;
        }
        protected override string PorukaUspesno()
        {
            return "Korisnicko ime i sifra su ispravni.";
        }
    }
}
