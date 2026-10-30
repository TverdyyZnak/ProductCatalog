using Infrastructure.DB.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DB
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
            
        }

        public DbSet<UserEntity> Users {  get; set; }
        public DbSet<CategoryEntity> Categories { get; set; }
        public DbSet<UserActionEntity> UserActions { get; set; }
        public DbSet<ProductEntity> Products { get; set; }

    }
}
