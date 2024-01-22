using StackOverflowClone.Application.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackOverflowClone.Application.Entity
{
    public class PostVote : IEntity<Guid>
    {
        public virtual Guid Id { get; set; }
        public virtual Post Post { get; set; }
        public virtual User User { get; set; }
        public virtual VoteType VoteType { get; set; }
    }
}
