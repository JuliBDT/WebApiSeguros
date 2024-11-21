using ApiWebSeguros.Dominio.Entidades.DTOs; // Asegúrate de crear los DTOs para Poliza.
using ApiWebSeguros.Dominio;
using ApiWebSeguros.Persistencia.Interfaces;
using Microsoft.AspNetCore.Mvc;
using ApiWebSeguros.Data;

namespace ApiWebSeguros.Infraestructura.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RamoController : ControllerBase
    {
        private readonly DataContext _context;

        public RamoController(DataContext ramoRepository)
        {
            _context = ramoRepository;
        }


    }
}