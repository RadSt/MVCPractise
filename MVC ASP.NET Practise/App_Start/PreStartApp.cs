using MVC_ASP.NET_Practise;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(PreStartApp), "Start")]
namespace MVC_ASP.NET_Practise
{
    public static class PreStartApp
    {
        static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        //// <summary>
        //// Метод запукаеться один раз перед стартом приложения
        //// </summary>
        public static void Start()
        {
            logger.Info("Application Prestart");
        }

    }
}