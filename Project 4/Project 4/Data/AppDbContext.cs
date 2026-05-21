using System;
using System.Collections.Generic;

// We created a fake, lightweight version of DbContext so your project 
// compiles perfectly without downloading any external packages.
public class DbContext
{
    protected virtual void OnModelCreating(object modelBuilder) { }
}

public class DbContextOptions<T> { }

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
    {
        // Automatically fills your dataset when the application starts
        DataSeeder.Seed(this);
    }

    // These act exactly like database tables for your website pages
    public List<Product> Products { get; set; } = new List<Product>();
    public List<Store> Stores { get; set; } = new List<Store>();
    public List<Inventory> Inventories { get; set; } = new List<Inventory>();
    public List<Transfer> Transfers { get; set; } = new List<Transfer>();
}

// --- YOUR DIRECT DATA SET ---
public static class DataSeeder
{
    public static void Seed(AppDbContext context)
    {
        // 1. Stores Data
        context.Stores.Add(new Store(1, "Main Eindhoven Warehouse", "Eindhoven HQ"));
        context.Stores.Add(new Store(2, "Amsterdam Retail Outlet", "Amsterdam Center"));
        context.Stores.Add(new Store(3, "Rotterdam Distribution Hub", "Rotterdam Port"));

        // 2. Products Data
        context.Products.Add(new Product(1, "Logitech MX Master 3S", 109.99m, "Ergonomic wireless performance mouse."));
        context.Products.Add(new Product(2, "Dell UltraSharp 27 Monitor", 349.50m, "27-inch 4K USB-C hub monitor."));
        context.Products.Add(new Product(3, "Keychron K2 V2 Keyboard", 89.00m, "Wireless mechanical keyboard."));
        context.Products.Add(new Product(4, "Anker USB-C Multi-port Hub", 45.99m, "8-in-1 USB-C data hub."));

        // 3. Inventory Data (Contains your Low Stock and Expiring test states)
        context.Inventories.Add(new Inventory(1, 1, 1, 50, 10, DateTime.Now.AddYears(2)));
        context.Inventories.Add(new Inventory(2, 2, 1, 15, 5, DateTime.Now.AddYears(3)));
        context.Inventories.Add(new Inventory(3, 1, 2, 2, 5, DateTime.Now.AddYears(2)));   // Low stock (2 left, min 5)
        context.Inventories.Add(new Inventory(4, 3, 2, 25, 8, DateTime.Now.AddYears(2)));
        context.Inventories.Add(new Inventory(5, 4, 3, 100, 20, DateTime.Now.AddDays(1))); // Expiring tomorrow

        // 4. Stock Transfers Data
        context.Transfers.Add(new Transfer(1, 1, 2, 1, 10));
    }
}