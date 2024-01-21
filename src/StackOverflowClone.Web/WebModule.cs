using Autofac;
using StackOverflowClone.Web.Models;

namespace StackOverflowClone.Web
{
    public class WebModule : Module
    {
		public WebModule()
        { }

        protected override void Load(ContainerBuilder builder)
        {


            builder.RegisterType<RegisterModel>().AsSelf();

            builder.RegisterType<LoginModel>().AsSelf();

          

            base.Load(builder);
        }
    }
}
