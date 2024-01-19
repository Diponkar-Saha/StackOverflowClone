namespace StackOverflowClone.Web.Repository
{
    public interface IFuncionRepository<T> where T : class
    {
        Task Add(T item);
        Task Remove(long id);
        Task Update(T item);
        Task<T> FindById(long id);
        IEnumerable<T> FindAll();
    }
}
