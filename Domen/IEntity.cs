using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    public interface IEntity
    {
        string TableName { get; }
        string InsertColumns { get; }
        string InsertValues { get; }
        string UpdateSetClause { get; }
        string WhereClause { get; }
        Dictionary<string, object> GetParameters();
        List<IEntity> GetReaderList(SqlDataReader reader);

        //
        Dictionary<string, object> GetWhereParameters();

    }
}
