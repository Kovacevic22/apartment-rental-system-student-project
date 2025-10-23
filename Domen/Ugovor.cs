using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    public class Ugovor : IEntity
    {
        public int IdUgovor {  get; set; }
        public DateTime DatumOd {  get; set; }
        public DateTime DatumDo { get; set; }
        public int IdStanodavac {  get; set; }
        public int IdZakupac { get; set; }
        public List<StavkaUgovora> StavkeUgovora { get; set; } = new List<StavkaUgovora>();


        public string TableName => "Ugovor";

        public string Values => $"'{DatumOd:yyyy-MM-dd}', '{DatumDo:yyyy-MM-dd}', {IdStanodavac}, {IdZakupac}";

        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            List<IEntity> lista = new List<IEntity>();
            while (reader.Read())
            {
                Ugovor ugovor = new Ugovor
                {
                    IdUgovor = (int)reader["idUgovor"],
                    DatumOd = (DateTime)reader["DatumOd"],
                    DatumDo = (DateTime)reader["DatumDo"],
                    IdStanodavac = (int)reader["idStanodavac"],
                    IdZakupac = (int)reader["idZakupac"],
                    StavkeUgovora = new List<StavkaUgovora>() // ← Prazan! Ne učitava stavke!
                };
                lista.Add(ugovor);
            }
            return lista;
        }

        //Za prikaz
        public string StanodavacImePrezime { get; set; }
        public string ZakupacImePrezime { get; set; }
        public decimal UkupanIznos { get; set; }    
        public decimal Iznos => (StavkeUgovora?.Count>0)?StavkeUgovora.Sum(s=>s.Iznos):(UkupanIznos>0?UkupanIznos:0);
    }
}
