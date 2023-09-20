using Microsoft.AspNetCore.Mvc;

namespace CSharp.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderController : ControllerBase
{
    private readonly string _connectionString;

    public OrderController(IConfiguration configuration)
    {
        // init connection string
        _connectionString = configuration.GetConnectionString("DefaultConnection");
    }

    [HttpGet("{id:int}")]
    public IActionResult GetById(int id)
    {
        var maybeOrder = FSharpSql.Services.Orders.getById(_connectionString, id);
        if (maybeOrder.IsSome())
        {
            return Ok(maybeOrder.Value);
        }

        return NotFound();
    }

    [HttpGet("customer/{customerId}")]
    public IActionResult GetForCustomer(string customerId)
    {
        var orders = FSharpSql.Services.Orders.getForCustomer(_connectionString, customerId);
        return Ok(orders);
    }
}
