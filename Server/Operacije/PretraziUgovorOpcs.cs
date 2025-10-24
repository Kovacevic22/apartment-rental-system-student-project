using BrokerBazePodataka;
using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Zajednicki;

namespace Server.Operacije
{
    public class PretraziUgovorOpcs : OperacijaBaze
    {
        private BrokerBP broker = new BrokerBP();

        protected override object DeserijalizujPodatke(object podaci)
        {
            return JsonSerializer.Deserialize<UgovorSearchParametri>((JsonElement)podaci);
        }

        protected override object IzvrsiOperaciju(object podaci)
        {
            UgovorSearchParametri kriterijum = (UgovorSearchParametri)podaci;

            string upit = "SELECT u.*, z.Ime + ' ' + z.Prezime AS 'Zakupac', s.Ime + ' ' + s.Prezime as 'Stanodavac', " +
                "(SELECT COALESCE(SUM(Iznos),0) FROM StavkaUgovora su WHERE su.idUgovor = u.idUgovor) AS UkupanIznos " +
                "FROM Ugovor u JOIN Zakupac z ON u.idZakupac=z.idZakupac JOIN Stanodavac s ON u.idStanodavac = s.idStanodavac WHERE 1=1";

            var parametri = new Dictionary<string, object>();

            if (kriterijum.datumOd.HasValue)
            {
                upit += " AND u.DatumOd >= @datumOd";
                parametri.Add("@datumOd", kriterijum.datumOd.Value);
            }
            if (kriterijum.datumDo.HasValue)
            {
                upit += " AND u.DatumDo <= @datumDo";
                parametri.Add("@datumDo", kriterijum.datumDo.Value);
            }
            if (kriterijum.idZakupac.HasValue)
            {
                upit += " AND u.idZakupac = @idZakupac";
                parametri.Add("@idZakupac", kriterijum.idZakupac);
            }
            if (kriterijum.idStanodavac.HasValue)
            {
                upit += " AND u.idStanodavac = @idStanodavac";
                parametri.Add("@idStanodavac", kriterijum.idStanodavac);
            }
            upit += " ORDER BY u.DatumOd DESC";

            List<IEntity> rezultat = broker.ExecuteQuery(new Ugovor(), upit, parametri);
            return rezultat.Cast<Ugovor>().ToList();
        }

        protected override string PorukaUspesno()
        {
            return "Sistem je pronasao ugovore.";
        }
    }
}
