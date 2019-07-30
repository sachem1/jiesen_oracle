using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YtToolKit;

namespace Asesh.Common
{
    public class SecrityHelper
    {
        public static string EnCode(string value)
        {
            return DeEnHelper.Instance.EnCode(value);
        }

        public static string DeCode(string value)
        {
            return DeEnHelper.Instance.DeCode(value);
        }
    }
}
