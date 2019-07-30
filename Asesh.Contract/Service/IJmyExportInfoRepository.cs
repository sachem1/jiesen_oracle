using Asesh.Contract.Model;
using Jiesen_asesh.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Asesh.Contract.Service
{
    public interface IJmyExportInfoRepository : IService
    {
        Task<List<INNERASESHJMY_EXPORTINFO>> Get_ExportBOMNum(ExportInfoDto erpBom);

        Task<List<INNERASESHJMY_EXPORTINFO>> Get_ExportBOMList(ExportInfoDto erpBom);

        Task<bool> Update(ExportInfoDto erpBom);
    }
}
