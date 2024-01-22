using NHibernate;
using StackOverflowClone.Application.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackOverflowClone.Application.Repositories
{
    public class TagRepository : Repository<Tag, Guid>, ITagRepository
    {
        public TagRepository(ISession session) : base(session)
        {
        }
    }
}
