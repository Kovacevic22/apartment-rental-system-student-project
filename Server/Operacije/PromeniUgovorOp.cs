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
    public class PromeniUgovorOp : OperacijaBaze
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
                    string upitProvera = "SELECT COUNT(*) FROM Ugovor u JOIN StavkaUgovora su on u.idUgovor=su.idUgovor WHERE su.idStan=@idStan AND su.idUgovor<>@idUgovor AND (u.DatumDo>=@datumOd AND u.DatumOd<=@datumDo)";
                    var parametriProvera = new Dictionary<string, object>
                    {
                        { "@idStan", stavka.IdStan },
                        { "@idUgovor", ugovor.IdUgovor },
                        { "@datumOd", ugovor.DatumOd.Date },
                        { "@datumDo", ugovor.DatumDo.Date }
                    };
                    int count = Convert.ToInt32(broker.ExecuteScalar(upitProvera, parametriProvera));
                    if (count > 0)
                    {
                        throw new Exception("Sistem ne moze da zapamti ugovor, jer za taj stan postoji ugovor u navedenom periodu.");
                    }
                }

                broker.BeginTransaction();

                broker.Update(ugovor);
                broker.DeleteByCondition(new StavkaUgovora(), "idUgovor=@idUgovor",
                    new Dictionary<string, object> { { "@idUgovor", ugovor.IdUgovor } });

                foreach (StavkaUgovora stavka in ugovor.StavkeUgovora)
                {
                    stavka.IdUgovora = ugovor.IdUgovor;
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
            return "Sistem je promenio ugovor.";
        }
    }
}
