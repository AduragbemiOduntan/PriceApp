using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PriceApp_Domain.Entities;
using PriceApp_Infrastructure.Configurations;

namespace PriceApp_Infrastructure.Persistence.ApplicationDbContext
{
    public class DataBaseContext : IdentityDbContext<User>
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options) { }
 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<MaterialEstimate> MaterialEstimates { get; set; }
/*        public DbSet<Estimate> Estimates { get; set; }
        public DbSet<Project> Projects { get; set; }*/
       /* public DbSet<SettingOutStage> SettingOuts { get; set; }*/
    }
}
