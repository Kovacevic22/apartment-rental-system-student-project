using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    public class Status : IEntity
    {
        public int IdStanodavac { get; set; }
        public int IdTerminIz { get; set; }
        public string OpisStatusa { get; set; }

        public string TableName => "Status";

        public string InsertColumns => "idStanodavac, idTerminIz, OpisStatusa";

        public string InsertValues => "@idStanodavac, @idTerminIz, @OpisStatusa";

        public string UpdateSetClause => "OpisStatusa = @OpisStatusa";
        public string WhereClause => "idStanodavac = @idStanodavac AND idTerminIz = @idTerminIz";

        public Dictionary<string, object> GetParameters()
        {
            return new Dictionary<string, object>
            {
                { "@idStanodavac", IdStanodavac },
                { "@idTerminIz", IdTerminIz },
                { "@OpisStatusa", OpisStatusa }
            };
        }

        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            List<IEntity> list = new List<IEntity>();
            while (reader.Read())
            {
                list.Add(new Status
                {
                    IdStanodavac = Convert.ToInt32(reader["idStanodavac"]),
                    IdTerminIz = Convert.ToInt32(reader["idTerminIz"]),
                    OpisStatusa = reader["OpisStatusa"].ToString()
                });
            }
            return list;
        }

        public Dictionary<string, object> GetWhereParameters()
        {
            return new Dictionary<string, object>
            {
                { "@idStanodavac", IdStanodavac },
                { "@idTerminIz", IdTerminIz }
            };
        }
    }
}