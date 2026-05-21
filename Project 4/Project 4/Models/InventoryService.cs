using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public class InventoryService
{
    private readonly AppDbContext context;

    public InventoryService(AppDbContext context)
    {
        this.context = context;
    }

    public List<Product> GetProducts()
    {
        return context.Products;
    }

    public List<Inventory> GetInventoryByStore(int storeId)
    {
        return context.Inventories
            .Where(i => i.StoreId == storeId)
            .ToList();
    }

    public void UpdateQuantity(int inventoryId, int newQuantity)
    {
        Inventory? item = context.Inventories
            .FirstOrDefault(i => i.InventoryId == inventoryId);

        if (item != null)
        {
            item.Quantity = newQuantity;
        }
    }

    public List<Inventory> GetLowStockItems()
    {
        return context.Inventories
            .Where(i => i.IsLowStock())
            .ToList();
    }

    public List<Inventory> GetExpiringItems()
    {
        return context.Inventories
            .Where(i => i.IsExpiringSoon())
            .ToList();
    }
}
