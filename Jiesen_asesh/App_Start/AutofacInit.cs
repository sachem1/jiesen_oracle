using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;
using Asesh.Common;
using Asesh.Contract;
using Asesh.Contract.Service;
using Asesh.Repository;
using Autofac;
using Autofac.Extras.DynamicProxy;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using EPass.Framework;
using EPass.Framework.Aop;
using log4net;

namespace Jiesen_asesh
{
    public class AutofacInit
    {
        public static void ProgramStart()
        {
            var builder = new ContainerBuilder();
            HttpConfiguration config = GlobalConfiguration.Configuration;
            
            //注册所有的Controllers
            //builder.RegisterControllers(Assembly.GetExecutingAssembly()).PropertiesAutowired();

            builder.RegisterModule(new CommonModule());
            builder.RegisterModule(new ContractModule());
            builder.RegisterModule(new FrameworkModule());
            builder.RegisterModule(new RepositoryModule());
            LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
            
            //注册所有的ApiControllers
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly()).PropertiesAutowired();
            //autofac 注册依赖
            IContainer container = builder.Build();
            // webApi部分注册
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}