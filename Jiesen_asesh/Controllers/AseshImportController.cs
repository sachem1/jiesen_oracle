using Asesh.Contract;
using Jiesen_asesh.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Asesh.Contract.Service;
using Asesh.Common;
using System.Threading.Tasks;
using Asesh.Contract.Model;
using log4net;
using Newtonsoft.Json;

namespace Jiesen_asesh.Controllers
{
    public class AseshImportController : ApiController
    {
        private readonly ILog _logger;
        private readonly IJmyImportInfoRepository _jmyImportInfoRepository;
        public AseshImportController(IJmyImportInfoRepository jmyImportInfoRepository, ILog logger)
        {
            _jmyImportInfoRepository = jmyImportInfoRepository;
            _logger = logger;
        }

        [HttpPost]
        [Route("api/GetJmyImportInfo")]
        public async Task<IHttpActionResult> GetJmyImportInfo(ImportInfoDto importInfoDto)
        {
            try
            {
                var result = await _jmyImportInfoRepository.Get_ImportInfoNum(importInfoDto);
                _logger.Info($"获取的结果:{JsonConvert.SerializeObject(result)}");
                return Json(new ReturnResult<object>() { Data = result.Select(x => new { x.INVOICE_NO }).ToList(), Success = true });
            }
            catch (System.Exception ex)
            {
                _logger.Error($"GetJmyImportInfo 异常:{ex}");
                return Json(new ReturnResult<object>() { Messge = ex.Message, Success = false });
            }

        }

        [HttpPost]
        [Route("api/GetJmyImportInfoByNo")]
        public async Task<IHttpActionResult> GetJmyImportInfoByNo(ImportInfoDto importInfoDto)
        {
            try
            {
                var result = await _jmyImportInfoRepository.Get_ImportInfoList(importInfoDto);
                _logger.Info($"获取的结果:{JsonConvert.SerializeObject(result)}");
                return Json(new ReturnResult<List<INNERASESHJMY_IMPORTINFO>>() { Data = result, Success = true });
            }
            catch (System.Exception ex)
            {
                _logger.Error($"GetJmyImportInfoByNo 异常:{ex}");
                return Json(new ReturnResult<object>() { Messge = ex.Message, Success = false });
            }
        }

        [HttpPost]
        [Route("api/UpdateImportInfo")]
        public async Task<IHttpActionResult> UpdateJmyImportInfo(ImportInfoDto importInfoDto)
        {
            try
            {
                bool result = await _jmyImportInfoRepository.Update(importInfoDto);
                return Json(new ReturnResult<List<INNERASESHJMY_IMPORTINFO>>() { Success = result });
            }
            catch (System.Exception ex)
            {
                _logger.Error($"UpdateJmyImportInfo 异常:{ex}");
                return Json(new ReturnResult<object>() { Messge = ex.Message, Success = false });
            }
        }


    }
}
