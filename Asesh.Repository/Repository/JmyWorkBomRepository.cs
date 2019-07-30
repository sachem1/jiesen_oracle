using Asesh.Contract;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using Asesh.Contract.Service;
using Jiesen_asesh.Models;
using System.Threading.Tasks;

namespace Asesh.Repository
{
    public class JmyWorkBomRepository : IJmyWorkBomRepository
    {
        public async Task<List<INNERASESHJMY_WORKBOM>> Get_WorkBOMList(WorkBomDto erpBom)
        {
            IEnumerable<INNERASESHJMY_WORKBOM> result = new List<INNERASESHJMY_WORKBOM>();
            try
            {
                var dyParam = new OracleDynamicParameters();
                using (var conn = DapperFactory.GetConnection(erpBom.ConnectionString))
                {
                    var query = "select * from {0} where {1}=:{2}";
                    query = string.Format(query, erpBom.CurenetTableName, nameof(erpBom.CONTROL_NO), nameof(erpBom.CONTROL_NO));
                    result =await conn.QueryAsync<INNERASESHJMY_WORKBOM>(query, new { erpBom.CONTROL_NO });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result.ToList();
        }

        public async Task<List<INNERASESHJMY_WORKBOM>> Get_WorkBOMNum(WorkBomDto erpBom)
        {
            IEnumerable<INNERASESHJMY_WORKBOM> result = new List<INNERASESHJMY_WORKBOM>();
            try
            {
                using (var conn = DapperFactory.GetConnection(erpBom.ConnectionString))
                {
                    var query = "select {0} from {1} where MODIFY_FLAG=0 group by {2}";
                    query = string.Format(query,nameof(erpBom.CONTROL_NO), erpBom.CurenetTableName, nameof(erpBom.CONTROL_NO));
                    result =await conn.QueryAsync<INNERASESHJMY_WORKBOM>(query);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result.ToList();
        }

        public async Task<bool> Update(WorkBomDto erpBom)
        {
            try
            {
                using (var conn = DapperFactory.GetConnection(erpBom.ConnectionString))
                {
                    var query = " update {0} set  MODIFY_FLAG=1 where {1}=:{2}";
                    query = string.Format(query, erpBom.CurenetTableName, nameof(erpBom.CONTROL_NO), nameof(erpBom.CONTROL_NO));
                    return await conn.ExecuteAsync(query, new { erpBom.CONTROL_NO }, commandType: System.Data.CommandType.Text) == 1;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
