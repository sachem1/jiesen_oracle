using Asesh.Contract;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using Asesh.Contract.Service;
using Jiesen_asesh.Models;
using Asesh.Contract.Model;
using System.Threading.Tasks;

namespace Asesh.Repository
{
    public class JmyWaferBomRepository : IJmyWaferBomRepository
    {
        public async Task<List<INNERASESHJMY_WAFERQTY>> Get_WaferBOMList(WaferBomDto erpBom)
        {
            IEnumerable<INNERASESHJMY_WAFERQTY> result = new List<INNERASESHJMY_WAFERQTY>();
            try
            {
                var dyParam = new OracleDynamicParameters();
                using (var conn = DapperFactory.GetConnection(erpBom.ConnectionString))
                {
                    var query = "select * from {0} where {1}=:{2}";
                    query = string.Format(query, erpBom.CurenetTableName, nameof(erpBom.EXG_NO), nameof(erpBom.EXG_NO));
                    result = await conn.QueryAsync<INNERASESHJMY_WAFERQTY>(query, new { erpBom.EXG_NO });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result.ToList();
        }

        public async Task<List<INNERASESHJMY_WAFERQTY>> Get_WaferBOMNum(WaferBomDto erpBom)
        {
            IEnumerable<INNERASESHJMY_WAFERQTY> result = new List<INNERASESHJMY_WAFERQTY>();
            try
            {
                using (var conn = DapperFactory.GetConnection(erpBom.ConnectionString))
                {
                    var query = "select {0} from {1} where MODIFY_FLAG=0 group by {2}";
                    query = string.Format(query, nameof(erpBom.EXG_NO), erpBom.CurenetTableName, nameof(erpBom.EXG_NO));
                    result = await conn.QueryAsync<INNERASESHJMY_WAFERQTY>(query);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result.ToList();
        }

        public async Task<bool> Update(WaferBomDto erpBom)
        {
            try
            {
                using (var conn = DapperFactory.GetConnection(erpBom.ConnectionString))
                {
                    var query = " update {0} set  MODIFY_FLAG=1 where {1}=:{2}";
                    query = string.Format(query, erpBom.CurenetTableName, nameof(erpBom.EXG_NO), nameof(erpBom.EXG_NO));
                    return await conn.ExecuteAsync(query, new { erpBom.EXG_NO }, commandType: System.Data.CommandType.Text) == 1;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
