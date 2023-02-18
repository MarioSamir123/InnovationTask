using InnovationTask.Core.Model;
using InnovationTask.Core.Repositories;

namespace InnovationTask.Core.UOW
{
    public interface IUnitOfWork : IDisposable
    {
        public IGenericRepository<Order> Orders { get; }
        public int Complete();
    }
}
