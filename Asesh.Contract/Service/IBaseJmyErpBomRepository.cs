using System.Collections.Generic;

namespace Asesh.Contract.Service
{
    public interface IBaseJmyErpBomRepository<T>: IService
    {
        List<T> Get_ERPBOMNum();

        List<T> Get_ERPBOMList(object[] param);

        bool Update(object[] param);



    }
}
