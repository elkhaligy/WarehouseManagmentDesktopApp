using Microsoft.EntityFrameworkCore;
using WarehouseManagement.Models;

namespace WarehouseManagement.Data
{
    public class WarehouseContext : DbContext
    {
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<WarehouseItem> WarehouseItems { get; set; }
        public DbSet<SupplyPermission> SupplyPermissions { get; set; }
        public DbSet<SupplyPermissionItem> SupplyPermissionItems { get; set; }
        public DbSet<ReleasePermission> ReleasePermissions { get; set; }
        public DbSet<ReleasePermissionItem> ReleasePermissionItems { get; set; }
        public DbSet<ItemTransfer> ItemTransfers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-OK63JOE\\SQLEXPRESS;Database=WarehouseManagement;Trusted_Connection=True;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure relationships for Warehouse
            modelBuilder.Entity<Warehouse>()
                .HasMany(w => w.SourceTransfers)
                .WithOne(t => t.SourceWarehouse)
                .HasForeignKey(t => t.SourceWarehouseId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Warehouse>()
                .HasMany(w => w.DestinationTransfers)
                .WithOne(t => t.DestinationWarehouse)
                .HasForeignKey(t => t.DestinationWarehouseId)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure required fields
            // modelBuilder.Entity<Warehouse>().Property(w => w.Name).IsRequired();
            // modelBuilder.Entity<Item>().Property(i => i.Code).IsRequired();
            // modelBuilder.Entity<Item>().Property(i => i.Name).IsRequired();
            // //modelBuilder.Entity<Contact>().Property(c => c.Name).IsRequired();
            // //modelBuilder.Entity<Contact>().Property(c => c.Phone).IsRequired();
            // modelBuilder.Entity<Customer>().Property(c => c.Name).IsRequired();
            // modelBuilder.Entity<Customer>().Property(c => c.Phone).IsRequired();
            // modelBuilder.Entity<Supplier>().Property(s => s.Name).IsRequired();
            // modelBuilder.Entity<Supplier>().Property(s => s.Phone).IsRequired();

            base.OnModelCreating(modelBuilder);
        }
    }
} 