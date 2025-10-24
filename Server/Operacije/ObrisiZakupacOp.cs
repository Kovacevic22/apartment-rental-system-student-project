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
    public class ObrisiZakupacOp : OperacijaBaze
    {
        private BrokerBP broker = new BrokerBP();

        protected override object DeserijalizujPodatke(object podaci)
        {
            return JsonSerializer.Deserialize<int>((JsonElement)podaci);
        }

        protected override object IzvrsiOperaciju(object podaci)
        {
            int zakupacId = (int)podaci;

            string upitProvera = "SELECT COUNT(*) FROM Ugovor WHERE idZakupac=@zakupacId";
            var parametar = new Dictionary<string, object> { { "@zakupacId", zakupacId } };

            int count = Convert.ToInt32(broker.ExecuteScalar(upitProvera, parametar));
            if (count > 0)
            {
                throw new Exception("Sistem ne moze da obrise zakupca, jer postoji ugovor povezan s njim.");
            }
            broker.Delete(new Zakupac { IdZakupac = zakupacId });
            return null;
        }

        protected override string PorukaUspesno()
        {
            return "Sistem je obrisao zakupca.";
        }
    }
}
