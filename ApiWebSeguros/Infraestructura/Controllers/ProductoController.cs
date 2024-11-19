
using ApiWebSeguros.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiWebSeguros.Infraestructura
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductoController : ControllerBase
    {
        private DataContext _context;
        public ProductoController(DataContext context)
        {
            _context = context;
        }

        
    }
}