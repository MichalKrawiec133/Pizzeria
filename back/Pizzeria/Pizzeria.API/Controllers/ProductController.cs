using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pizzeria.Data.Sql;
using Pizzeria.Api.BindingModels;
using Pizzeria.Api.Validation;
using Pizzeria.Api.ViewModels;
using Pizzeria.Data.Sql;
using Pizzeria.Data.Sql.DAO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Pizzeria.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly PizzeriaDbContext _context;

        public ProductController(PizzeriaDbContext context)
        {
            _context = context;
        }

        
        
      [HttpGet]
      public async Task<ActionResult<IEnumerable<Product>>> GetProduct()
      {
        return await _context.Product.ToListAsync();
      }

      
      
      /*
        [ValidateModel]
//        [Consumes("application/x-www-form-urlencoded")]
//        [HttpPost("create", Name = "CreateClient")]
        public async Task<IActionResult> Post([FromBody] CreateClient createClient)
        {
            var client = new Client
            {
                ClientId = createClient.ClientId,
                ClientFirstName = createClient.ClientFirstName,
                ClientLastName = createClient.ClientLastName,
                ClientPesel = createClient.ClientPesel,
                ClientEmail = createClient.ClientEmail,
                ClientHash = createClient.ClientHash,
                ClientRole = createClient.ClientRole

            };
            await _context.AddAsync(client);
            await _context.SaveChangesAsync();

            return Created(client.ClientId.ToString(), new ClientViewModel
            {
                ClientId = client.ClientId,
                ClientFirstName = client.ClientFirstName,
                ClientLastName = client.ClientLastName,
                ClientPesel = client.ClientPesel,
                ClientEmail = client.ClientEmail,
                ClientHash = client.ClientHash,
                ClientRole = client.ClientRole
            });
        }

        [ValidateModel]
        [HttpPatch("edit/{ClientId:min(1)}", Name = "EditClient")]
//        public async Task<IActionResult> EditUser([FromBody] EditUser editUser,[FromQuery] int userId)
        public async Task<IActionResult> EditClient([FromBody] EditClient editClient, int clientId)
        {
            var client = await _context.Client.FirstOrDefaultAsync(x => x.ClientId == clientId);
            client.ClientFirstName = editClient.ClientFirstName;
            client.ClientLastName = editClient.ClientLastName;
            client.ClientPesel = editClient.ClientPesel;
            client.ClientEmail = editClient.ClientEmail;
            client.ClientHash = editClient.ClientHash;
            client.ClientRole = editClient.ClientRole;
            await _context.SaveChangesAsync();
            return NoContent();
            return Ok(new ClientViewModel
            {
                ClientFirstName = client.ClientFirstName,
                ClientLastName = client.ClientLastName,
                ClientPesel = client.ClientPesel
            });
        }

        [HttpDelete("{clientId}")]
        public async Task<IActionResult> DeleteClient(int clientId)
        {
            var clientToDelete = await _context.Client.FirstOrDefaultAsync(x => x.ClientId == clientId);

            

            _context.Client.Remove(clientToDelete);

            await _context.SaveChangesAsync();
            return NoContent();


        }

*/

    }
}

