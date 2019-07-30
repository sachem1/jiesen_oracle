using Asesh.Contract.Model;

namespace Asesh.Contract.Dto
{
    public class ErpBomDto: BaseBom
    {
        /// <summary>
        /// YYYYMMDD+四位流水号
        /// </summary>
        public string THROW_DATE { get; set; }

        /// <summary>
        /// 厂内成品号
        /// </summary>
        public string EXG_NO { get; set; }
    }
}