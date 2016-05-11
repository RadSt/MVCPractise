using System;
using System.Web;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using Ninject;
using Ninject.Web.Common;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(WebApp.NinjectWebCommon),"Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethod(typeof(WebApp.NinjectWebCommon),"Stop")]
namespace WebApp
{
    public static class NinjectWebCommon
    {
         private static readonly Bootstrapper Bootstrapper = new Bootstrapper();

        // Старт приложения

        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            Bootstrapper.Initialize(CreateKernel);
        }

        // Остановка приложения
        public static void Stop()
        {
            Bootstrapper.ShutDown();
        }

        // Создаем ядро для управления приложением
        // <returns>The created kernel</returns>

        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();

            kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
            kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

            RegisterServices(kernel);
            return kernel;
        }

        // В RegisterServices мы добавляем регистрацию своих сервисов
        // Ядро

        private static void RegisterServices(IKernel kernel)
        {
            
        }

    }
}