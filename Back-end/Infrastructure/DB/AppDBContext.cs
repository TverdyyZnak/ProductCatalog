using Infrastructure.DB.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infrastructure.DB
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<UserEntity> Users {  get; set; }
        public DbSet<CategoryEntity> Categories { get; set; }
        public DbSet<UserActionEntity> UserActions { get; set; }
        public DbSet<ProductEntity> Products { get; set; }

    }
}
