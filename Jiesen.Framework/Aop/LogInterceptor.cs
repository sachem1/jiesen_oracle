using System;
using System.Diagnostics;
using System.Globalization;
using Castle.DynamicProxy;
using log4net;
using Newtonsoft.Json;

namespace EPass.Framework.Aop
{
    public class LogInterceptor : IInterceptor
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(LogInterceptor));
        public void Intercept(IInvocation invocation)
        {
            Logger.Info($"{DateTime.Now.ToString(CultureInfo.InvariantCulture)}方法{invocation.Method.Name}" +
                              $"调用前,参数:{JsonConvert.SerializeObject(invocation.Arguments)}");
            Stopwatch watch = new Stopwatch();
            watch.Start();
            invocation.Proceed();
            Logger.Info($"{DateTime.Now.ToString(CultureInfo.InvariantCulture)}方法{invocation.Method.Name}" +
                              $"调用后,耗时:{watch.ElapsedMilliseconds}");
        }
    }
}
