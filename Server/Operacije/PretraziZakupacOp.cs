using BrokerBazePodataka;
using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Zajednicki;

namespace Server.Operacije
{
    public class PretraziZakupacOp : OperacijaBaze
    {
        private BrokerBP broker;
        private List<Zakupac> rezultat;
        public PretraziZakupacOp(BrokerBP broker)
        {
            this.broker = broker;
        }
        protected override object DeserijalizujPodatke(object podaci)
        {
            return  JsonSerializer.Deserialize<ZakupacSearchParametri>((JsonElement)podaci);
        }
        protected override object IzvrsiOperaciju(object podaci)
        {
            ZakupacSearchParametri kriterijumPretrage = (ZakupacSearchParametri)podaci;
            rezultat = broker.PretraziZakupac(kriterijumPretrage.Email, kriterijumPretrage.Ime, kriterijumPretrage.Prezime, kriterijumPretrage.MestoId);
            return rezultat;
        }
        protected override string PorukaUspesno()
        {
            return rezultat.Count>1 ? "Sistem je nasao zakupce po zadatom kriterijumu." : "Sistem je nasao zakupca.";
        }
    }
}
