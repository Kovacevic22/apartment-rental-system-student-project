using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zajednicki;

namespace Server
{
    public abstract class OperacijaBaze
    {
        public Odgovor Izvrsi(Zahtev zahtev, ServerFrm serverFrm)
        {
            Odgovor odgovor;
            try
            {
                object podaci = DeserijalizujPodatke(zahtev.Podaci);
                object rezultat = IzvrsiOperaciju(podaci);
                odgovor = new Odgovor
                {
                    Signal = true,
                    Poruka = PorukaUspesno(),
                    Podaci = rezultat
                };
                serverFrm?.DodajLog($"Signal {odgovor.Signal}: {odgovor.Poruka}");
            }
            catch (Exception ex)
            {
                odgovor = new Odgovor
                {
                    Signal = false,
                    Poruka = ex.Message,
                    Podaci = null
                };
                serverFrm?.DodajLog($"Signal {odgovor.Signal}: {odgovor.Poruka}");
            }
            return odgovor;
        }
        protected abstract object IzvrsiOperaciju(object podaci);
        protected abstract string PorukaUspesno();
        protected abstract object DeserijalizujPodatke(object podaci);
    }
}
