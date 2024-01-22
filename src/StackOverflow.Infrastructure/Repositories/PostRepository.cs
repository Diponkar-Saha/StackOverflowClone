using NHibernate;
using StackOverflowClone.Application.Entity;

namespace StackOverflowClone.Application.Repositories
{
    public class PostRepository : Repository<Post, Guid>, IPostRepository
    {
        public PostRepository(ISession session) : base(session)
        {
        }
    }
}
