using ApiWebSeguros.Dominio.Entidades.DTOs; 
using ApiWebSeguros.Dominio;
using ApiWebSeguros.Persistencia.Interfaces;
using Microsoft.AspNetCore.Mvc;
using ApiWebSeguros.Data;

namespace ApiWebSeguros.Infraestructura.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly DataContext _context;

        public ClienteController(DataContext clienteRepository)
        {
            _context = clienteRepository;
            
        }

    
    }
}
