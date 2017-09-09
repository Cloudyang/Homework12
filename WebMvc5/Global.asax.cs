using Entity.Model;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace WebMvc5
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            ControllerBuilder.Current.SetControllerFactory(new UnityControllerFactory());
        }
    }

    /// <summary>
    /// 自定义Unity容器加载工厂(省去配置文件通过约定来实现反射加载)
    /// </summary>
    public class UnityControllerFactory : DefaultControllerFactory
    {
        private IUnityContainer UnityContainer
        {
            get
            {
                IUnityContainer container = RegisterService();
                return container;
            }
        }

        /// <summary>
        /// 使用Unity自动加载对应的IService接口的实现（Service层）
        /// </summary>
        /// <param name="container"></param>
        private static IUnityContainer RegisterService()
        {
            IUnityContainer container = new UnityContainer();
            Dictionary<string, Type> dictInterface = new Dictionary<string, Type>();
            Dictionary<string, Type> dictService = new Dictionary<string, Type>();
            //先注册JDContext : DbContext
            container.RegisterType<DbContext, JDContext>();

            var itypes = Assembly.Load("Bussiness.IService").GetTypes();
            var types= Assembly.Load("Bussiness.Service").GetTypes();
            foreach (var itype in itypes)
            {
                var type = types.FirstOrDefault(t => itype.IsAssignableFrom(t) 
                                                || (itype.IsGenericType && t.IsGenericType));
                if (type != null)
                {
                    container.RegisterType(itype, type);
                }
            }
            
            return container;
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            if (controllerType == null)
            {
                return null;
            }
            IController controller = (IController)this.UnityContainer.Resolve(controllerType);
            return controller;
        }

        public override void ReleaseController(IController controller)
        {
            this.UnityContainer.Teardown(controller);
            base.ReleaseController(controller);
        }
    }
}
