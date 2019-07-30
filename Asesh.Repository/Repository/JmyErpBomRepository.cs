using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Asesh.Contract;
using Asesh.Contract.Dto;
using Asesh.Contract.Service;
using Dapper;

namespace Asesh.Repository.Repository
{
    public class JmyErpBomRepository : IJmyErpBomRepository
    {
        public async Task<List<INNERASESHJMY_ERPBOM>> Get_ERPBOMList(ErpBomDto erpBom)
        {
            IEnumerable<INNERASESHJMY_ERPBOM> result = new List<INNERASESHJMY_ERPBOM>();
            try
            {
                var dyParam = new OracleDynamicParameters();
                using (var conn = DapperFactory.GetConnection(erpBom.ConnectionString))
                {
                    var query = "select * from {0} where {1}=:{1} AND {2}=:{2}";
                    query = string.Format(query, erpBom.CurenetTableName, nameof(erpBom.THROW_DATE), nameof(erpBom.EXG_NO));
                    result = await conn.QueryAsync<INNERASESHJMY_ERPBOM>(query, new { erpBom.THROW_DATE, erpBom.EXG_NO });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result.ToList();
        }

        public async Task<List<INNERASESHJMY_ERPBOM>> Get_ERPBOMList(List<ErpBomDto> erpBoms)
        {
            List<INNERASESHJMY_ERPBOM> resultList = new List<INNERASESHJMY_ERPBOM>();
            try
            {
                var first = erpBoms.FirstOrDefault();
                using (var conn = DapperFactory.GetConnection(first?.ConnectionString))
                {
                    var query = "select * from {0} where {1}=:{1} AND {2}=:{2}";
                    foreach (var erpBom in erpBoms)
                    {
                        var sql = string.Format(query, erpBom.CurenetTableName, nameof(erpBom.THROW_DATE),
                            nameof(erpBom.EXG_NO));
                        var result=await conn.QueryAsync<INNERASESHJMY_ERPBOM>(sql, new {erpBom.THROW_DATE, erpBom.EXG_NO});
                        resultList.AddRange(result);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return resultList;
        }


        public async Task<List<INNERASESHJMY_ERPBOM>> Get_ERPBOMNum(ErpBomDto erpBom)
        {
            IEnumerable<INNERASESHJMY_ERPBOM> result = new List<INNERASESHJMY_ERPBOM>();
            try
            {
                using (var conn = DapperFactory.GetConnection(erpBom.ConnectionString))
                {
                    var query = "select {0},{1} from {2} where MODIFY_FLAG=0 group by {0},{1}";
                    query = string.Format(query, nameof(erpBom.THROW_DATE), nameof(erpBom.EXG_NO), erpBom.CurenetTableName);
                    result = await conn.QueryAsync<INNERASESHJMY_ERPBOM>(query);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result.ToList();
        }

        public async Task<bool> Update(ErpBomDto erpBom)
        {
            try
            {
                using (var conn = DapperFactory.GetConnection(erpBom.ConnectionString))
                {
                    var query = " update {0} set MODIFY_FLAG=1 where {1}=:{1} and {2}=:{2}";
                    query = string.Format(query, erpBom.CurenetTableName, nameof(erpBom.THROW_DATE), nameof(erpBom.EXG_NO));
                    return await conn.ExecuteAsync(query, new { erpBom.THROW_DATE, erpBom.EXG_NO }, commandType: System.Data.CommandType.Text) == 1;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> BatchUpdate(List<ErpBomDto> erpBoms)
        {
            try
            {
                var query = " update {0} set MODIFY_FLAG=1 where {1}=:{1} and {2}=:{2}";
                var first = erpBoms.FirstOrDefault();
                using (var conn = DapperFactory.GetConnection(first?.ConnectionString))
                {
                    foreach (var erpBom in erpBoms)
                    {
                        var sql = string.Format(query, erpBom.CurenetTableName, nameof(erpBom.THROW_DATE), nameof(erpBom.EXG_NO));
                        await conn.ExecuteAsync(sql, new {erpBom.THROW_DATE, erpBom.EXG_NO},
                            commandType: System.Data.CommandType.Text);
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
