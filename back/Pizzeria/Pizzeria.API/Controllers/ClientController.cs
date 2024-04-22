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
    public class ClientController : ControllerBase
    {
        private readonly PizzeriaDbContext _context;

        public ClientController(PizzeriaDbContext context)
        {
            _context = context;
        }
        

      [HttpGet]
      public async Task<ActionResult<IEnumerable<Client>>> GetClient()
      {
        return await _context.Client.ToListAsync();
      }

        [HttpGet("name/{clientFirstName}", Name = "GetClientByClientName")]
        public async Task<IActionResult> GetClientByClientName(string clientFirstName)
        {
            var client = await _context.Client.FirstOrDefaultAsync(x => x.ClientFirstName == clientFirstName);

            if (client != null)
            {
                return Ok(new ClientViewModel
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

            return NotFound();
        }


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



    }
}
