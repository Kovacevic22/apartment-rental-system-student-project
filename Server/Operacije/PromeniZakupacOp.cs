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
    public class PromeniZakupacOp : OperacijaBaze
    {
        private BrokerBP broker = new BrokerBP();

        protected override object DeserijalizujPodatke(object podaci)
        {
            return JsonSerializer.Deserialize<Zakupac>((JsonElement)podaci);
        }

        protected override object IzvrsiOperaciju(object podaci)
        {
            Zakupac zakupac = (Zakupac)podaci;

            string upitProvera = "SELECT COUNT(*) FROM Zakupac WHERE (Email=@email OR BrojTelefona=@brojtelefona) AND idZakupac<>@idZakupac";
            var parametri = new Dictionary<string, object>
            {
                {"@email", zakupac.Email},
                {"@brojtelefona", zakupac.BrojTelefona },
                {"@idZakupac", zakupac.IdZakupac }
            };
            int count = Convert.ToInt32(broker.ExecuteScalar(upitProvera, parametri));
            if (count > 0)
            {
                throw new Exception("Zakupac sa unetim email-om ili brojem telefona već postoji.");
            }
            broker.Update(zakupac);
            return null;
        }

        protected override string PorukaUspesno()
        {
            return "Sistem je promenio zakupca.";
        }
    }
}
