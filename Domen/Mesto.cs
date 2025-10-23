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

        public string TableName => "Mesto";

        public string Values => $"'{Naziv}'";

        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            List<IEntity> list = new List<IEntity>();
            while (reader.Read())
            {
                Mesto m = new Mesto()
                {
                    IdMesto = (int)reader["idMesto"],
                    Naziv = (string)reader["Naziv"],
                };
                list.Add(m);
            }
            return list;
        }

        override public string ToString()
        {
            return Naziv;
        }
    }
}
