using Autofac;
using StackOverflowClone.Application.External;
using StackOverflowClone.Application.Services;

namespace StackOverflowClone.Application
{
    public class ApplicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<PostService>().As<IPostService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<TagService>().As<ITagService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<AnswerService>().As<IAnswerService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<UserService>().As<IUserService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<VoteService>().As<IVoteService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<SeedService>().As<ISeedService>()
                .InstancePerLifetimeScope();
        }
    }
}
