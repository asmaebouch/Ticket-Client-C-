using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TicketClient.NewFolder;

namespace TicketClient.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : Controller
    {
        private readonly DataContext _context;

        public ClientController(DataContext context
   )
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<List<Client>>> GetClient()
        {

            return Ok(await _context.Clients.ToListAsync());

        }
         [HttpPost]
         public async Task<ActionResult<List<Client>>> CreateClient(Client client)
         {
             _context.Clients.Add(client);
             await _context.SaveChangesAsync();
             return Ok(await _context
                 .Clients.ToListAsync());
         }
         [HttpPut]
         public async Task<ActionResult<List<Client>>> UpdateClient(Client client)
         {
             var dbClient = await _context.Clients.FindAsync(client.Id);
             if (dbClient == null)
                 return BadRequest("Client n'existe pas");
             dbClient.nom=client.nom;
             dbClient.prenom=client.prenom;
             dbClient.email = client.email;
             dbClient.age = client.age;
             dbClient.mdp = client.mdp;
             await _context.SaveChangesAsync();
             return Ok(await _context.Clients.ToListAsync());
         }
         [HttpDelete("{id}")]
         public async Task<ActionResult<List<Client>>> DeleteClient(int id)
         {
             var dbClient = await _context.Clients.FindAsync(id);
             if(dbClient == null)
                 return BadRequest("Client n'existe pas");
             _context.Clients.Remove(dbClient);
             await _context.SaveChangesAsync();
             return Ok(await _context.Clients.ToListAsync());

         }

     }
    }

