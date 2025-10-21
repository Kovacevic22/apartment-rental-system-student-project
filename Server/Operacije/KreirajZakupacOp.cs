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
    public class KreirajZakupacOp : OperacijaBaze
    {
        private BrokerBP broker;
        public KreirajZakupacOp(BrokerBP broker)
        {
            this.broker = broker;
        }
        protected override object DeserijalizujPodatke(object podaci)
        {
           return JsonSerializer.Deserialize<Zakupac>((JsonElement)podaci);
        }
        protected override object IzvrsiOperaciju(object podaci)
        {
            Zakupac novi = (Zakupac)podaci;
            broker.KreirajZakupac(novi);
            return null;
        }
        protected override string PorukaUspesno()
        {
            return "Sistem je zapamtio zakupca";
        }
    }
}
