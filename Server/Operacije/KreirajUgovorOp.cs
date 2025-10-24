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
    public class KreirajUgovorOp : OperacijaBaze
    {
        private BrokerBP broker = new BrokerBP();

        protected override object DeserijalizujPodatke(object podaci)
        {
            return JsonSerializer.Deserialize<Ugovor>((JsonElement)podaci);
        }

        protected override object IzvrsiOperaciju(object podaci)
        {
            Ugovor ugovor = (Ugovor)podaci;

            try
            {
                foreach (StavkaUgovora stavka in ugovor.StavkeUgovora)
                {
                    string upitProvera = "SELECT COUNT(*) FROM Ugovor u JOIN StavkaUgovora su ON su.idUgovor = u.idUgovor WHERE su.idStan = @idStan AND (u.DatumDo >= @datumOd AND u.DatumOd <= @datumDo)";
                    var parametriProvera = new Dictionary<string, object>
                    {
                        {"@idStan", stavka.IdStan },
                        {"@datumOd", ugovor.DatumOd },
                        {"@datumDo", ugovor.DatumDo }
                    };
                    int count = Convert.ToInt32(broker.ExecuteScalar(upitProvera, parametriProvera));
                    if (count > 0)
                    {
                        throw new Exception("Sistem ne moze da zapamti ugovor, jer postoji ugovor za taj stan u navedenom periodu.");
                    }
                }

                broker.BeginTransaction();

                int idUgovor = broker.InsertWithIdentity(ugovor, "idUgovor");

                foreach (StavkaUgovora stavka in ugovor.StavkeUgovora)
                {
                    stavka.IdUgovora = idUgovor;
                    broker.Insert(stavka);
                }

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
            return "Sistem je zapamtio ugovor.";
        }
    }
}
