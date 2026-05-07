using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class TransferController : ControllerBase
{
    [HttpPost]
    public IActionResult TransferStock([FromBody] TransferRequest request)
    {
        // Check if the quantity is valid
        if (request.Quantity <= 0)
        {
            return BadRequest("Quantity must be greater than zero.");
        }

        // Prevent transferring stock to the same store
        if (request.FromStoreId == request.ToStoreId)
        {
            return BadRequest("Source and destination store cannot be the same.");
        }

        

        return Ok("Transfer request is valid.");
    }
}