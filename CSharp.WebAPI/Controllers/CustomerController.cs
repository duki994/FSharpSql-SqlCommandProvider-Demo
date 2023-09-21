using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FSharpSql.Services.CSharpInterop;

namespace CSharp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly string _connectionString;

        public CustomerController(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var maybeCustomer = await Customer.getByIdAsync(_connectionString, id);
            if (maybeCustomer.IsSome())
            {
                return Ok(maybeCustomer.Value);
            }

            return NotFound();
        }
    }
}
