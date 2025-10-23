using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    public class TerminIznajmljivanja : IEntity
    {
        public int IdTerminIz {  get; set; }
        public DateTime DatumOd {  get; set; }
        public DateTime DatumDo {  get; set; }
        public Status Status { get; set; }

        public string TableName => "TerminIznajmljivanja";

        public string Values => $"'{DatumOd:yyyy-MM-dd}', '{DatumDo:yyyy-MM-dd}'";

        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            List<IEntity> list = new List<IEntity>();
            while (reader.Read())
            {
                TerminIznajmljivanja termin = new TerminIznajmljivanja
                {
                    IdTerminIz = (int)reader["idTerminIz"],
                    DatumOd = (DateTime)reader["DatumOd"],
                    DatumDo = (DateTime)reader["DatumDo"]
                };
                list.Add(termin);
            }
            return list;
        }
    }
}
