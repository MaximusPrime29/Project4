using System;

public class Inventory
{
	public int InventoryId { get; set; }
	public Product Product { get; set; }
    public int productID { get; set; }
	public int StoreID { get; set; }
	public int Quantity { get; set; }
    public int MinimumQuantity { get; set; }
    public DateTime ExpiryDate { get; set; }

    public Inventory(int inventoryId, int productId, int storeID, int quantity, int minQuantity, DateTime expiryDate)
	{
		InventoryId = inventoryId;
		ProductId = productId;
		StoreID = storeID;
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
