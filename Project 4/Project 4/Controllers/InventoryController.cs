using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/inventory")]
public class InventoryController : ControllerBase
{
    private readonly InventoryService inventoryService;

    public InventoryController(InventoryService inventoryService)
    {
        this.inventoryService = inventoryService;
    }

    [HttpGet("products")]
    public IActionResult GetProducts()
    {
        return Ok(inventoryService.GetProducts());
    }

    [HttpGet("store/{storeId}")]
    public IActionResult GetInventoryByStore(int storeId)
    {
        return Ok(inventoryService.GetInventoryByStore(storeId));
    }

    [HttpGet("low-stock")]
    public IActionResult GetLowStockItems()
    {
        return Ok(inventoryService.GetLowStockItems());
    }

    [HttpPut("update/{inventoryId}")]
    public IActionResult UpdateQuantity(int inventoryId, int newQuantity)
    {
        inventoryService.UpdateQuantity(inventoryId, newQuantity);
        return Ok("Quantity updated");
    }
    [HttpGet("expiring")]
    public IActionResult GetExpiringItems()
    {
        return Ok(inventoryService.GetExpiringItems());
    }
}
