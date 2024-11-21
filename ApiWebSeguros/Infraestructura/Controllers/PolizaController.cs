using ApiWebSeguros.Dominio.Entidades.DTOs;
using ApiWebSeguros.Dominio;
using ApiWebSeguros.Persistencia.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiWebSeguros.Infraestructura.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PolizaController : ControllerBase
    {
        private readonly IPolizaRepository _polizaRepository; // Crea la interfaz del repositorio para Poliza.

        public PolizaController(IPolizaRepository polizaRepository )
        {
            _polizaRepository = polizaRepository;
          
        }

    }
}
