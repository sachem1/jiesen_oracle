using Asesh.Contract.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Asesh.Contract.Dto;

namespace Jiesen_asesh.Models
{
    public class WaferBomDto : BaseBom
    {
        /// <summary>
        /// 厂内成品号
        /// </summary>
        public string EXG_NO { get; set; }

    }
}