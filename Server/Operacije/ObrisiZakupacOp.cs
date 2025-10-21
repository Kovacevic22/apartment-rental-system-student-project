using BrokerBazePodataka;
using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Server.Operacije
{
    public class ObrisiZakupacOp : OperacijaBaze
    {
        private BrokerBP broker;
        public ObrisiZakupacOp(BrokerBP broker)
        {
            this.broker = broker;
        }
        protected override object DeserijalizujPodatke(object podaci)
        {
            return JsonSerializer.Deserialize<int>((JsonElement)podaci);
        }
        protected override object IzvrsiOperaciju(object podaci)
        {
            int idZakupac = (int)podaci;
            broker.ObrisiZakupac(idZakupac);
            return null;
        }
        protected override string PorukaUspesno()
        {
            return "Sistem je obrisao zakupca.";
        }
    }
}
