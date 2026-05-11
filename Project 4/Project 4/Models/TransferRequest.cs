
using System;


// Represents data submitted when a user requests a stock transfer
public class TransferRequest
{

    // Store the stock is being transferred from
    public int FromStoreId { get; set; }


    // Store the stock is being transferred to
    public int ToStoreId { get; set; }


    // Product being transferred
    public int ProductId { get; set; }


    // Quantity of stock requested for transfer
    public int Quantity { get; set; }
}