using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asesh.Contract.Model
{
    /// <summary>
    /// ERP出口发票接口
    /// </summary>
    public class INNERASESHJMY_EXPORTINFO
    {
        /// <summary>
        /// 出口发票号
        /// </summary>
        public string INVOICE_NO { get; set; }

        public string DN_NO { get; set; }


        public string G_NO { get; set; }


        public string Curr { get; set; }


        public decimal? TOTAL { get; set; }


        public decimal? QTY { get; set; }


        public decimal? QTY_2 { get; set; }

        public string CONTROL_NO { get; set; }

        public string ORGIN_COUNTRY { get; set; }

        public string SHIPTO_COUNTRY { get; set; }

        public char? MODIFY_FLAG { get; set; }

        public DateTime? IMD_DATE { get; set; }

    }
}
