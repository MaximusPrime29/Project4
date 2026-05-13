using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public class InventoryService
{
    private List<Product> products = new();
    private List<Store> stores = new();
    private List<Inventory> inventory = new();

    public void SeedData() // Test Data
    {
        Store store1 = new Store(1, "FreshChoice Eindhoven", "Eindhoven");
        Store store2 = new Store(2, "FreshChoice Veldhoven", "Veldhoven");

        stores.Add(store1);
        stores.Add(store2);

        Product milk = new Product(1, "Milk", 1.99m, "Fresh whole milk");
        Product bread = new Product(2, "Bread", 2.99m, "Whole grain bread");

        products.Add(milk);
        products.Add(bread);

        inventory.Add(new Inventory(1, 1, 1, 25, 10, DateTime.Now.AddDays(7)));
        inventory.Add(new Inventory(2, 2, 1, 5, 10, DateTime.Now.AddDays(2)));
        inventory.Add(new Inventory(3, 3, 2, 40, 15, DateTime.Now.AddDays(10)));
    }

    public InventoryService()
    {
        SeedData();
    }

    public List<Product> GetProducts()
    {
        return products;
    }

    public List<Inventory> GetInventoryByStore(int storeId)
    {
        return inventory
            .Where(i => i.StoreId == storeId)
            .ToList();
    }
    public void UpdateQuantity(int inventoryId, int newQuantity)
    {
        Inventory item = inventory
            .FirstOrDefault(i => i.InventoryId == inventoryId);

        if (item != null)
        {
            item.Quantity = newQuantity;
        }
    }
    public List<Inventory> GetLowStockItems()
    {
        return inventory
            .Where(i => i.IsLowStock())
            .ToList();
    }
    public List<Inventory> GetExpiringItems()
    {
        return inventory
            .Where(i => i.IsExpiringSoon())
            .ToList();
    }
}

