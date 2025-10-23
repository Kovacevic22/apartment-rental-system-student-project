using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    public class Zakupac : IEntity
    {
        public int IdZakupac {  get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string BrojTelefona { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int IdMesto { get; set; }
        
        public string ImePrezime => $"{Ime} {Prezime}";

        public string TableName => "Zakupac";

        public string Values => $"'{Ime}', '{Prezime}', '{BrojTelefona}', '{Email}', '{Password}', '{IdMesto}'";

        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            List<IEntity> list = new List<IEntity>();
            while (reader.Read())
            {
                Zakupac zakupac = new Zakupac
                {
                    IdZakupac = (int)reader["idZakupac"],
                    Ime = (string)reader["Ime"],
                    Prezime = (string)reader["Prezime"],
                    BrojTelefona = (string)reader["BrojTelefona"],
                    Email = (string)reader["Email"],
                    Password = (string)reader["Password"],
                    IdMesto = (int)reader["idMesto"]
                };
                list.Add(zakupac);
            }
            return list;
        }
    }
}
