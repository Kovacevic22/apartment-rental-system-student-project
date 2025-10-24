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
    public class UbaciTerminIznajmljivanjaOp : OperacijaBaze
    {
        private BrokerBP broker = new BrokerBP();

        // (Uklonio sam konstruktor da bude dosledno sa ostalim klasama)

        protected override object DeserijalizujPodatke(object podaci)
        {
            // Preuzeo sam ime klase iz tvog isečka
            return JsonSerializer.Deserialize<UbaciTerminIzinajmljivanjaPodaci>((JsonElement)podaci);
        }

        protected override object IzvrsiOperaciju(object podaci)
        {
            UbaciTerminIzinajmljivanjaPodaci parametri = (UbaciTerminIzinajmljivanjaPodaci)podaci;

            TerminIznajmljivanja termin = parametri.terminIznajmljivanja;
            int idStanodavac = parametri.idStanodavac;
            string opisStatusa = parametri.opisStatusa;
            string upitProvera = "SELECT COUNT(*) FROM TerminIznajmljivanja t JOIN Status s on t.idTerminIz=s.idTerminIz WHERE s.idStanodavac=@idStanodavac AND t.DatumDo >= @datumOd AND t.DatumOd <= @datumDo";
            var parametriProvera = new Dictionary<string, object>()
            {
                { "@idStanodavac", idStanodavac },
                { "@datumOd", termin.DatumOd.Date },
                { "@datumDo", termin.DatumDo.Date }
            };
            int count = Convert.ToInt32(broker.ExecuteScalar(upitProvera, parametriProvera));
            if (count > 0)
            {
                throw new Exception("Sistem ne moze da zapamti termin iznajmljivanja, jer postoji termin u navedenom periodu.");
            }
            try
            {
                broker.BeginTransaction();
                int idTerminIz = broker.InsertWithIdentity(termin, "idTerminIz");

                // Kreiramo novi objekat Status i popunjavamo ga
                Status status = new Status
                {
                    IdTerminIz = idTerminIz,
                    IdStanodavac = idStanodavac, 
                    OpisStatusa = opisStatusa    
                };
                broker.Insert(status);

                broker.Commit();
                return null;
            }
            catch (Exception)
            {
                broker.Rollback();
                throw; 
            }
            finally
            {
                broker.CloseConnection();
            }
        }
        protected override string PorukaUspesno()
        {
            return "Sistem je zapamtio termin iznajmljivanja.";
        }
    }
}
