using Microsoft.Data.SqlClient;

namespace Domen
{
    public class Stanodavac : IEntity
    {
        public int IdStanodavac {  get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string BrojTelefona { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public string TableName => "Stanodavac";
        public string InsertColumns => "Ime, Prezime, BrojTelefona, Email, Password";
        public string InsertValues => "@Ime, @Prezime, @BrojTelefona, @Email, @Password";
        public string UpdateSetClause => "Ime=@Ime, Prezime=@Prezime, BrojTelefona=@BrojTelefona, Email=@Email, Password=@Password";
        public string WhereClause => "idStanodavac=@IdStanodavac";
        public Dictionary<string, object> GetParameters()
        {
            return new Dictionary<string, object>
            {
                { "@IdStanodavac", IdStanodavac },
                { "@Ime", Ime },
                { "@Prezime", Prezime },
                { "@BrojTelefona", BrojTelefona },
                { "@Email", Email },
                { "@Password", Password }
            };
        }

        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            List<IEntity> lista = new List<IEntity>();
            while (reader.Read())
            {
                lista.Add(new Stanodavac
                {
                    IdStanodavac = (int)reader["idStanodavac"],
                    Ime = (string)reader["Ime"],
                    Prezime = (string)reader["Prezime"],
                    BrojTelefona = (string)reader["BrojTelefona"],
                    Email = (string)reader["Email"],
                    Password = (string)reader["Password"]
                });
            }
            return lista;
        }
        public Dictionary<string, object> GetWhereParameters()
        {
            return new Dictionary<string, object>
            {
                { "@IdStanodavac", IdStanodavac }
            };
        }
    }
}
