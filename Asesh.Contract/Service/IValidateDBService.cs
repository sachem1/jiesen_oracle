using Asesh.Contract.Dto;

namespace Asesh.Contract.Service
{
    public interface IValidateDbService
    {
        bool Validate(ConnectionParam param);
    }
}
