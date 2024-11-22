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
            try
            {
                List<Poliza> polizas = _context.Polizas
                .AsNoTracking()
                .Where(p => p.CLIENTE_TITULAR == clienteId && p.RAMO == ramoId && p.PRODUCTO == productoId)
                .ToList();

                int suma = polizas.Sum(p => p.SUMA_ASEGURADA);

                return (suma + sumaPropuesta > 1000000) ? Ok(false) : Ok(true);
            } catch(Exception ex)
            {
                return StatusCode(500, new { mensaje = "Error al validar el monto asegurado.", detalle = ex.Message });
            }
            
        }

        [HttpGet("ValidarNullDate")]
        public ActionResult ValidarNullDate(int ramoId, int productoId, int polizaId)
        {
            try
            {
                bool retorno = true;
                Poliza? polizaBuscada = _context.Polizas
                .AsNoTracking().
                FirstOrDefault(p => p.POLIZA == polizaId && p.RAMO == ramoId && p.PRODUCTO == productoId);

                if (polizaBuscada == null || polizaBuscada.NULLDATE != null)
                {
                    retorno = false;
                }

                return Ok(retorno);
            } catch(Exception ex)
            {
                return StatusCode(500, new { mensaje = "Error al validar la vigencia de la póliza.", detalle = ex.Message });
            }
            
        }

        [HttpGet("ValidarCantPolizas")]
        public ActionResult ValidarCantPolizas(int ramoId, int productoId)
        {
            try
            {
                List<Poliza> polizas = _context.Polizas
                .AsNoTracking()
                .Where(p => p.RAMO == ramoId && p.PRODUCTO == productoId)
                .ToList();

                return (polizas.Count > 4) ? Ok(false) : Ok(true);
            }
            catch(Exception ex)
            {
                return StatusCode(500, new { mensaje = "Error al validar la cantidad de pólizas.", detalle = ex.Message });
            }
            
        }
    }
}
