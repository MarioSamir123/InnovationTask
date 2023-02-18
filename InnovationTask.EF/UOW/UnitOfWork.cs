using InnovationTask.Core.Model;
using InnovationTask.Core.Repositories;
using InnovationTask.Core.UOW;
using InnovationTask.EF.EFRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovationTask.EF.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDBContext _appDBContext;
        public IGenericRepository<Order> Orders { get; private init; }
        public UnitOfWork(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
            Orders = new BaseRepository<Order>(_appDBContext);
        }
        
        public int Complete()
        {
            int rowEffected =  _appDBContext.SaveChanges();
            return rowEffected;
        }

        public void Dispose()
        {
            _appDBContext.Dispose();
        }
    }
}
