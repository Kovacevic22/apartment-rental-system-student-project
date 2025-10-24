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
        private BrokerBP broker = new BrokerBP();

        protected override object DeserijalizujPodatke(object podaci)
        {
            return null;
        }

        protected override object IzvrsiOperaciju(object podaci)
        {
            List<IEntity> entities = broker.GetAll(new Mesto());
            return entities.Cast<Mesto>().ToList();
        }

        protected override string PorukaUspesno()
        {
            return "Sistem je ucitao mesta.";
        }
    }
}
