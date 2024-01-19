using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using StackOverflowClone.Web.Entities;

namespace StackOverflowClone.Web.Mapping
{
    public class VoteMap : ClassMapping<Vote>
    {
        public VoteMap()
        {
            Table("Votes");

            Id(x => x.Id, m => m.Generator(Generators.Identity));

            Property(x => x.UserId);
            Property(x => x.QuestionId);
            Property(x => x.AnswerId);
            Property(x => x.IsUpvote);
            Property(x => x.Timestamp);
        }
    }
}
