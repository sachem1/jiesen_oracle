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
    public class AseshExportController : ApiController
    {
        private readonly ILog _logger;
        private readonly IJmyExportInfoRepository _jmyExportBomRepository;
        public AseshExportController(IJmyExportInfoRepository jmyExportBomRepository, ILog logger)
        {
            _jmyExportBomRepository = jmyExportBomRepository;
            _logger = logger;
        }

        [HttpPost]
        [Route("api/GetJmyExportQty")]
        public async Task<IHttpActionResult> GetJmyExportQty(ExportInfoDto exportInfoDto)
        {

            try
            {
                var result = await _jmyExportBomRepository.Get_ExportBOMNum(exportInfoDto);
                _logger.Info($"获取的结果:{JsonConvert.SerializeObject(result)}");
                return Json(new ReturnResult<object>() { Data = result.Select(x => new { x.INVOICE_NO }).ToList(), Success = true });
            }
            catch (System.Exception ex)
            {
                _logger.Error($"GetJmyExportQty 异常:{ex}");
                return Json(new ReturnResult<object>() { Messge = ex.ToString(), Success = false });
            }

        }

        [HttpPost]
        [Route("api/GetJmyExportQtyByNo")]
        public async Task<IHttpActionResult> GetJmyExportQtyByNo(ExportInfoDto exportInfoDto)
        {
            try
            {
                var result = await _jmyExportBomRepository.Get_ExportBOMList(exportInfoDto);
                _logger.Info($"获取的结果:{JsonConvert.SerializeObject(result)}");
                return Json(new ReturnResult<List<INNERASESHJMY_EXPORTINFO>>() { Data = result, Success = true });
            }
            catch (System.Exception ex)
            {
                _logger.Error($"GetJmyExportQtyByNo 异常:{ex}");
                return Json(new ReturnResult<object>() { Messge = ex.ToString(), Success = false });
            }
        }

        [HttpPost]
        [Route("api/UpdateExportQty")]
        public async Task<IHttpActionResult> UpdateJmyExportQty(ExportInfoDto exportInfoDto)
        {
            try
            {
                bool result = await _jmyExportBomRepository.Update(exportInfoDto);
                _logger.Info($"获取的结果:{JsonConvert.SerializeObject(result)}");
                return Json(new ReturnResult<List<INNERASESHJMY_EXPORTINFO>>() { Success = result });
            }
            catch (System.Exception ex)
            {
                _logger.Error($"UpdateJmyExportQty 异常:{ex}");
                return Json(new ReturnResult<object>() { Messge = ex.ToString(), Success = false });
            }
        }


    }
}
