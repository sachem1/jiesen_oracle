namespace Asesh.Contract.Dto
{
    public class ConnectionParam:BaseBom
    {
        /// <summary>
        ///  1:测试数据库是否存在,2:测试表是否存在
        /// </summary>
       public int ValidateType { get; set; }
    }
}