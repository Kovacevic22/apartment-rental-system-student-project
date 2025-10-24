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
    public class VratiUgovorSaStavkamaOp : OperacijaBaze
    {
        private BrokerBP broker = new BrokerBP();

        protected override object DeserijalizujPodatke(object podaci)
        {
            return JsonSerializer.Deserialize<int>((JsonElement)podaci);
        }

        protected override object IzvrsiOperaciju(object podaci)
        {
            int ugovorId = (int)podaci;

            string upitOsnovni = "SELECT u.*, z.Ime + ' ' + z.Prezime AS 'Zakupac', s.Ime + ' ' + s.Prezime as 'Stanodavac', " + 
                "(SELECT COALESCE(SUM(su.Iznos),0) FROM StavkaUgovora su WHERE su.idUgovor = u.idUgovor) AS UkupanIznos " + 
                "FROM Ugovor u JOIN Zakupac z ON u.idZakupac=z.idZakupac JOIN Stanodavac s ON u.idStanodavac = s.idStanodavac " +
                "WHERE u.idUgovor = @idUgovor";

            var parametri = new Dictionary<string, object> { { "@idUgovor", ugovorId } };
            List<IEntity> ugovoriList = broker.ExecuteQuery(new Ugovor(), upitOsnovni, parametri);

            if (ugovoriList.Count == 0)
            {
                throw new Exception("Ugovor nije pronadjen");
            }

            Ugovor rezultat = (Ugovor)ugovoriList[0];

            string upitStavka = "SELECT su.*, st.Adresa, st.Povrsina, st.TipStana, st.BrojSoba FROM StavkaUgovora su JOIN Stan st on su.idStan=st.idStan WHERE su.idUgovor=@idUgovor ORDER BY su.rb";
            List<IEntity> stavkeList = broker.ExecuteQuery(new StavkaUgovora(), upitStavka, parametri);
            rezultat.StavkeUgovora = stavkeList.Cast<StavkaUgovora>().ToList();

            return rezultat;
        }

        protected override string PorukaUspesno()
        {
            return "Sistem je ucitao ugovor.";
        }
    }
}
