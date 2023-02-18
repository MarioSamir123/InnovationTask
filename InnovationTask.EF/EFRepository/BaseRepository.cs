using InnovationTask.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace InnovationTask.EF.EFRepository
{
    public class BaseRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly AppDBContext _appDBContext;
        public BaseRepository(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }


        public IEnumerable<T> Get(Expression<Func<T, bool>> critieria, int take = 0, int skip = 0, string[]? includes = null, Expression<Func<T, object>>? orderBy = null, bool orderByDes = false)
        {
            IQueryable<T> query = _appDBContext.Set<T>();
            query = query.Where(critieria);
            if (includes != null)
            {
                foreach (string include in includes)
                {
                    query = query.Include(include);
                }
            }
            if (orderBy != null)
            {
                query = (orderByDes) ? query.OrderByDescending(orderBy) : query.OrderBy(orderBy);
            }

            query = (take == 0) ? query : query.Take(take);
            query = (skip == 0) ? query : query.Skip(skip);

            return query.ToList();
        }

        public IEnumerable<T> GetAll()
        {
            List<T> items = _appDBContext.Set<T>().ToList();
            return items;
        }

        public T GetByID(int id)
        {
            T item = _appDBContext.Set<T>().Find(id);
            return item;
        }

        public T GetOne(Expression<Func<T, bool>> critieria, string[]? includes = null)
        {
            IQueryable<T> query = _appDBContext.Set<T>();
            if (includes != null)
            {
                foreach (string include in includes)
                {
                    query = query.Include(include);
                }
            }
            T item = query.FirstOrDefault(critieria);
            return item;
        }
        public T Add(T entity)
        {
            _appDBContext.Set<T>().Add(entity);
            return entity;
        }

        public T Update(T entity)
        {
            _appDBContext.Set<T>().Update(entity);
            return entity;
        }

        public void Delete(int id)
        {
            T entity = GetByID(id);
            _appDBContext.SaveChanges();
        }
    }
}
