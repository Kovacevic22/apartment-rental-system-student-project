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
        string Values { get; }
        List<IEntity> GetReaderList(SqlDataReader reader);
    }
}
