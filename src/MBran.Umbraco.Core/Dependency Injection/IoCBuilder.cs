using Autofac;
using Autofac.Integration.Mvc;
using System;
using System.Reflection;
using Umbraco.Core;
using Umbraco.Core.Services;

namespace MBran.Umbraco.Core
{
    public class IoCBuilder
    {
        private static readonly Lazy<IoCBuilder> _instance = 
            new Lazy<IoCBuilder>(() => new IoCBuilder());
        public static IoCBuilder Instance => _instance.Value;

        private ContainerBuilder _builder;

        private IoCBuilder()
        {
            
        }
               

        public ContainerBuilder GetBuilder(ApplicationContext applicationContext, IApplicationEventHandler eventHandler)
        {
            if(_builder != null)
            {
                return _builder;
            }

            _builder = new ContainerBuilder();
            var executingAssembly = Assembly.GetExecutingAssembly();

            _builder.RegisterInstance(applicationContext.Services.ContentService).As<IContentService>();
            _builder.RegisterControllers(eventHandler.GetType().Assembly);

            _builder
                .RegisterCustomControllers(executingAssembly)
                .RegisterServices(executingAssembly)
                .RegisterRepositories(executingAssembly)
                .RegisterAssemblies();

            return _builder;
        }
    }
}
