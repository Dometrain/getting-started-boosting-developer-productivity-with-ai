using Microsoft.EntityFrameworkCore;
using OrderManager.Entities;

namespace OrderManager.DbContexts;

public class OrderManagerDbContext(DbContextOptions<OrderManagerDbContext> options) : DbContext(options)
{
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderLine> OrderLines { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Vendor> Vendors { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    { 
        modelBuilder.Entity<Order>()
            .ToTable("Orders")
            .Property(o => o.Title)
            .IsRequired()
            .HasMaxLength(100);

        modelBuilder.Entity<Order>()
            .Property(o => o.Description) 
            .HasMaxLength(300);

        modelBuilder.Entity<Order>()
           .Property(o => o.Id)
           .UseIdentityColumn();
 
        modelBuilder.Entity<Order>()
            .Property(o => o.OrderTotal) 
            .HasColumnType("decimal(18,2)"); 

        modelBuilder.Entity<OrderLine>()
            .ToTable("OrderLines")
            .Property(ol => ol.Details)
            .HasMaxLength(300);

        modelBuilder.Entity<OrderLine>()
            .Property(ol => ol.Id)
            .UseIdentityColumn();

        modelBuilder.Entity<OrderLine>()
            .Property(ol => ol.Price)
            .HasColumnType("decimal(18,2)");

        modelBuilder.Entity<Product>()
            .ToTable("Products")
            .Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(100);

        modelBuilder.Entity<Product>() 
            .Property(p => p.Description)
            .HasMaxLength(300);

        modelBuilder.Entity<Product>()
             .Property(p => p.Price)
             .HasColumnType("decimal(18,2)");

        modelBuilder.Entity<Product>()
            .Property(p => p.Id)
            .UseIdentityColumn();

        modelBuilder.Entity<Vendor>()
            .ToTable("Vendors")
            .Property(v => v.Name)
            .IsRequired()
            .HasMaxLength(100);

        modelBuilder.Entity<Vendor>() 
          .Property(v => v.Address) 
          .HasMaxLength(200);

        modelBuilder.Entity<Vendor>()
            .Property(v => v.Email)
            .IsRequired() 
            .HasMaxLength(200);

        modelBuilder.Entity<Vendor>()
           .Property(v => v.Id)
           .UseIdentityColumn(); 

        // Seed data for Products
        modelBuilder.Entity<Product>().HasData(
            new Product { Id = 1, Name = "Laptop", Description = "High performance laptop", Price = 1200.00M },
            new Product { Id = 2, Name = "Smartphone", Description = "Latest model smartphone", Price = 800.00M },
            new Product { Id = 3, Name = "Tablet", Description = "Portable touchscreen tablet", Price = 300.00M },
            new Product { Id = 4, Name = "Smartwatch", Description = "Wearable smart device", Price = 200.00M },
            new Product { Id = 5, Name = "E-Reader", Description = "Electronic book reader", Price = 150.00M },
            new Product { Id = 6, Name = "Wireless Earbuds", Description = "Bluetooth earphones", Price = 90.00M },
            new Product { Id = 7, Name = "VR Headset", Description = "Virtual reality headset", Price = 350.00M },
            new Product { Id = 8, Name = "Action Camera", Description = "Compact, durable camera", Price = 400.00M },
            new Product { Id = 9, Name = "Fitness Tracker", Description = "Wearable activity tracker", Price = 100.00M },
            new Product { Id = 10, Name = "Portable Speaker", Description = "Wireless, durable speaker", Price = 120.00M },
            new Product { Id = 11, Name = "Gaming Console", Description = "Home video game console", Price = 500.00M },
            new Product { Id = 12, Name = "Drone", Description = "Remote-controlled drone", Price = 600.00M }
        );

        // Seed data for Vendors
        modelBuilder.Entity<Vendor>().HasData(
            new Vendor { Id = 1, Name = "Tech Supplies Inc.", Address = "123 Tech Lane", Email = "contact@techsupplies.com" },
            new Vendor { Id = 2, Name = "Gadgets World", Address = "456 Gadget St.", Email = "info@gadgetsworld.com" },
            new Vendor { Id = 3, Name = "Global Tech", Address = "789 Tech Park", Email = "sales@globaltech.com" },
            new Vendor { Id = 4, Name = "Innovatech Solutions", Address = "1011 Innovation Drive", Email = "contact@innovatechsolutions.com" },
            new Vendor { Id = 5, Name = "Gadget Planet", Address = "1213 Gadget Ave", Email = "support@gadgetplanet.com" },
            new Vendor { Id = 6, Name = "Tech Trends", Address = "1415 Trendy St", Email = "info@techtrends.com" },
            new Vendor { Id = 7, Name = "Electronix", Address = "1617 Electronics Blvd", Email = "help@electronix.com" }
        );

        // Seed data for Orders
        modelBuilder.Entity<Order>().HasData(
            new Order { Id = 1, Title = "Office Supplies", Description = "Office gadgets and laptops", OrderDate = DateTime.Now, OrderTotal = 2200.00M },
            new Order { Id = 2, Title = "Personal Tech", Description = "Personal use gadgets", OrderDate = DateTime.Now.AddDays(-1), OrderTotal = 800.00M },
            new Order { Id = 3, Title = "Tech Gear", Description = "Assorted tech gadgets", OrderDate = DateTime.Now.AddDays(-2), OrderTotal = 1240.00M },
            new Order { Id = 4, Title = "Entertainment Bundle", Description = "Gaming and audio", OrderDate = DateTime.Now.AddDays(-3), OrderTotal = 1020.00M }
        );

        // Seed data for OrderLines
        modelBuilder.Entity<OrderLine>().HasData(
            new OrderLine { Id = 1, Details = "Laptop for office use", Amount = 2, Price = 1200.00M, ProductId = 1, OrderId = 1 },
            new OrderLine { Id = 2, Details = "Smartphone for personal use", Amount = 1, Price = 800.00M, ProductId = 2, OrderId = 2 },
            new OrderLine { Id = 3, Details = "Tablet for on-the-go entertainment", Amount = 2, Price = 300.00M, ProductId = 3, OrderId = 3 },
            new OrderLine { Id = 4, Details = "Smartwatch to stay connected", Amount = 1, Price = 200.00M, ProductId = 4, OrderId = 3 }
            );
 
    }
}
