using Asesh.Common;
using Microsoft.Build.Framework;
using Newtonsoft.Json;

namespace Asesh.Contract.Dto
{
    public class BaseBom
    {

        /// <summary>
        /// 连接字符串
        /// </summary>
        [JsonRequired]
        public string ConnectionString { get; set; }

        [JsonIgnore]
        public string CurenetTableName  => SecrityHelper.DeCode(TableName);

        /// <summary>
        /// 查询的表
        /// </summary>
        [JsonRequired]
        public string TableName
        {
            get; set;
        }
    }
}
