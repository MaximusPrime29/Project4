using System;


// Represents a stock transfer between two stores
public class Transfer
{

    // Unique ID for the transfer record
    public int TransferId { get; set; }


    // Store where stock is being transferred from
    public int FromStoreId { get; set; }


    // Store where stock is being transferred to
    public int ToStoreId { get; set; }


    // Product being transferred
    public int ProductId { get; set; }


    // Amount of stock being transferred
    public int Quantity { get; set; }

    // Date and time the transfer was created
    public DateTime TransferDate { get; set; }

    // Constructor used to create a new transfer record
    public Transfer(int transferId, int fromStoreId, int toStoreId, int productId, int quantity)
    {
        TransferId = transferId;
        FromStoreId = fromStoreId;
        ToStoreId = toStoreId;
        ProductId = productId;
        Quantity = quantity;
        TransferDate = DateTime.Now;
    }
}