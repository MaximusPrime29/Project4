using System.Collections.Generic;
using System.Linq;

public class TransferService
{
    private List<Inventory> inventories = new List<Inventory>();

    private List<Transfer> transfers = new List<Transfer>();

    public TransferService()
    {
        // Temporary test data

        inventories.Add(new Inventory(1, 1, 1, 50, 10,
            DateTime.Now.AddDays(7)));

        inventories.Add(new Inventory(2, 1, 2, 20, 10,
            DateTime.Now.AddDays(7)));
    }

    public string TransferStock(TransferRequest request)
    {
        if (request.Quantity <= 0)
        {
            return "Quantity must be greater than zero.";
        }

        if (request.FromStoreId == request.ToStoreId)
        {
            return "Source and destination store cannot be the same.";
        }

        Inventory sourceInventory = inventories.FirstOrDefault(i =>
            i.StoreID == request.FromStoreId &&
            i.ProductId == request.ProductId);

        Inventory destinationInventory = inventories.FirstOrDefault(i =>
            i.StoreID == request.ToStoreId &&
            i.ProductId == request.ProductId);

        if (sourceInventory == null)
        {
            return "Source inventory not found.";
        }

        if (sourceInventory.Quantity < request.Quantity)
        {
            return "Not enough stock available.";
        }

        sourceInventory.Quantity -= request.Quantity;

        if (destinationInventory != null)
        {
            destinationInventory.Quantity += request.Quantity;
        }

        Transfer transfer = new Transfer(
            transfers.Count + 1,
            request.FromStoreId,
            request.ToStoreId,
            request.ProductId,
            request.Quantity
        );

        transfers.Add(transfer);

        return "Transfer successful.";
    }
}