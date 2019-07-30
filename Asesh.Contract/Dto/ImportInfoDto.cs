using Asesh.Contract.Dto;
using Asesh.Contract.Model;

namespace Jiesen_asesh.Models
{
    public class ImportInfoDto : BaseBom
    {
        /// <summary>
        /// 出口发票号
        /// </summary>
        public string INVOICE_NO { get; set; }

    }
}