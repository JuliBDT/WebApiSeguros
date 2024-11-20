using ApiWebSeguros.Data;
using ApiWebSeguros.Dominio;
using ApiWebSeguros.Dominio.Entidades.DTOs; // Importamos el DTO
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ApiWebSeguros.Infraestructura.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RolController : ControllerBase
    {
        private DataContext _context;

        public RolController(DataContext context)
        {
            _context = context;
        }

        // Crear un nuevo Rol
        [HttpPost]
        public async Task<ActionResult> PostRol(Rol rolPost)
        {
            var nuevoRol = new Rol
            {
                ramo = rolPost.ramo,
                producto = rolPost.producto,
                poliza = rolPost.poliza,
                rol = rolPost.rol,
                cliente = rolPost.cliente,
                fechaEfecto = rolPost.fechaEfecto,
                nulldate = rolPost.nulldate
            };

            _context.Roles.Add(nuevoRol);
            await _context.SaveChangesAsync();

            return Ok();
        }

        // Obtener todos los Rols
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RolDto>>> GetRols()
        {
            var roles = await _context.Roles
                .Select(r => new RolDto
                {
                    Rol = r.rol,
                    Cliente = r.cliente,
                    FechaEfecto = r.fechaEfecto
                })
                .ToListAsync();

            return Ok(roles);
        }

        // Obtener un Rol por Ramo, Producto y Poliza
        [HttpGet("{idRamo}/{idProducto}/{idPoliza}")]
        public async Task<ActionResult<RolDto>> GetRol(int idRamo, int idProducto, int idPoliza)
        {
            var rol = await _context.Roles
                .Where(r => r.ramo == idRamo && r.producto == idProducto && r.poliza == idPoliza)
                .Select(r => new RolDto
                {
                    Rol = r.rol,
                    Cliente = r.cliente,
                    FechaEfecto = r.fechaEfecto
                })
                .FirstOrDefaultAsync();

            if (rol == null)
            {
                return NotFound();
            }

            return Ok(rol);
        }

        // Actualizar un Rol
        [HttpPut("{idRamo}/{idProducto}/{idPoliza}")]
        public async Task<ActionResult> PutRol(int idRamo, int idProducto, int idPoliza, Rol rolPost)
        {
            var rolAModificar = await _context.Roles
                .FirstOrDefaultAsync(r => r.ramo == idRamo && r.producto == idProducto && r.poliza == idPoliza);

            if (rolAModificar == null)
            {
                return NotFound();
            }

            rolAModificar.rol = rolPost.rol;
            rolAModificar.cliente = rolPost.cliente;
            rolAModificar.fechaEfecto = rolPost.fechaEfecto;
            rolAModificar.nulldate = rolPost.nulldate;

            await _context.SaveChangesAsync();
            return Ok();
        }

        // Eliminar un Rol
        [HttpDelete("{idRamo}/{idProducto}/{idPoliza}")]
        public async Task<ActionResult> DeleteRol(int idRamo, int idProducto, int idPoliza)
        {
            var rolAEliminar = await _context.Roles
                .FirstOrDefaultAsync(r => r.ramo == idRamo && r.producto == idProducto && r.poliza == idPoliza);

            if (rolAEliminar == null)
            {
                return NotFound();
            }

            _context.Roles.Remove(rolAEliminar);
            await _context.SaveChangesAsync();
            return Ok(rolAEliminar);
        }
    }
}
