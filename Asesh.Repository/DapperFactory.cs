using System.Configuration;
using System.Data;
using Asesh.Common;
using Oracle.ManagedDataAccess.Client;

namespace Asesh.Repository
{
    public class DapperFactory
    {
        public static IDbConnection GetConnection(string connString=null)
        {
            var connectionString = connString?? ConfigurationManager.ConnectionStrings["OracleConnString"].ConnectionString;
            //var connParam = MemoryCacheManager.Get<ConnectionParam>(StaticString.CurrentConnString);
            //if (!string.IsNullOrEmpty(connParam?.ConnectionString))
            //    connectionString = connParam.ConnectionString;
            var conn = new OracleConnection(SecrityHelper.DeCode(connectionString));
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            return conn;
        }
    }
}