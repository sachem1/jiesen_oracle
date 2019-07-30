using Asesh.Common;
using Asesh.Common.Memory;
using Asesh.Contract;
using Newtonsoft.Json;
using System.Web.Http;
using Asesh.Contract.Dto;
using Asesh.Contract.Service;

namespace Jiesen_asesh.Controllers
{
    /// <summary>
    /// 初始化配置
    /// </summary>
    public class AseshController : ApiController
    {
        private readonly IValidateDbService _validateDbService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="validateDbService"></param>
        public AseshController(IValidateDbService validateDbService)
        {
            _validateDbService = validateDbService;
        }

        /// <summary>
        /// 验证库或者表是否可用
        /// </summary>
        /// <param name="connectionParam"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/ValidateConnection")]
        public IHttpActionResult ConnectionString(ConnectionParam connectionParam)
        {
            var result = _validateDbService.Validate(connectionParam);
            return Json(new ReturnResult<object>() { Success = result });
        }
    }


}
