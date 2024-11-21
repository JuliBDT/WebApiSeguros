using ApiWebSeguros.Dominio.Entidades.DTOs;
using ApiWebSeguros.Dominio;
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

        public PolizaController(DataContext polizaRepository)
        {
            _context = polizaRepository;

        }

        [HttpGet("ValidarMonto")]
        public ActionResult ValidarMonto(string clienteId, int ramoId, int productoId, int sumaPropuesta)
        {
            List<Poliza> polizas = _context.Polizas
            .AsNoTracking()
            .Where(p => p.CLIENTE_TITULAR == clienteId && p.RAMO == ramoId && p.PRODUCTO == productoId)
            .ToList();

            int suma = polizas.Sum(p => p.SUMA_ASEGURADA);

            return (suma + sumaPropuesta > 1000000) ? Ok(false) : Ok(true);
        }

        [HttpGet("ValidarNullDate")]
        public ActionResult ValidarNullDate(int ramoId, int productoId, int polizaId)
        {
            bool retorno = true;
            Poliza? polizaBuscada = _context.Polizas
           .AsNoTracking().
           FirstOrDefault(p => p.POLIZA == polizaId && p.RAMO == ramoId && p.PRODUCTO == productoId);

            if(polizaBuscada == null || polizaBuscada.NULLDATE != null)
            {
                retorno = false;
            }

            return Ok(retorno);
        }
    }
}
