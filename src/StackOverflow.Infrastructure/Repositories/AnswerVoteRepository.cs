using NHibernate;
using StackOverflowClone.Application.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackOverflowClone.Application.Repositories
{
    public class AnswerVoteRepository : Repository<AnswerVote, Guid>, IAnswerVoteRepository
    {
        public AnswerVoteRepository(ISession session) : base(session)
        {
        }
    }
}
