using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiWebSeguros.Data;
using ApiWebSeguros.Dominio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiWebSeguros.Infraestructura
{
    [ApiController]
    [Route("api/[controller]")]
    public class EstadoCivilController : ControllerBase
    {
   
            private DataContext _context;
        public  EstadoCivilController(DataContext context)
        {
            _context = context;
        }    
    
    [HttpPost]
    public async Task<ActionResult<EstadoCivil>> PostEstadoCivil (EstadoCivil estadoCivil)
    {
        var nuevoEstadoCivil = new EstadoCivil {
        
        descripcion = estadoCivil.descripcion, 
        id = estadoCivil.id 
        };

        _context.EstadosCiviles.Add(nuevoEstadoCivil);
        await _context.SaveChangesAsync();

        return Ok();
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<EstadoCivil>>> GetEstadoCivils()
    {
        return await _context.EstadosCiviles.ToListAsync();
    }

[HttpGet("{idRamo}")]
public async Task<ActionResult<EstadoCivil>> GetEstadoCivil(int id)
{
    var estadoCivilGet = await _context.EstadosCiviles
        .FirstOrDefaultAsync(e => e.id == id);
    if (estadoCivilGet == null)
    {
        return NotFound();
    }
    return Ok(estadoCivilGet);
}

[HttpPut]
public async Task<ActionResult<EstadoCivil>> PutEstadoCivil (int id, EstadoCivil estadoCivilPut)
{
     var estadoCivilAModificar =await _context.EstadosCiviles
        .FirstOrDefaultAsync(e => e.id == id);
    if (estadoCivilAModificar == null)
    {
        return NotFound();
    }

            estadoCivilAModificar.descripcion = estadoCivilPut.descripcion; 

    await _context.SaveChangesAsync();
    return Ok();

}

[HttpDelete]
public async Task<ActionResult<EstadoCivil>> DeleteEstadoCivil(int id)
{
  var EstadoCivilAEliminar =await _context.EstadosCiviles
        .FirstOrDefaultAsync(e => e.id == id);
    if (EstadoCivilAEliminar == null)
    {
        return NotFound();
    }
     _context.EstadosCiviles.Remove(EstadoCivilAEliminar);
     await _context.SaveChangesAsync();
    return Ok(EstadoCivilAEliminar);
}
        
    }
}