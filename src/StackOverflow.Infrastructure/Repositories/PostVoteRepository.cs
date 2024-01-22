using NHibernate;
using StackOverflowClone.Application.Entity;

namespace StackOverflowClone.Application.Repositories
{
    public class PostVoteRepository : Repository<PostVote, Guid>, IPostVoteRepository
    {
        public PostVoteRepository(ISession session) : base(session)
        {
        }
    }
}
