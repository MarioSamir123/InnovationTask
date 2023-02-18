using System.Linq.Expressions;

namespace InnovationTask.Core.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        TEntity GetByID(int id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> critieria,
            int take = 0, int skip = 0,
            string[]? includes = null,
            Expression<Func<TEntity, object>>? orderBy = null, bool orderByDes = false);
        TEntity GetOne(Expression<Func<TEntity, bool>> critieria, string[]? includes = null);
        TEntity Add(TEntity entity);
        TEntity Update(TEntity entity);
        void Delete(int id);
    }
}
