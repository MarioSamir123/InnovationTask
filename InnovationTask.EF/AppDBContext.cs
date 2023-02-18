using InnovationTask.Core.Model;
using Microsoft.EntityFrameworkCore;

namespace InnovationTask.EF
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) 
        { 
        
        }
        public DbSet<Order> Orders { get; set; }
    }
}