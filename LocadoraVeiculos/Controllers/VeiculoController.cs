using LocadoraVeiculos.Data;
using LocadoraVeiculos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LocadoraVeiculos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VeiculoController : Controller
    {
        private readonly ClienteContext _context;
        public VeiculoController(ClienteContext context)
        {
            _context = context;
        }
        [HttpGet]
        [Route("/Veiculo")]
        public async Task<ActionResult> GetVeiculo() //Fazer com reserva e veiculos
        {
            return Ok(await _context.Veiculos.ToListAsync());
        }
        [HttpPost]
        [Route("/Veiculos")]
        public async Task<ActionResult> CreateVeiculo(Veiculo veiculo)
        {
            await _context.Veiculos.AddAsync(veiculo);
            await _context.SaveChangesAsync();

            return Ok(veiculo);
        }
        [HttpPut]
        [Route("/Veiculos")]
        public async Task<ActionResult> UpdateVeiculos(Veiculo veiculo)
        {
            var dbVeiculo = await _context.Veiculos.FindAsync(veiculo.Id);

            if (dbVeiculo == null)
                return NotFound();
    
            dbVeiculo.Marca = veiculo.Marca;
            dbVeiculo.Modelo = veiculo.Modelo;
            dbVeiculo.Ano = veiculo.Ano;
            dbVeiculo.Placa = veiculo.Placa;
            dbVeiculo.Cor = veiculo.Cor;

            return Ok(veiculo);
        }
    }
}
