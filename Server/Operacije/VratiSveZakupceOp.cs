using BrokerBazePodataka;
using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Operacije
{
    public class VratiSveZakupceOp : OperacijaBaze
    {
        private BrokerBP broker;
        public VratiSveZakupceOp(BrokerBP broker)
        {
            this.broker = broker;
        }
        protected override object DeserijalizujPodatke(object podaci)
        {
            return null;
        }
        protected override object IzvrsiOperaciju(object podaci)
        {
            List<Zakupac> zakupci = broker.VratiSveZakupce();
            return zakupci;
        }
        protected override string PorukaUspesno()
        {
            return "Sistem je ucitao sve zakupce";
        }
    }
}
