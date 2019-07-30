using System;
using System.Collections.Generic;
using System.Text;

namespace Asesh.Contract
{
    /// <summary>
    /// ERP标准BOM接口
    /// </summary>
    public class INNERASESHJMY_ERPBOM
    {
        /// <summary>
        /// YYYYMMDD+四位流水号
        /// </summary>
        public string THROW_DATE { get; set; }

        /// <summary>
        /// 厂内成品号
        /// </summary>
        public string EXG_NO { get; set; }

        public string IMG_NO { get; set; }

        public decimal? DEC_CM { get; set; } = 0;

        public char? GROUP_FLAG { get; set; }


        public char? MODIFY_FLAG { get; set; }

        public DateTime? IMD_DATE { get; set; }


        public char? BOND_MARK { get; set; }


        public decimal? TGBL_LOSS_RATE { get; set; }

        public decimal? INTGB_LOSS_RATE { get; set; }

        public decimal? BOND_MTPCK_PRPR { get; set; }
            
    }
}
