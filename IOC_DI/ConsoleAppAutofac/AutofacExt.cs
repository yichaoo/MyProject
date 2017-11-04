using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autofac;
using Autofac.Configuration;
namespace AutoFacDemo
{
    public static class AutofacExt
    {
        static ContainerBuilder _builder;
        static IContainer _container;
        
        /// <summary>
        /// 初始化
        /// </summary>
        public static void InitAutofac()
        {
            _builder = new ContainerBuilder();

            //武器
            _builder.RegisterType<Fireball>();
            _builder.RegisterType<Sword>();
            //玩家
            _builder.RegisterType<Archmage>();
            _builder.RegisterType<Knight>();
            //敌人
            _builder.RegisterType<Orca>();
            _builder.RegisterType<Goblin>();

            //读取配置
            _builder.RegisterModule(new ConfigurationSettingsReader("autofac"));
        }
        static IContainer Container
        {
            get
            {
                if (_container == null)
                    _container = _builder.Build();
                return _container;
            }
        }

        /// <summary>
        /// 从容器中获取对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public static T GetFromFac<T>()
        {
            T t = Container.Resolve<T>();
            return t;
        }
    }

}


