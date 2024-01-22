using StackOverflowClone.Application.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackOverflowClone.Application.Repositories
{
    public interface IPostVoteRepository : IRepository<PostVote,Guid>
    {
    }
}
