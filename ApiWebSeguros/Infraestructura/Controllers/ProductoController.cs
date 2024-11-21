using ApiWebSeguros.Data;
using ApiWebSeguros.Dominio;
using ApiWebSeguros.Dominio.Entidades.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiWebSeguros.Infraestructura
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductoController : ControllerBase
    {
        private readonly DataContext _context;
     
        public ProductoController(DataContext context )
        {
            _context = context;
       
        }

    
    }
}
