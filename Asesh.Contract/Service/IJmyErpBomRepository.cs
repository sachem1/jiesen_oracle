using Jiesen_asesh.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Asesh.Contract.Dto;

namespace Asesh.Contract.Service
{
    public interface IJmyErpBomRepository: IService
    {
        Task<List<INNERASESHJMY_ERPBOM>> Get_ERPBOMNum(ErpBomDto erpBom);

        Task<List<INNERASESHJMY_ERPBOM>> Get_ERPBOMList(ErpBomDto erpBom);

        Task<List<INNERASESHJMY_ERPBOM>> Get_ERPBOMList(List<ErpBomDto> erpBoms);

        Task<bool> Update(ErpBomDto erpBom);

        Task<bool> BatchUpdate(List<ErpBomDto> erpBoms);
        
    }
}
