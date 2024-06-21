using LocadoraVeiculos.Data;
using LocadoraVeiculos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LocadoraVeiculos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservaController : Controller
    {
        private readonly ClienteContext _context;
        public ReservaController(ClienteContext context)
        {
            _context = context;
        }
        [HttpGet]
        [Route("/Reserva")]
        public async Task<ActionResult> GetReserva()
        {
            return Ok(await _context.Reservas.ToListAsync());
        }
        [HttpPost]
        [Route("/Reserva")]
        public async Task<ActionResult> CreateRerserva(Reserva reserva)
        {
            await _context.Reservas.AddAsync(reserva);
            await _context.SaveChangesAsync();

            return Ok(reserva);
        }

    }
}
