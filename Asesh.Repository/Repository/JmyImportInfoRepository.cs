using Asesh.Contract;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using Asesh.Contract.Service;
using Jiesen_asesh.Models;
using System.Threading.Tasks;
using Asesh.Contract.Model;

namespace Asesh.Repository
{
    public class JmyImportInfoRepository : IJmyImportInfoRepository
    {
        public async Task<List<INNERASESHJMY_IMPORTINFO>> Get_ImportInfoList(ImportInfoDto exportInfoDto)
        {
            IEnumerable<INNERASESHJMY_IMPORTINFO> result = new List<INNERASESHJMY_IMPORTINFO>();
            try
            {
                using (var conn = DapperFactory.GetConnection(exportInfoDto.ConnectionString))
                {
                    var query = "select * from {0} where {1}=:{1}";
                    query = string.Format(query, exportInfoDto.CurenetTableName, nameof(exportInfoDto.INVOICE_NO));
                    result = await conn.QueryAsync<INNERASESHJMY_IMPORTINFO>(query, new { exportInfoDto.INVOICE_NO });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result.ToList();
        }

        public async Task<List<INNERASESHJMY_IMPORTINFO>> Get_ImportInfoNum(ImportInfoDto exportInfoDto)
        {
            IEnumerable<INNERASESHJMY_IMPORTINFO> result = new List<INNERASESHJMY_IMPORTINFO>();
            try
            {
                using (var conn = DapperFactory.GetConnection(exportInfoDto.ConnectionString))
                {
                    var query = "select {0} from {1} where MODIFY_FLAG=0 group by {0}";
                    query = string.Format(query, nameof(exportInfoDto.INVOICE_NO), exportInfoDto.CurenetTableName);
                    result = await conn.QueryAsync<INNERASESHJMY_IMPORTINFO>(query);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result.ToList();
        }

        public async Task<bool> Update(ImportInfoDto exportInfoDto)
        {
            try
            {
                using (var conn = DapperFactory.GetConnection(exportInfoDto.ConnectionString))
                {
                    var query = " update {0} set  MODIFY_FLAG=1 where {1}=:{1}";
                    query = string.Format(query, exportInfoDto.CurenetTableName, nameof(exportInfoDto.INVOICE_NO));
                    return await conn.ExecuteAsync(query, new { exportInfoDto.INVOICE_NO }, commandType: System.Data.CommandType.Text) == 1;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
