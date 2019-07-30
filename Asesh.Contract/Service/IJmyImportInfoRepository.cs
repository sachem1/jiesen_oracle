using Asesh.Contract.Model;
using Jiesen_asesh.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Asesh.Contract.Service
{
    public interface IJmyImportInfoRepository : IService
    {
        Task<List<INNERASESHJMY_IMPORTINFO>> Get_ImportInfoNum(ImportInfoDto erpBom);

        Task<List<INNERASESHJMY_IMPORTINFO>> Get_ImportInfoList(ImportInfoDto erpBom);

        Task<bool> Update(ImportInfoDto erpBom);
    }
}
