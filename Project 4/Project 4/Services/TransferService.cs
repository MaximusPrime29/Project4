using System.Collections.Generic;
using System.Linq;


// Handles stock transfer validation and transfer processing
public class TransferService
{

    // Temporary in-memory inventory list used for prototype testing.
    // Later this should be replaced by shared inventory data from InventoryService or a database.
    private List<Inventory> inventories = new List<Inventory>();


    // Temporary in-memory transfer history used for prototype testing.
    // Later this should be stored in the database.
    private List<Transfer> transfers = new List<Transfer>();

    public TransferService()
    {

        // Temporary sample inventory data used to test transfer logic.
        // Parameters: inventoryId, productId, storeId, quantity, minimumQuantity, expiryDate


        inventories.Add(new Inventory(1, 1, 1, 50, 10,
            DateTime.Now.AddDays(7)));

        inventories.Add(new Inventory(2, 1, 2, 20, 10,
            DateTime.Now.AddDays(7)));
    }

    // Processes a stock transfer request and returns a success or error message
    public string TransferStock(TransferRequest request)
    {

        // Prevent zero or negative transfer quantities
        if (request.Quantity <= 0)
        {
            return "Quantity must be greater than zero.";
        }


        // Prevent transferring stock to the same store
        if (request.FromStoreId == request.ToStoreId)
        {
            return "Source and destination store cannot be the same.";
        }


        // Find the inventory record for the source store and product
        Inventory sourceInventory = inventories.FirstOrDefault(i =>
            i.StoreID == request.FromStoreId &&
            i.ProductId == request.ProductId);

        // Find the inventory record for the destination store and product
        Inventory destinationInventory = inventories.FirstOrDefault(i =>
            i.StoreID == request.ToStoreId &&
            i.ProductId == request.ProductId);

        // Transfer cannot continue if the source inventory does not exist
        if (sourceInventory == null)
        {
            return "Source inventory not found.";
        }

        // Transfer cannot continue if the source store does not have enough stock
        if (sourceInventory.Quantity < request.Quantity)
        {
            return "Not enough stock available.";
        }

        // Remove stock from the source store
        sourceInventory.Quantity -= request.Quantity;

        // Add stock to the destination store if an inventory record exists
        if (destinationInventory != null)
        {
            destinationInventory.Quantity += request.Quantity;
        }

        // Create a transfer record for transfer history
        Transfer transfer = new Transfer(
            transfers.Count + 1,
            request.FromStoreId,
            request.ToStoreId,
            request.ProductId,
            request.Quantity
        );

        // Store transfer record in temporary transfer history
        transfers.Add(transfer);

        return "Transfer successful.";
    }
}