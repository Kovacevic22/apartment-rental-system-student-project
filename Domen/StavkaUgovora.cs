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
        public string InsertColumns => "idUgovor, rb, idStan, Iznos";
        public string InsertValues => "@IdUgovora, @Rb, @IdStan, @Iznos";
        public string UpdateSetClause => "idStan=@IdStan, Iznos=@Iznos";
        public string WhereClause => "idUgovor=@IdUgovora AND rb=@Rb";
        public Dictionary<string, object> GetParameters()
        {
            return new Dictionary<string, object>
            {
                { "@IdUgovora", IdUgovora },
                { "@Rb", Rb },
                { "@IdStan", IdStan },
                { "@Iznos", Iznos }
            };
        }

        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            List<IEntity> lista = new List<IEntity>();
            while (reader.Read())
            {
                lista.Add(new StavkaUgovora
                {
                    IdUgovora = (int)reader["idUgovor"],
                    Rb = (int)reader["rb"],
                    IdStan = (int)reader["idStan"], 
                    Iznos = Convert.ToDecimal(reader["Iznos"]),
                    Stan = new Stan
                    {
                        IdStan = (int)reader["idStan"], 
                        Adresa = (string)reader["Adresa"],
                        Povrsina = (int)reader["Povrsina"],
                        TipStana = (TipStana)Convert.ToInt32(reader["TipStana"]),
                        BrojSoba = (double)reader["BrojSoba"]
                    }
                });
            }
            return lista;
        }
        public Dictionary<string, object> GetWhereParameters()
        {
            return new Dictionary<string, object>
            {
                { "@IdUgovora", IdUgovora },
                { "@Rb", Rb }
            };
        }
    }
}
