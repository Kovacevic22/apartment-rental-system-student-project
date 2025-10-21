using BrokerBazePodataka;
using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Operacije
{
    public class VratiSvaMestaOp : OperacijaBaze
    {
        private BrokerBP broker;
        public VratiSvaMestaOp(BrokerBP broker)
        {
            this.broker = broker;
        }
        protected override object DeserijalizujPodatke(object podaci)
        {
            return null;
        }
        protected override object IzvrsiOperaciju(object podaci)
        {
            List<Mesto> mesta = broker.VratiSvaMesta();
            return mesta;
        }
        protected override string PorukaUspesno()
        {
            return "Sistem je ucitao sva mesta";
        }
    }
}
