using NHibernate;
using StackOverflowClone.Application.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackOverflowClone.Application.Repositories
{
    public class AnswerRepository : Repository<Answer, Guid>, IAnswerRepository
    {
        public AnswerRepository(ISession session) : base(session)
        {
        }
    }
}
