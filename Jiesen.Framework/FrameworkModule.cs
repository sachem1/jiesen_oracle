using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Asesh.Contract.Service;
using Autofac;
using Autofac.Extras.DynamicProxy;
using EPass.Framework.Aop;

namespace EPass.Framework
{
    public class FrameworkModule:Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType(typeof(LogInterceptor));
        }
    }
}
