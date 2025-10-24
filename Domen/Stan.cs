using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    public class Stan : IEntity
    {
        public int IdStan { get; set; }
        public string Adresa { get; set; }
        public int Povrsina { get; set; }
        public TipStana TipStana { get; set; }
        public double BrojSoba { get; set; } 
        public override string ToString()
        {
            return Adresa;
        }
        public string TableName => "Stan";
        public string InsertColumns => "Adresa, Povrsina, TipStana, BrojSoba";
        public string InsertValues => "@Adresa, @Povrsina, @TipStana, @BrojSoba";
        public string UpdateSetClause => "Adresa=@Adresa, Povrsina=@Povrsina, TipStana=@TipStana, BrojSoba=@BrojSoba";
        public string WhereClause => "idStan=@IdStan";
        public Dictionary<string, object> GetParameters()
        {
            return new Dictionary<string, object>
            {
                { "@IdStan", IdStan },
                { "@Adresa", Adresa },
                { "@Povrsina", Povrsina },
                { "@TipStana", (int)TipStana }, 
                { "@BrojSoba", BrojSoba }
            };
        }

        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            List<IEntity> lista = new List<IEntity>();
            while (reader.Read())
            {
                lista.Add(new Stan
                {
                    IdStan = (int)reader["idStan"],
                    Adresa = (string)reader["Adresa"],
                    Povrsina = (int)reader["Povrsina"],
                    TipStana = (TipStana)Convert.ToInt32(reader["TipStana"]), 
                    BrojSoba = (double)reader["BrojSoba"]
                });
            }
            return lista;
        }
        public Dictionary<string, object> GetWhereParameters()
        {
            return new Dictionary<string, object>
            {
                { "@IdStan", IdStan }
            };
        }
    }
}
