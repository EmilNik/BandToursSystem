namespace SimilarBeads.Data.Common
{
    using System.Linq;

    using SimilarBeads.Data.Common.Models;

    public interface IRepository<T> : IRepository<T, int>
        where T : class
    {
    }

    public interface IRepository<T, in TKey>
        where T : class
    {
        IQueryable<T> All();

        IQueryable<T> AllWithDeleted();

        T GetById(TKey id);

        void Add(T entity);

        void Delete(T entity);

        void HardDelete(T entity);

        void SaveChanges();
    }
}
