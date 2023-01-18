using Microsoft.EntityFrameworkCore;
using SQLMange.Model;

namespace SQLMange.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<User> User { get; set; }
    }
}
