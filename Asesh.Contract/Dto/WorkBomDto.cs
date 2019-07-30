using Asesh.Contract.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Asesh.Contract.Dto;

namespace Jiesen_asesh.Models
{
    public class WorkBomDto : BaseBom
    {
        /// <summary>
        /// 厂内批次，订单，工单任意能与出口发票串联的号
        /// </summary>
        public string CONTROL_NO { get; set; }

    }
}