using System;
using System.Collections.Generic;
using System.Text;

namespace Asesh.Contract
{
    /// <summary>
    /// ERP工单BOM接口
    /// </summary>
    public class INNERASESHJMY_WORKBOM
    {
        /// <summary>
        /// 厂内批次，订单，工单任意能与出口发票串联的号
        /// </summary>
        public string CONTROL_NO { get; set; }

        public string EXG_NO { get; set; }


        public string IMG_NO { get; set; }

        public string WAFER_NO { get; set; }


        public decimal? DEC_CM { get; set; }

        public char? MODIFY_FLAG { get; set; }

        public DateTime? IMD_DATE { get; set; }
    }
}
