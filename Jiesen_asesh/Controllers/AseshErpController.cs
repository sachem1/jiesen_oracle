using Asesh.Contract;
using Jiesen_asesh.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Asesh.Contract.Service;
using Asesh.Common;
using System.Threading.Tasks;
using Asesh.Contract.Dto;
using log4net;
using Newtonsoft.Json;
using WebGrease;

namespace Jiesen_asesh.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class AseshErpController : ApiController
    {

        private readonly IJmyErpBomRepository _jmyErpBomRepository;
        private readonly ILog _logger;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="jmyErpBomRepository"></param>
        /// <param name="logger"></param>
        public AseshErpController(IJmyErpBomRepository jmyErpBomRepository, ILog logger)
        {
            _jmyErpBomRepository = jmyErpBomRepository;
            _logger = logger;
        }

        /// <summary>
        /// 获取erp bom 编号，分组数据
        /// </summary>
        /// <param name="erpBomDto"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/GetJmyErpBom")]
        public async Task<IHttpActionResult> GetJmyErpBom(ErpBomDto erpBomDto)
        {
            try
            {
                _logger.Info($"GetJmyErpBom param:{JsonConvert.SerializeObject(erpBomDto)}");
                var result = await _jmyErpBomRepository.Get_ERPBOMNum(erpBomDto);
                _logger.Info($"获取的结果:{JsonConvert.SerializeObject(result)}");
                return Json(new ReturnResult<object>() { Data = result.Select(x => new { x.THROW_DATE, x.EXG_NO }).ToList(), Success = true });
            }
            catch (System.Exception ex)
            {
                _logger.Error($"GetJmyErpBom 异常:{ex}");
                return Json(new ReturnResult<object>() { Messge = ex.Message, Success = false });
            }
        }

        /// <summary>
        /// 根据编号获取对应列表数据
        /// </summary>
        /// <param name="erpBomDto"></param>
        /// <returns></returns>

        [HttpPost]
        [Route("api/GetJmyErpBomByNo")]
        public async Task<IHttpActionResult> GetJmyErpBomByNo(ErpBomDto erpBomDto)
        {
            try
            {
                _logger.Info($"GetJmyErpBomByNo param:{JsonConvert.SerializeObject(erpBomDto)}");
                var result = await _jmyErpBomRepository.Get_ERPBOMList(erpBomDto);
                _logger.Info($"获取的结果:{JsonConvert.SerializeObject(result)}");
                return Json(new ReturnResult<List<INNERASESHJMY_ERPBOM>>() { Data = result, Success = true });
            }
            catch (System.Exception ex)
            {
                _logger.Error($"GetJmyErpBomByNo 异常:{ex}");
                return Json(new ReturnResult<object>() { Messge = ex.Message, Success = false });
            }
        }


        /// <summary>
        /// 根据编号列表获取对应列表数据
        /// </summary>
        /// <param name="erpBomDtos">建议不超过10组一次</param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/GetJmyErpBomByNoList")]
        public async Task<IHttpActionResult> GetJmyErpBom(List<ErpBomDto> erpBomDtos)
        {
            try
            {
                _logger.Info($"GetJmyErpBomByNo param:{JsonConvert.SerializeObject(erpBomDtos)}");
                var result = await _jmyErpBomRepository.Get_ERPBOMList(erpBomDtos);
                _logger.Info($"获取的结果:{JsonConvert.SerializeObject(result)}");
                return Json(new ReturnResult<List<INNERASESHJMY_ERPBOM>>() { Data = result, Success = true });
            }
            catch (System.Exception ex)
            {
                _logger.Error($"GetJmyErpBomByNo 异常:{ex}");
                return Json(new ReturnResult<object>() { Messge = ex.Message, Success = false });
            }
        }

        /// <summary>
        /// 将数据更新为已拉取
        /// </summary>
        /// <param name="erpBomDto"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/UpdateErpBom")]
        public async Task<IHttpActionResult> UpdateJmyErpBom(ErpBomDto erpBomDto)
        {
            try
            {
                _logger.Info($"UpdateJmyErpBom param:{JsonConvert.SerializeObject(erpBomDto)}");
                bool result = await _jmyErpBomRepository.Update(erpBomDto);
                return Json(new ReturnResult<List<INNERASESHJMY_ERPBOM>>() { Success = result });
            }
            catch (System.Exception ex)
            {
                _logger.Error($"UpdateJmyErpBom 异常:{ex}");
                return Json(new ReturnResult<object>() { Messge = ex.Message, Success = false });
            }
        }

        /// <summary>
        /// 批量更新数据状态
        /// </summary>
        /// <param name="erpBomDtos"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/UpdateErpBomList")]
        public async Task<IHttpActionResult> UpdateJmyErpBom(List<ErpBomDto> erpBomDtos)
        {
            try
            {
                _logger.Info($"UpdateJmyErpBom param:{JsonConvert.SerializeObject(erpBomDtos)}");
                bool result = await _jmyErpBomRepository.BatchUpdate(erpBomDtos);
                return Json(new ReturnResult<List<INNERASESHJMY_ERPBOM>>() { Success = result });
            }
            catch (System.Exception ex)
            {
                _logger.Error($"UpdateJmyErpBom 异常:{ex}");
                return Json(new ReturnResult<object>() { Messge = ex.Message, Success = false });
            }
        }
    }
}
