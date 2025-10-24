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
        public string InsertColumns => "DatumOd, DatumDo";
        public string InsertValues => "@DatumOd, @DatumDo";
        public string UpdateSetClause => "DatumOd=@DatumOd, DatumDo=@DatumDo";
        public string WhereClause => "idTerminIz=@IdTerminIz";
        public Dictionary<string, object> GetParameters()
        {
            return new Dictionary<string, object>
            {
                { "@IdTerminIz", IdTerminIz },
                { "@DatumOd", DatumOd },
                { "@DatumDo", DatumDo }
            };
        }
        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            List<IEntity> lista = new List<IEntity>();
            while (reader.Read())
            {
                lista.Add(new TerminIznajmljivanja
                {
                    IdTerminIz = (int)reader["idTerminIz"],
                    DatumOd = (DateTime)reader["DatumOd"],
                    DatumDo = (DateTime)reader["DatumDo"]
                });
            }
            return lista;
        }
        public Dictionary<string, object> GetWhereParameters()
        {
            return new Dictionary<string, object>
            {
                { "@IdTerminIz", IdTerminIz }
            };
        }
    }
}
