using BrokerBazePodataka;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Zajednicki;

namespace Server.Operacije
{
    public class UbaciTerminIznajmljivanjaOp : OperacijaBaze
    {
        private BrokerBP broker;
        public UbaciTerminIznajmljivanjaOp(BrokerBP broker)
        {
            this.broker = broker;
        }
        protected override object DeserijalizujPodatke(object podaci)
        {
            return JsonSerializer.Deserialize<UbaciTerminIzinajmljivanjaPodaci>((JsonElement)podaci);
        }
        protected override object IzvrsiOperaciju(object podaci)
        {
            UbaciTerminIzinajmljivanjaPodaci parametri = (UbaciTerminIzinajmljivanjaPodaci)podaci;
            broker.UbaciTerminIznajmljivnja(parametri.terminIznajmljivanja, parametri.idStanodavac, parametri.opisStatusa);
            return null;
        }
        protected override string PorukaUspesno()
        {
            return "Sistem je zapamtio termin iznajmljivanja.";
        }
    }
}
