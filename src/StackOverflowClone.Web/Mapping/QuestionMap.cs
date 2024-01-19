using NHibernate.Mapping.ByCode;
using NHibernate;
using NHibernate.Mapping.ByCode.Conformist;
using StackOverflowClone.Web.Entities;

namespace StackOverflowClone.Web.Mapping
{
    public class QuestionMap : ClassMapping<Question>
    {
        public QuestionMap()
        {
            Table("Questions");

            Id(x => x.Id, m => m.Generator(Generators.Identity));

            Property(x => x.UserId);
            Property(x => x.Title);
            Property(x => x.Body);
            Property(x => x.Timestamp);
        }
    }
}
