using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Context
{
    public class ShipmentContext : DbContext
    {
        public ShipmentContext(DbContextOptions<ShipmentContext> options): base(options)  { }

        public ShipmentContext()
        {
            new ShipmentContext(new DbContextOptions<ShipmentContext>());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=tcp:shipmentmanagement-server.database.windows.net,1433;Initial Catalog=ShipmentManagementDB;Persist Security Info=False;User ID=shipmentmanagementlogin;Password=MakeThisWork!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        public DbSet<User> Users { get; set; }
    }
}