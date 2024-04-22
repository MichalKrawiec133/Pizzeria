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

namespace Pizzeria.Controllers;


    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly PizzeriaDbContext _context;

        public LoginController(PizzeriaDbContext context)
        {
            _context = context;
        }
        
        
        
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Login login)
        {
            var user = _context.Client.SingleOrDefault(c => c.ClientEmail == login.clientEmail);
           
            if (user == null || user.ClientHash != login.clientHash)
            {
                
                return Unauthorized();
                
            }

            bool isAdmin = user.ClientRole== "Admin";
            string clientName = user.ClientFirstName;
            //Console.Write(clientName);
            return Ok(new {IsAdmin = isAdmin, ClientName = clientName});
        }
        
        

    }

