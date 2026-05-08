using System.Collections.Generic;
using System.Linq;

public class TransferService
{
    private readonly List<Inventory> _inventories;
    private readonly List<Transfer> _transfers;

    public TransferService(List<Inventory> inventories, List<Transfer> transfers)
    {
        _inventories = inventories;
        _transfers = transfers;
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

        Inventory sourceInventory = _inventories.FirstOrDefault(i =>
            i.StoreID == request.FromStoreId &&
            i.ProductId == request.ProductId);

        Inventory destinationInventory = _inventories.FirstOrDefault(i =>
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
            _transfers.Count + 1,
            request.FromStoreId,
            request.ToStoreId,
            request.ProductId,
            request.Quantity
        );

        _transfers.Add(transfer);

        return "Transfer successful.";
    }
}