using System;

public class Transfer
{
    public int TransferId { get; set; }

    public int FromStoreId { get; set; }

    public int ToStoreId { get; set; }

    public int ProductId { get; set; }

    public int Quantity { get; set; }

    public DateTime TransferDate { get; set; }

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