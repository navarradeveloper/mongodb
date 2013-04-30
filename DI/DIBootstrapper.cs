using System.Web.Mvc;
using Blog.BL;
using Microsoft.Practices.Unity;

namespace DI
{
    public static class DIBootstrapper
    {

        public static void Run()
        {
            SetUnityContainer();
        }

        private static void SetUnityContainer()
        {
            var container = new UnityContainer();
            
            container.RegisterType<IPostService, PostService>(new PerResolveLifetimeManager());


            //container.RegisterType<Blog.DA.IDAContext, Blog.DA.DAContext>(new PerResolveLifetimeManager(), new InjectionConstructor(ConfigurationManager.ConnectionStrings["ProzittiEntities"].ConnectionString));
            container.RegisterType<Blog.DA.IDAContext, Blog.DA.DAContext>(new PerResolveLifetimeManager(), new InjectionConstructor("server=127.0.0.1;database=blog"));

            //container.RegisterType<IMembershipService, AccountMembershipService>(new PerResolveLifetimeManager());
            

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
            UnityControllerFactory slcf = new UnityControllerFactory(container);
            ControllerBuilder.Current.SetControllerFactory(slcf);
        }

    }
}
