using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using NLog;

namespace MVC_ASP.NET_Practise
{
    public class MvcApplication : HttpApplication
    {
        Logger logger = LogManager.GetCurrentClassLogger();

        protected void Application_Start()
        {
            logger.Info("Application Start");

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        public void Init()
        {
            logger.Info("application Init");
        }

        public void Dispose()
        {
            logger.Info("Application Dispose");
        }

        public void Application_Errror()
        {
            logger.Info("Application Error");
        }

        public void Application_End()
        {
            logger.Info("Application End");
        }
    }
}