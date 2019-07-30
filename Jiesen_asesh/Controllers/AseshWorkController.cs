using Asesh.Contract;
using Jiesen_asesh.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Asesh.Contract.Service;
using Asesh.Common;
using System.Threading.Tasks;
using log4net;
using Newtonsoft.Json;

namespace Jiesen_asesh.Controllers
{
    public class AseshWorkController : ApiController
    {
        private readonly ILog _logger;
        private readonly IJmyWorkBomRepository _jmyWorkBomRepository;
        public AseshWorkController(IJmyWorkBomRepository jmyWorkBomRepository, ILog logger)
        {
            _jmyWorkBomRepository = jmyWorkBomRepository;
            _logger = logger;
        }

        /// <summary>
        /// 获取ERP工单编号
        /// </summary>
        /// <param name="workBomDto"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/GetJmyWorkBom")]
        public async Task<IHttpActionResult> GetJmyWorkBom(WorkBomDto workBomDto)
        {
            try
            {
                var result = await _jmyWorkBomRepository.Get_WorkBOMNum(workBomDto);
                _logger.Info($"获取的结果:{JsonConvert.SerializeObject(result)}");
                return Json(new ReturnResult<object>() { Data = result.Select(x => new { x.CONTROL_NO }).ToList(), Success = true });
            }
            catch (System.Exception ex)
            {
                _logger.Error($"GetJmyWorkBom 异常:{ex.ToString()}");
                return Json(new ReturnResult<object>() { Messge = ex.Message, Success = false });
            }
        }

        /// <summary>
        /// 根据工单编号获取列表
        /// </summary>
        /// <param name="workBomDto"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/GetJmyWorkBomByNo")]
        public async Task<IHttpActionResult> GetJmyWorkBomByNo(WorkBomDto workBomDto)
        {
            try
            {
                var result = await _jmyWorkBomRepository.Get_WorkBOMList(workBomDto);
                _logger.Info($"获取的结果:{JsonConvert.SerializeObject(result)}");
                return Json(new ReturnResult<List<INNERASESHJMY_WORKBOM>>() { Data = result, Success = true });
            }
            catch (System.Exception ex)
            {
                _logger.Error($"GetJmyWorkBomByNo 异常:{ex.ToString()}");
                return Json(new ReturnResult<object>() { Messge = ex.Message, Success = false });
            }
        }

        /// <summary>
        /// 根据工单更新
        /// </summary>
        /// <param name="workBomDto"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/UpdateWorkBom")]
        public async Task<IHttpActionResult> UpdateJmyWorkBom(WorkBomDto workBomDto)
        {
            try
            {
                bool result = await _jmyWorkBomRepository.Update(workBomDto);
                return Json(new ReturnResult<List<INNERASESHJMY_WORKBOM>>() { Success = result });
            }
            catch (System.Exception ex)
            {
                _logger.Error($"UpdateJmyWorkBom 异常:{ex}");
                return Json(new ReturnResult<object>() { Messge = ex.Message, Success = false });
            }
        }


    }
}
