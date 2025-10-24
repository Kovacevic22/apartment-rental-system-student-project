using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    public class Mesto : IEntity
    {
        public int IdMesto { get; set; }
        public string Naziv { get; set; }

        override public string ToString()
        {
            return Naziv;
        }
        public string TableName => "Mesto";
        public string InsertColumns => "Naziv";
        public string InsertValues => "@Naziv";
        public string UpdateSetClause => "Naziv=@Naziv";
        public string WhereClause => "idMesto=@IdMesto";
        public Dictionary<string, object> GetParameters()
        {
            return new Dictionary<string, object>
            {
                { "@IdMesto", IdMesto },
                { "@Naziv", Naziv }
            };
        }
        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            List<IEntity> lista = new List<IEntity>();
            while (reader.Read())
            {
                lista.Add(new Mesto
                {
                    IdMesto = (int)reader["idMesto"],
                    Naziv = (string)reader["Naziv"]
                });
            }
            return lista;
        }

        public Dictionary<string, object> GetWhereParameters()
        {
            return new Dictionary<string, object>
            {
                { "@IdMesto", IdMesto }
            };
        }
    }
}
