using Autofac;
using StackOverflowClone.Web.Models;
using StackOverflowClone.Web.Models.AnswerModel;
using StackOverflowClone.Web.Models.PostModel;
using StackOverflowClone.Web.Models.TagModel;
using StackOverflowClone.Web.Models.VoteModel;

namespace StackOverflowClone.Web
{
    public class WebModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterType<RegisterModel>().AsSelf()
                .InstancePerLifetimeScope();

            builder.RegisterType<LoginModel>().AsSelf()
                .InstancePerLifetimeScope();

            builder.RegisterType<TagModel>().AsSelf();

            builder.RegisterType<AddPostModel>().AsSelf();
            builder.RegisterType<PostModel>().AsSelf();

            builder.RegisterType<UpdatePostModel>().AsSelf();
            builder.RegisterType<DeleteAnswerModel>().AsSelf();
            builder.RegisterType<UpdateAnswerModel>().AsSelf();

            builder.RegisterType<AddAnswerModel>().AsSelf();

            builder.RegisterType<VoteModel>().AsSelf();

            base.Load(builder);
        }
    }
}