using Complex.ICO.Utility.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MvcWeb
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // RegisterDependency就是注册接口与实例的关系．
            // setCongrollerFactory则是用MyDependencyMvcControllerFactory替代默认Controller工厂

            DependencyFactory.RegisterDependency();

            ControllerBuilder.Current.SetControllerFactory(new DependencyMvcControllerFactory());

            GlobalConfiguration.Configuration.DependencyResolver = new IoCContainer(DependencyUnityContainer.Current); 
            //var builder = new ContainerBuilder();
            //var data = Assembly.Load("Service");
            //builder.RegisterAssemblyTypes(data)
            //      .Where(a => a.FullName.Contains("SqlServer")).AsImplementedInterfaces();
            //builder.RegisterControllers(Assembly.GetExecutingAssembly());
            //var container = builder.Build();
            //DependencyResolver.SetResolver(new AutofacDependencyResolver(container));


        }
    }
}