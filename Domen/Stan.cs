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
        public int IdStan {  get; set; }
        public string Adresa { get; set; }
        public int Povrsina { get; set; }
        public TipStana TipStana { get; set; }
        public double BrojSoba { get; set; }

        public string TableName => "Stan";

        public string Values => $"'{Adresa}', {Povrsina}, '{TipStana}', {BrojSoba}";

        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            List<IEntity> lista = new List<IEntity>();
            while (reader.Read())
            {
                Stan stan = new Stan
                {
                    IdStan = (int)reader["idStan"],
                    Adresa = (string)reader["Adresa"],
                    Povrsina = (int)reader["Povrsina"],
                    TipStana = (TipStana)reader["TipStana"],
                    BrojSoba = (double)reader["BrojSoba"]
                };
                lista.Add(stan);
            }
            return lista;
        }

        public override string ToString()
        {
            return Adresa;
        }

    }
}
