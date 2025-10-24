using BrokerBazePodataka;
using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Operacije
{
    public class VratiSveStanoveOp : OperacijaBaze
    {
        private BrokerBP broker = new BrokerBP();

        protected override object DeserijalizujPodatke(object podaci)
        {
            return null;
        }

        protected override object IzvrsiOperaciju(object podaci)
        {
            List<IEntity> entities = broker.GetAll(new Stan());
            return entities.Cast<Stan>().ToList();
        }

        protected override string PorukaUspesno()
        {
            return "Sistem je ucitao stanove.";
        }
    }
}
