
using ApiWebSeguros.Data;
using ApiWebSeguros.Dominio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


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
    
    [HttpPost]
    public async Task<ActionResult<Rol>> PostRol (Rol RolPost)
    {
        var nuevoRol = new Rol {
            ramo = RolPost.ramo,
            producto = RolPost.producto,
            poliza = RolPost.poliza, 
            rol = RolPost.rol, 
            cliente =RolPost.cliente,
            fechaEfecto = RolPost.fechaEfecto, 
            nulldate = RolPost.nulldate 
        };

        _context.Roles.Add(nuevoRol);
        await _context.SaveChangesAsync();

        return Ok();
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Rol>>> GetRols()
    {
        return await _context.Roles.ToListAsync();
    }

[HttpGet("{idRamo}/{idRol}/{idPoliza}")]
public async Task<ActionResult<Rol>> GetRol(int idRamo, int idProducto, int idPoliza)
{
    var rol = await _context.Roles
        .FirstOrDefaultAsync(r => r.ramo == idRamo && r.producto == idProducto && r.poliza == idPoliza);
    if (rol == null)
    {
        return NotFound();
    }
    return Ok(rol);
}

[HttpPut]
public async Task<ActionResult<Rol>> PutRol (int idRamo, int idProducto, int idPoliza, Rol rolPost)
{
     var rolAModificar = await _context.Roles
        .FirstOrDefaultAsync(r => r.ramo == idRamo && r.producto == idProducto && r.poliza == idPoliza);
    if (rolAModificar == null)
    {
        return NotFound();
    }

            rolAModificar.rol = rolPost.rol; 
            rolAModificar.cliente =rolPost.cliente;
            rolAModificar.fechaEfecto = rolPost.fechaEfecto; 
           rolAModificar.nulldate = rolPost.nulldate; 

    await _context.SaveChangesAsync();
    return Ok();

}

[HttpDelete]
public async Task<ActionResult<Rol>> DeleteRol(int idRamo, int idProducto, int idPoliza)
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