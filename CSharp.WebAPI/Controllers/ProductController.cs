using Microsoft.AspNetCore.Mvc;

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
    public IActionResult GetById(int id)
    {
        // TODO: Use a simple DTO type instead of returning the F# type provider generated type directly.
        // FSharp.Data.SqlClient uses Design-Time Erased type providers, so we can't use System.Text.Json as it's
        // not supported. We can use Newtonsoft.Json, but we need to add a custom converter to handle
        // F# types (Unions etc.).
        var maybeProduct = FSharpSql.Services.Product.getById(_connectionString, id);

        if (maybeProduct.IsSome())
        {
            return Ok(maybeProduct.Value);
        }

        return NotFound();
    }
}
