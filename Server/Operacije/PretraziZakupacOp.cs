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
    public class PretraziZakupacOp : OperacijaBaze
    {
        private BrokerBP broker = new BrokerBP();

        protected override object DeserijalizujPodatke(object podaci)
        {
            return JsonSerializer.Deserialize<ZakupacSearchParametri>((JsonElement)podaci);
        }

        protected override object IzvrsiOperaciju(object podaci)
        {
            ZakupacSearchParametri kriterijum = (ZakupacSearchParametri)podaci;

            string upit = "SELECT * FROM Zakupac WHERE 1=1";
            var parametri = new Dictionary<string, object>();

            if (!string.IsNullOrEmpty(kriterijum.Email))
            {
                upit += " AND Email LIKE @email";
                parametri.Add("@email", "%" + kriterijum.Email + "%");
            }
            if (!string.IsNullOrEmpty(kriterijum.Ime))
            {
                upit += " AND Ime LIKE @ime";
                parametri.Add("@ime", "%" + kriterijum.Ime + "%");
            }
            if (!string.IsNullOrEmpty(kriterijum.Prezime))
            {
                upit += " AND Prezime LIKE @prezime";
                parametri.Add("@prezime", "%" + kriterijum.Prezime + "%");
            }
            if ( kriterijum.MestoId > 0)
            {
                upit += " AND idMesto = @idMesto";
                parametri.Add("@idMesto", kriterijum.MestoId);
            }

            List<IEntity> rezultat = broker.ExecuteQuery(new Zakupac(), upit, parametri);
            return rezultat.Cast<Zakupac>().ToList();
        }

        protected override string PorukaUspesno()
        {
            return "Sistem je pronasao zakupce.";
        }
    }
}
