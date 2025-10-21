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
    public class PretraziUgovorOpcs : OperacijaBaze
    {
        private BrokerBP broker;
        public PretraziUgovorOpcs(BrokerBP broker)
        {
            this.broker = broker;
        }
        protected override object DeserijalizujPodatke(object podaci)
        {
            return JsonSerializer.Deserialize<UgovorSearchParametri>((JsonElement)podaci);
        }
        protected override object IzvrsiOperaciju(object podaci)
        {
            UgovorSearchParametri parametri = (UgovorSearchParametri)podaci;
            List<Ugovor> pretraga = broker.PretraziUgovor(parametri.datumOd,parametri.datumDo,parametri.idZakupac,parametri.idStanodavac);
            return pretraga;
        }
        protected override string PorukaUspesno()
        {
            return "Sistem je nasao ugovore po zadatom kriterijumu.";
        }
    }
}
