using Asesh.Contract;
using Jiesen_asesh.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Asesh.Contract.Service;
using Asesh.Common;
using Asesh.Contract.Model;
using System.Threading.Tasks;
using log4net;
using Newtonsoft.Json;

namespace Jiesen_asesh.Controllers
{
    public class AseshWaferController : ApiController
    {
        private readonly ILog _logger;
        private readonly IJmyWaferBomRepository _jmyWaferBomRepository;
        public AseshWaferController(IJmyWaferBomRepository jmyWaferBomRepository, ILog logger)
        {
            _jmyWaferBomRepository = jmyWaferBomRepository;
            _logger = logger;
        }

        [HttpPost]
        [Route("api/GetJmyWaferQty")]
        public async Task<IHttpActionResult> GetJmyWaferQty(WaferBomDto waferBomDto)
        {
            try
            {
                var result = await _jmyWaferBomRepository.Get_WaferBOMNum(waferBomDto);
                _logger.Info($"获取的结果:{JsonConvert.SerializeObject(result)}");
                return Json(new ReturnResult<object>() { Data = result.Select(x => new { x.EXG_NO }).ToList(), Success = true });
            }
            catch (System.Exception ex)
            {
                _logger.Error($"GetJmyWaferQty 异常:{ex}");
                return Json(new ReturnResult<object>() { Messge = ex.Message, Success = false });
            }
        }

        [HttpPost]
        [Route("api/GetJmyWaferQtyByNo")]
        public async Task<IHttpActionResult> GetJmyWaferQtyByNo(WaferBomDto waferBomDto)
        {
            try
            {
                var result = await _jmyWaferBomRepository.Get_WaferBOMList(waferBomDto);
                _logger.Info($"获取的结果:{JsonConvert.SerializeObject(result)}");
                return Json(new ReturnResult<List<INNERASESHJMY_WAFERQTY>>() { Data = result, Success = true });
            }
            catch (System.Exception ex)
            {
                _logger.Error($"GetJmyWaferQtyByNo 异常:{ex}");
                return Json(new ReturnResult<object>() { Messge = ex.Message, Success = false });
            }
        }

        [HttpPost]
        [Route("api/UpdateWaferQty")]
        public async Task<IHttpActionResult> UpdateJmyWaferQty(WaferBomDto waferBomDto)
        {
            try
            {
                bool result = await _jmyWaferBomRepository.Update(waferBomDto);
                return Json(new ReturnResult<List<INNERASESHJMY_WAFERQTY>>() { Success = result });
            }
            catch (System.Exception ex)
            {
                _logger.Error($"UpdateJmyWaferQty 异常:{ex}");
                return Json(new ReturnResult<object>() { Messge = ex.Message, Success = false });
            }
        }


    }
}
