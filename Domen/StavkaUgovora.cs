using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    public class StavkaUgovora : IEntity
    {
        public int IdUgovora { get; set; }
        public int Rb {  get; set; }
        public int IdStan {  get; set; }
        public decimal Iznos { get; set; }
        public Stan Stan { get; set; }

        public string TableName => "StavkaUgovora";

        public string Values => $"{IdUgovora}, {Rb}, {Stan.IdStan}, {Iznos}";

        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            List<IEntity> list = new List<IEntity>();
            while (reader.Read())
            {
                StavkaUgovora stavka = new StavkaUgovora
                {
                    IdUgovora = (int)reader["idUgovor"],
                    Rb = (int)reader["rb"],
                    Stan = new Stan { IdStan = (int)reader["idStan"] },
                    Iznos = Convert.ToDecimal(reader["Iznos"])
                };
                list.Add(stavka);
            }
            return list;
        }
    }
}
