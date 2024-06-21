using LocadoraVeiculos.Data;
using LocadoraVeiculos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LocadoraVeiculos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly ClienteContext _context;

      public ClienteController(ClienteContext context)
      {
            _context = context;
      }
      [HttpGet]
      [Route("/Clientes")]
      public async Task<ActionResult> GetCliente() //Fazer com reserva e veiculos
      {
            return Ok(await _context.Clientes.ToListAsync());
      }
      [HttpPost]
      [Route("/Clientes")]
      public async Task<ActionResult> CreateCliente(Cliente cliente)
      {
          await _context.Clientes.AddAsync(cliente);
          await _context.SaveChangesAsync();
         
          return Ok(cliente);
      }
        [HttpPut]
        [Route("/Clientes")]
        public async Task<ActionResult> UpdateCliente(Cliente cliente)
        {
            var dbCliente = await _context.Clientes.FindAsync(cliente.Id);

            if (dbCliente == null)
                return NotFound();
            dbCliente.Nome = cliente.Nome;
            dbCliente.CPF = cliente.CPF;
            dbCliente.Endereco = cliente.Endereco;

            return Ok(cliente);
        }
        [HttpDelete]
        [Route("/Clientes")]
        public async Task<ActionResult> UpdateCliente(long Id)
        {
            var dbCliente = await _context.Clientes.FindAsync(Id);

            if (dbCliente == null)
                return NotFound();

            _context.Clientes.Remove(dbCliente);

            await _context.SaveChangesAsync();

            return NoContent();
        }





    }
}
