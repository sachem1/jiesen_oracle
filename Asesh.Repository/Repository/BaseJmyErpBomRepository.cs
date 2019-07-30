
using Asesh.Contract;
using Dapper;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Asesh.Contract.Service;

namespace Asesh.Repository
{
    public class BaseJmyErpBomRepository<T> : IBaseJmyErpBomRepository<T> where T : class
    {
        public List<T> Get_ERPBOMList(string THROW_DATE, string EXG_NO)
        {
            IEnumerable<T> result = new List<T>();
            try
            {
                var dyParam = new OracleDynamicParameters();
                using (var conn = DapperFactory.GetConnection())
                {
                    //var query = "select * from INNER_ASESH_JMY_ERP_BOM where THROW_DATE='" + THROW_DATE + "' AND EXG_NO='" + EXG_NO +"'";
                    var query = "select * from INNER_ASESH_JMY_ERP_BOM where THROW_DATE=:THROW_DATE AND EXG_NO=:EXG_NO";
                    result = conn.Query<T>(query, new { THROW_DATE, EXG_NO });
                    //result = SqlMapper.Query<T>(conn, query, param: dyParam, commandType: CommandType.Text);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result.ToList();
        }

        public List<T> Get_ERPBOMNum()
        {
            IEnumerable<T> result = new List<T>();
            try
            {
                using (var conn = DapperFactory.GetConnection())
                {
                    var query = "select THROW_DATE,EXG_NO from INNER_ASESH_JMY_ERP_BOM where MODIFY_FLAG=0 group by THROW_DATE,EXG_NO";
                    //result = SqlMapper.Query<T>(conn, query, param: dyParam, commandType: CommandType.Text);
                    result = conn.Query<T>(query);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result.ToList();
        }

        public List<T> Get_ERPBOMList(object[] param)
        {
            throw new NotImplementedException();
        }

        public bool Update(object[] param)
        {
            throw new NotImplementedException();
        }

        public bool Update(string THROW_DATE, string EXG_NO)
        {
            using (var conn = DapperFactory.GetConnection())
            {
                var query = " update INNER_ASESH_JMY_ERP_BOM set  MODIFY_FLAG=1 where THROW_DATE=:THROW_DATE and EXG_NO=:EXG_NO";
                var conditon = new { THROW_DATE, EXG_NO };
                return conn.Execute(query, conditon) == 1;
            }
        }
    }
}
