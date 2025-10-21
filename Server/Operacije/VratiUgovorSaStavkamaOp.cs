using BrokerBazePodataka;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Server.Operacije
{
    public class VratiUgovorSaStavkamaOp : OperacijaBaze
    {
        private BrokerBP broker;
        public VratiUgovorSaStavkamaOp(BrokerBP broker)
        {
            this.broker = broker;
        }
        protected override object DeserijalizujPodatke(object podaci)
        {
            return JsonSerializer.Deserialize<int>((JsonElement)podaci);
        }
        protected override object IzvrsiOperaciju(object podaci)
        {
            int idUgovor = (int)podaci;
            var ugovorSaStavkama = broker.VratiUgovorSaStavkama(idUgovor);
            return ugovorSaStavkama;
        }
        protected override string PorukaUspesno()
        {
            return "Sistem je vratio ugovore sa stavkama.";
        }
    }
}
