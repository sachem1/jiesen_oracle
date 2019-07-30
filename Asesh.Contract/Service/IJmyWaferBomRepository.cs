using Asesh.Contract.Model;
using Jiesen_asesh.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Asesh.Contract.Service
{
    public interface IJmyWaferBomRepository : IService
    {
        Task<List<INNERASESHJMY_WAFERQTY>> Get_WaferBOMNum(WaferBomDto erpBom);

        Task<List<INNERASESHJMY_WAFERQTY>> Get_WaferBOMList(WaferBomDto erpBom);

        Task<bool> Update(WaferBomDto erpBom);
    }
}
