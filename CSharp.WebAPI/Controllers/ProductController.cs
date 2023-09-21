using Microsoft.AspNetCore.Mvc;
using FSharpSql.Services.CSharpInterop;

namespace CSharp.WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    private readonly string _connectionString;

    public ProductController(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection");
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        var maybeProduct = await Product.getByIdAsync(_connectionString, id);

        if (maybeProduct.IsSome())
        {
            return Ok(maybeProduct.Value);
        }

        return NotFound();
    }
}
