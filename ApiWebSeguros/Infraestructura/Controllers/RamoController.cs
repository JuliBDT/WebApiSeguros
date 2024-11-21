using ApiWebSeguros.Dominio.Entidades.DTOs; // Asegúrate de crear los DTOs para Poliza.
using ApiWebSeguros.Dominio;
using ApiWebSeguros.Persistencia.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiWebSeguros.Infraestructura.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RamoController : ControllerBase
    {
        private readonly IRamoRepository _ramoRepository;

        public RamoController(IRamoRepository ramoRepository)
        {
            _ramoRepository = ramoRepository;
        }
    }
}