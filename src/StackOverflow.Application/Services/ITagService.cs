using StackOverflowClone.Application.Entity;

namespace StackOverflowClone.Application.Services
{
    public interface ITagService
    {
        Task AddTag(Tag entity);
        Task DeleteTag(Guid id);
        Task<Tag?> GetById(Guid id);
        Task<IList<Tag>> GetAllTag();
    }
}
