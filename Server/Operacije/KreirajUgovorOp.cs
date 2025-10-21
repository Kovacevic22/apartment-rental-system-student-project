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
    public class KreirajUgovorOp : OperacijaBaze
    {
        private BrokerBP broker;
        public KreirajUgovorOp(BrokerBP broker)
        {
            this.broker = broker;
        }
        protected override object DeserijalizujPodatke(object podaci)
        {
            return JsonSerializer.Deserialize<Ugovor>((JsonElement)podaci);
        }
        protected override object IzvrsiOperaciju(object podaci)
        {
            Ugovor novi = (Ugovor)podaci;
            broker.KreirajUgovor(novi);
            return null;
        }
        protected override string PorukaUspesno()
        {
            return "Sistem je zapamtio ugovor.";
        }
    }
}
