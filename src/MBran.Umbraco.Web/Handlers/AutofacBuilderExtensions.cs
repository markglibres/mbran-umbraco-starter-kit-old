using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using MBran.Umbraco.Components;
using System.Linq;
using System.Reflection;
using System.Web.Compilation;
using System.Web.Mvc;
using Umbraco.Web;

namespace MBran.Umbraco.Web
{
    public static class AutofacBuilderExtensions
    {
        public static ContainerBuilder RegisterUmbraco(this ContainerBuilder builder)
        {
            builder.RegisterCustomControllers(typeof(UmbracoApplication).Assembly);
            builder.RegisterApiControllers(typeof(UmbracoApplication).Assembly);


            return builder;
        }

        public static ContainerBuilder RegisterModules(this ContainerBuilder builder)
        {
            var assemblies = BuildManager.GetReferencedAssemblies().Cast<Assembly>();
            foreach (var assembly in assemblies)
            {
                builder.RegisterAssemblyModules(assembly);
            }
            return builder;
        }

        public static ContainerBuilder RegisterCustomControllers(this ContainerBuilder builder, Assembly executingAssembly)
        {
            builder.RegisterAssemblyTypes(executingAssembly)
                .Where(c => c.Name.EndsWith("Controller"))
                .AsImplementedInterfaces();
            builder.RegisterAssemblyTypes(executingAssembly)
                .Where(t => t.BaseType == typeof(ComponentSurfaceController))
                .As<ComponentSurfaceController>();
            return builder;
        }

        public static ContainerBuilder RegisterServices(this ContainerBuilder builder, Assembly executingAssembly)
        {
            builder.RegisterAssemblyTypes(executingAssembly)
                .Where(c => c.Name.EndsWith("Service"))
                .AsImplementedInterfaces();

            return builder;
        }
        public static ContainerBuilder RegisterRepositories(this ContainerBuilder builder, Assembly executingAssembly)
        {
            builder.RegisterAssemblyTypes(executingAssembly)
                .Where(c => c.Name.EndsWith("Repository"))
                .AsImplementedInterfaces();

            return builder;
        }

        public static void BuildContainer(this ContainerBuilder builder)
        {
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

        }

    }
}
