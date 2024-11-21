using ApiWebSeguros.Dominio.Entidades.DTOs;
using ApiWebSeguros.Dominio;
using ApiWebSeguros.Persistencia.Interfaces;
using Microsoft.AspNetCore.Mvc;
using ApiWebSeguros.Data;
using Microsoft.EntityFrameworkCore;

namespace ApiWebSeguros.Infraestructura.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PolizaController : ControllerBase
    {
        private readonly DataContext _context; 

        public PolizaController(DataContext polizaRepository )
        {
            _context = polizaRepository;
          
        }

        [HttpGet]
        public async Task<IActionResult> GetPolizas()
        {
            var polizas = await _context.Polizas.ToListAsync();
            return Ok(polizas);
        }


    }
}
