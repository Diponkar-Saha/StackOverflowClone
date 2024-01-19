namespace StackOverflowClone.Web.Entities
{
    public class Answer
    {
        public virtual int Id { get; set; }
        public virtual int UserId { get; set; }
        public virtual int QuestionId { get; set; }
        public virtual string Body { get; set; }
        public virtual DateTime Timestamp { get; set; }
    }
}
