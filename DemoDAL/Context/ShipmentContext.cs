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
            //Primary Keys
            modelBuilder.Entity<Shipment>().HasKey(s => new { s.Id });
            modelBuilder.Entity<Customer>().HasKey(c => new { c.Id });
            modelBuilder.Entity<Container>().HasKey(co => new { co.Id });
            modelBuilder.Entity<User>().HasKey(o => new { o.Id });

            //Relations
            //Shipment - Customer (Many to One)

            modelBuilder.Entity<Shipment>()
                .HasOne(s => s.Customer)
                .WithMany(c => c.Shipments)
                .HasForeignKey(s => s.CustomerId);

            modelBuilder.Entity<Customer>()
                .HasMany(c => c.Shipments)
                .WithOne(s => s.Customer);

            //Shipment - Container (One to Many)

            modelBuilder.Entity<Container>()
                .HasOne(co => co.Shipment)
                .WithMany(s => s.Containers)
                .HasForeignKey(co => co.ShipmentId);

            modelBuilder.Entity<Shipment>()
                .HasMany(s => s.Containers)
                .WithOne(co => co.Shipment);



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
        public DbSet<Shipment> Shipments { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Container> Containers { get; set; }
    }
}