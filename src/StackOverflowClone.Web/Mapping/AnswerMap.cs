using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using StackOverflowClone.Web.Entities;

namespace StackOverflowClone.Web.Mapping
{
    public class AnswerMap : ClassMapping<Answer>
    {
        public AnswerMap()
        {
            Table("Answers");

            Id(x => x.Id, m => m.Generator(Generators.Identity));

            Property(x => x.UserId);
            Property(x => x.QuestionId);
            Property(x => x.Body);
            Property(x => x.Timestamp);
        }
    }
}
