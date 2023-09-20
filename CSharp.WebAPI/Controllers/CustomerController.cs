using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult GetById(string id)
        {
            var maybeCustomer = FSharpSql.Services.Customer.getById(_connectionString, id);
            if (maybeCustomer.IsSome())
            {
                return Ok(maybeCustomer.Value);
            }

            return NotFound();
        }
    }
}
