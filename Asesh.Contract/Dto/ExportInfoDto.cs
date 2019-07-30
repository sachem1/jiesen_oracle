using Asesh.Contract.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Asesh.Contract.Dto;

namespace Jiesen_asesh.Models
{
    public class ExportInfoDto : BaseBom
    {
        /// <summary>
        /// 出口发票号
        /// </summary>
        public string INVOICE_NO { get; set; }

    }
}