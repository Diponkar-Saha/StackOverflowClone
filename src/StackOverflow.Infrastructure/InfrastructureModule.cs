using Autofac;
using StackOverflowClone.Application.Repositories;
using StackOverflowClone.Application.UnitOfWorks;

namespace StackOverflowClone.Application
{
    public class InfrastructureModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<PostRepository>().As<IPostRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<UserRepository>().As<IUserRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<TagRepository>().As<ITagRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<AnswerRepository>().As<IAnswerRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<AnswerVoteRepository>().As<IAnswerVoteRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<PostVoteRepository>().As<IPostVoteRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>()
                .InstancePerLifetimeScope();
        }
    }
}
/*
 * 
 
 * */