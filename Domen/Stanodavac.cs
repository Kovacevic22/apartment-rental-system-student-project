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

        public string Values => $"'{Ime}', '{Prezime}', '{BrojTelefona}', '{Email}', '{Password}'";

        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            List<IEntity> list = new List<IEntity>();
            while (reader.Read())
            {
                Stanodavac stanodavac = new Stanodavac
                {
                    IdStanodavac = (int)reader["idStanodavac"],
                    Ime = (string)reader["Ime"],
                    Prezime = (string)reader["Prezime"],
                    BrojTelefona = (string)reader["BrojTelefona"],
                    Email = (string)reader["Email"],
                    Password = (string)reader["Password"]
                };
                list.Add(stanodavac);
            }
            return list;
        }
    }
}
