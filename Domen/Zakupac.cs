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

        public string InsertColumns => "Ime, Prezime, BrojTelefona, Email, Password, idMesto";

        public string InsertValues => "@Ime, @Prezime, @BrojTelefona, @Email, @Password, @IdMesto";

        public string UpdateSetClause => "Ime=@Ime, Prezime=@Prezime, BrojTelefona=@BrojTelefona, Email=@Email, Password=@Password, idMesto=@IdMesto";

        public string WhereClause => "idZakupac=@IdZakupac";

        public Dictionary<string, object> GetParameters()
        {
            return new Dictionary<string, object>
            {
                { "@IdZakupac", IdZakupac },
                { "@Ime", Ime },
                { "@Prezime", Prezime },
                { "@BrojTelefona", BrojTelefona },
                { "@Email", Email },
                { "@Password", Password },
                { "@IdMesto", IdMesto }
            };
        }

        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            List<IEntity> lista = new List<IEntity>();
            while (reader.Read())
            {
                lista.Add(new Zakupac
                {
                    IdZakupac = (int)reader["idZakupac"],
                    Ime = (string)reader["Ime"],
                    Prezime = (string)reader["Prezime"],
                    BrojTelefona = (string)reader["BrojTelefona"],
                    Email = (string)reader["Email"],
                    Password = (string)reader["Password"],
                    IdMesto = (int)reader["idMesto"]
                });
            }
            return lista;
        }
        public Dictionary<string, object> GetWhereParameters()
        {
            return new Dictionary<string, object>
            {
                { "@IdZakupac", IdZakupac }
            };
        }
    }
}
