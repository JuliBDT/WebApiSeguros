
using Microsoft.AspNetCore.Mvc;
using ApiWebSeguros.Data;
using Microsoft.EntityFrameworkCore;

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