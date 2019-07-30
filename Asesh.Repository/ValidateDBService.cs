using System;
using System.Data;
using System.Linq;
using Asesh.Contract.Dto;
using Asesh.Contract.Service;
using Dapper;

namespace Asesh.Repository
{
    public class ValidateDbService : IValidateDbService
    {
        public bool Validate(ConnectionParam param)
        {
            if (param.ValidateType == 1)
            {
                try
                {
                    using (var conn = DapperFactory.GetConnection(param.ConnectionString))
                    {
                        if(conn.State == ConnectionState.Open)
                            return true;
                        return false;
                    }
                }
                catch (Exception)
                {
                    return false;
                }
            }
            try
            {
                var query = $"select count(1) from {param.CurenetTableName}";
                using (var conn = DapperFactory.GetConnection(param.ConnectionString))
                {
                    var result = conn.Query<int>(query).First();
                    return result>=0;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
