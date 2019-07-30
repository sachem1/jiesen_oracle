using System;

namespace Asesh.Contract.Model
{
    /// <summary>
    /// ERP成品耗用WAFER量接口
    /// </summary>
    public class INNERASESHJMY_WAFERQTY
    {
        /// <summary>
        /// 厂内成品号
        /// </summary>
        public string EXG_NO { get; set; }

        public decimal? WAFER_NO_QTY { get; set; }

        public char? MODIFY_FLAG { get; set; }

        public DateTime? IMD_DATE { get; set; }
        
    }
}
