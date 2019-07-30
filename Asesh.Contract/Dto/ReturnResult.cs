using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asesh.Contract
{
    public class ReturnResult<T>
    {
        public ReturnResult()
        {
            Success = true;
        }
        /// <summary>
        /// 成功标识
        /// </summary>
        public bool Success { get; set; } = false;

        /// <summary>
        /// 结果集
        /// </summary>
        public T Data { get; set; }

        /// <summary>
        /// 备注内容
        /// </summary>
        public string Messge { get; set; }
    }
}
