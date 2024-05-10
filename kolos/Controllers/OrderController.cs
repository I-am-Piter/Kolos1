using GakkoHorizontalSlice.Services;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class OrderController:ControllerBase
{
    private IOrderService _orderService;
    
    public OrderController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpGet("{id:int}")]
    public IActionResult GetOrder(int id)
    {
        var order = _orderService.GetOrder(id);

        if (order==null)
        {
            return NotFound("order not found");
        }
        
        return Ok(order);
    }
}