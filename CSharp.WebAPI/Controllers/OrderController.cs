using Microsoft.AspNetCore.Mvc;
using FSharpSql.Services.CSharpInterop;

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
    public async Task<IActionResult> GetById(int id)
    {
        var maybeOrder = await Orders.getByIdAsync(_connectionString, id);
        if (maybeOrder.IsSome())
        {
            return Ok(maybeOrder.Value);
        }

        return NotFound();
    }

    [HttpGet("customer/{customerId}")]
    public async Task<IActionResult> GetForCustomer(string customerId)
    {
        var orders = await Orders.getForCustomerAsync(_connectionString, customerId);
        return Ok(orders);
    }
}
