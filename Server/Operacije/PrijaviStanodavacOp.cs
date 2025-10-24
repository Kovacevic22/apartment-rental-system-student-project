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
        private BrokerBP broker = new BrokerBP();
        private Server server;
        private Socket klijentskiSocket;

        public PrijaviStanodavacOp(Server server, Socket klijentskiSocket)
        {
            this.server = server;
            this.klijentskiSocket = klijentskiSocket;
        }

        protected override object DeserijalizujPodatke(object podaci)
        {
            return JsonSerializer.Deserialize<Stanodavac>((JsonElement)podaci);
        }

        protected override object IzvrsiOperaciju(object podaci)
        {
            Stanodavac stanodavac = (Stanodavac)podaci;

            string upit = "SELECT * FROM Stanodavac WHERE Email=@email AND Password=@password";
            var parametri = new Dictionary<string, object>
            {
                { "@email", stanodavac.Email },
                { "@password", stanodavac.Password }
            };
            List<IEntity> rezultat = broker.ExecuteQuery(new Stanodavac(), upit, parametri);

            if (rezultat.Count == 0)
                throw new Exception("Korisnicko ime ili sifra nisu ispravni.");
            Stanodavac ulogovan = (Stanodavac)rezultat[0];
            if (server.DaliJeKorisnikPrijavljen(ulogovan.IdStanodavac))
                throw new Exception("Korisnik je vec ulogovan");
            server.DodajPrijavljenogKorisnika(ulogovan.IdStanodavac, klijentskiSocket);
            return ulogovan;
        }

        protected override string PorukaUspesno()
        {
            return "Sistem je prijavio stanodavca.";
        }
    }
}
