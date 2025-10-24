using BrokerBazePodataka;
using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Operacije
{
    public class VratiSveUgovoreOp : OperacijaBaze
    {
        private BrokerBP broker = new BrokerBP();

        protected override object DeserijalizujPodatke(object podaci)
        {
            return null;
        }

        protected override object IzvrsiOperaciju(object podaci)
        {
            string upit = "SELECT u.*, z.Ime + ' ' + z.Prezime AS 'Zakupac', s.Ime + ' ' + s.Prezime as 'Stanodavac', " +
                "(SELECT COALESCE(SUM(Iznos),0) FROM StavkaUgovora su WHERE su.idUgovor = u.idUgovor) AS UkupanIznos " +
                "FROM Ugovor u JOIN Zakupac z ON u.idZakupac=z.idZakupac JOIN Stanodavac s ON u.idStanodavac = s.idStanodavac";
            List<IEntity> rezultat = broker.ExecuteQuery(new Ugovor(), upit);
            return rezultat.Cast<Ugovor>().ToList();
        }

        protected override string PorukaUspesno()
        {
            return "Sistem je ucitao ugovore.";
        }
    }
}
