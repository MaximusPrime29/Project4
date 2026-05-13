using System;

public class Inventory
{
	public int InventoryId { get; set; }
    public int ProductId { get; set; }
	public int StoreId { get; set; }
	public int Quantity { get; set; }
    public int MinimumQuantity { get; set; }
    public DateTime ExpiryDate { get; set; }

    public Inventory(int inventoryId, int productId, int storeId, int quantity, int minQuantity, DateTime expiryDate)
	{
		InventoryId = inventoryId;
		ProductId = productId;
		StoreId = storeId;
		Quantity = quantity;
        MinimumQuantity = minQuantity;
        ExpiryDate = expiryDate;
    }
    public bool IsExpiringSoon()
    {
        return ExpiryDate <= DateTime.Now.AddDays(3);
    }


    public bool IsLowStock()
    {
        return Quantity <= MinimumQuantity;
    }
}
