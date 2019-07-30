using System.Reflection;
using Asesh.Contract;
using Asesh.Contract.Service;
//using Asesh.Repository.Aop;
using Asesh.Repository.Repository;
using Autofac;
using Autofac.Extras.DynamicProxy;
using EPass.Framework.Aop;
using Module = Autofac.Module;

namespace Asesh.Repository
{
    public class RepositoryModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<JmyErpBomRepository>().As<IJmyErpBomRepository>();
            builder.RegisterType<JmyWorkBomRepository>().As<IJmyWorkBomRepository>();
            builder.RegisterType<JmyWaferBomRepository>().As<IJmyWaferBomRepository>();
            builder.RegisterType<JmyExportInfoRepository>().As<IJmyExportInfoRepository>();
            builder.RegisterType<JmyImportInfoRepository>().As<IJmyImportInfoRepository>();
            builder.RegisterType<ValidateDbService>().As<IValidateDbService>();
            
            
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .Where(type => typeof(IService).IsAssignableFrom(type) && !type.GetTypeInfo().IsAbstract)
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope()
                .EnableInterfaceInterceptors()
                .InterceptedBy(typeof(LogInterceptor));
        }
    }
}