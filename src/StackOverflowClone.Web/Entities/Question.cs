namespace StackOverflowClone.Web.Entities
{
    public class Question
    {
        public virtual int Id { get; set; }
        public virtual int UserId { get; set; }
        public virtual string Title { get; set; }
        public virtual string Body { get; set; }
        public virtual DateTime Timestamp { get; set; }
    }
}
