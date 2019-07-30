using Jiesen_asesh.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Asesh.Contract.Service
{
    public interface IJmyWorkBomRepository : IService
    {
        Task<List<INNERASESHJMY_WORKBOM>> Get_WorkBOMNum(WorkBomDto erpBom);

        Task<List<INNERASESHJMY_WORKBOM>> Get_WorkBOMList(WorkBomDto erpBom);
        Task<bool> Update(WorkBomDto erpBom);
    }
}
