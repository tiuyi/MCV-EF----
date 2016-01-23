using Autofac;
using Autofac.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace XG.Temp.DI
{
    public class AutoFacHelper
    {
        public static T GetObject<T>(string objName) where T : class
        {
            var builder = new ContainerBuilder();
            //从.config配置文件中取得相关的组件注册  
            var config = new ConfigurationSettingsReader("autofac");
            builder.RegisterModule(config);

            using (var container = builder.Build())
            {
                if (container != null)
                {
                    if (container.IsRegisteredWithName(objName, typeof(T)))
                    {
                        T obj = container.ResolveNamed<T>(objName);
                        if (obj != null)
                            return obj;
                    }
                }
            }
            return null;
        }
    }
}
