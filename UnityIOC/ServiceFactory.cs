using Entity.Model;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace UnityIOC
{
    public class ServiceFactory
    {
        private static object syncRoot = new Object();
        private static ServiceFactory m_Instance = null;

        /// <summary>
        /// IOC的容器，可调用来获取对应接口实例。
        /// </summary>
        public IUnityContainer Container { get; set; }

        /// <summary>
        /// 获取带EF DBContext对象及对应业务类的实例
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public ServiceFactory GetEFService(DbContext context)
        {
            //注册DbContext实例
            Instance.Container.RegisterType(typeof(DbContext), context.GetType());
            return Instance;
        }

        /// <summary>
        /// 获取带EF DBContext对象及对应业务类的实例
        /// </summary>
        /// <typeparam name="TDbContext"></typeparam>
        /// <returns></returns>
        public ServiceFactory GetEFService<TDbContext>()
            where TDbContext : DbContext
        {
            //注册DbContext实例
            Instance.Container.RegisterType<DbContext, TDbContext>();
            return Instance;
        }

        /// <summary>
        /// 创建或者从缓存中获取对应业务类的实例
        /// </summary>
        public static ServiceFactory Instance
        {
            get
            {
                if (m_Instance == null)
                {
                    lock (syncRoot)
                    {
                        if (m_Instance == null)
                        {
                            m_Instance = new ServiceFactory();
                            //初始化相关的注册接口
                            m_Instance.Container = new UnityContainer();

                            RegisterService(m_Instance.Container);
                        }
                    }
                }
                return m_Instance;
            }
        }

        /// <summary>
        /// 使用Unity自动加载对应的IService接口的实现（Service层）
        /// </summary>
        /// <param name="container"></param>
        private static void RegisterService(IUnityContainer container)
        {
            Dictionary<string, Type> dictInterface = new Dictionary<string, Type>();
            Dictionary<string, Type> dictService = new Dictionary<string, Type>();
            Assembly currentAssembly = Assembly.GetExecutingAssembly();
            string interfaceSuffix = ".IService";
            string serviceSuffix = ".Service";

            //对比程序集里面的接口和具体的接口实现类，把它们分别放到不同的字典集合里
            foreach (Type objType in currentAssembly.GetTypes())
            {
                string defaultNamespace = objType.Namespace;
                if (objType.IsInterface && defaultNamespace.EndsWith(interfaceSuffix))
                {
                    if (!dictInterface.ContainsKey(objType.FullName))
                    {
                        dictInterface.Add(objType.FullName, objType);
                    }
                }
                else if (defaultNamespace.EndsWith(serviceSuffix))
                {
                    if (!dictService.ContainsKey(objType.FullName))
                    {
                        dictService.Add(objType.FullName, objType);
                    }
                }
            }

            //根据注册的接口和接口实现集合，使用IOC容器进行注册
            foreach (string key in dictInterface.Keys)
            {
                Type interfaceType = dictInterface[key];
                foreach (string ServiceKey in dictService.Keys)
                {
                    Type ServiceType = dictService[ServiceKey];
                    if (interfaceType.IsAssignableFrom(ServiceType))//判断Service是否实现了某接口
                    {
                        container.RegisterType(interfaceType, ServiceType);
                    }
                }
            }
        }
    }
}
