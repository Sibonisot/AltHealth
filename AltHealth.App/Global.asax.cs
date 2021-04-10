using AltHealth.Data.Gateways.Repositories;
using AltHealth.Data.Gateways.Repositories.Interfaces;
using AltHealth.Data.Gateways.Repositories.Wrapper;
using AltHealth.EmailHelper.Classes;
using AltHealth.EmailHelper.Interfaces;
using Microsoft.AspNet.WebFormsDependencyInjection.Unity;
using System;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using Unity;


namespace AltHealth.App
{
    public class Global : HttpApplication
    {
        protected void Application_Error(object sender, EventArgs args)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            Exception exception = Server.GetLastError();
            if(exception != null)
            {
                logger.Error(exception);
                Response.Redirect("~/Forms/Error.aspx");
            }
        }
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            
            var container = this.AddUnity();

            container.RegisterType<IDbFactory, DbFactory>();
            container.RegisterType<IRepositoryWrapper, RepositoryWrapper>();
            container.RegisterType<IConnectionString, ConnectionString>();
            container.RegisterType<IEmailSender, EmailSender>();

            log4net.Config.XmlConfigurator.Configure();
        }
    }
}