namespace StackOverflowClone.Web.Entities
{
    public class Vote
    {
        public virtual int Id { get; set; }
        public virtual int UserId { get; set; }
        public virtual int QuestionId { get; set; }
        public virtual int AnswerId { get; set; }
        public virtual bool IsUpvote { get; set; }
        public virtual DateTime Timestamp { get; set; }
    }
}
