using ApiWebSeguros.Data;
using ApiWebSeguros.Dominio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiWebSeguros.Infraestructura
{
    [ApiController]
    [Route("api/[controller]")]
    public class WayPayController : ControllerBase
    {
   
            private DataContext _context;
        public  WayPayController(DataContext context)
        {
            _context = context;
        }    
    
    [HttpPost]
    public async Task<ActionResult<WayPay>> PostWayPay (WayPay wayPayPost)
    {
        var nuevoWayPay = new WayPay {
        waypay = wayPayPost.waypay,
        fechaComputo = DateTime.Now,
        descripcion = wayPayPost.descripcion, 
        estado = wayPayPost.estado,
        codUsuario = wayPayPost.codUsuario 
        };

        _context.WayPays.Add(nuevoWayPay);
        await _context.SaveChangesAsync();

        return Ok();
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<WayPay>>> GetWayPays()
    {
        return await _context.WayPays.ToListAsync();
    }

[HttpGet("{idRamo}/{idWayPay}/{idPoliza}")]
public async Task<ActionResult<WayPay>> GetWayPay(int id)
{
    var wayPayGet = await _context.WayPays
        .FirstOrDefaultAsync(w => w.waypay == id);
    if (wayPayGet == null)
    {
        return NotFound();
    }
    return Ok(wayPayGet);
}

[HttpPut]
public async Task<ActionResult<WayPay>> PutWayPay (int id, WayPay WayPayPost)
{
     var WayPayAModificar =await _context.WayPays
        .FirstOrDefaultAsync(w => w.waypay == id);
    if (WayPayAModificar == null)
    {
        return NotFound();
    }

            WayPayAModificar.waypay = WayPayPost.waypay; 
            WayPayAModificar.descripcion =WayPayPost.descripcion;
            WayPayAModificar.fechaComputo = WayPayPost.fechaComputo; 
           WayPayAModificar.codUsuario = WayPayPost.codUsuario; 

    await _context.SaveChangesAsync();
    return Ok();

}

[HttpDelete]
public async Task<ActionResult<WayPay>> DeleteWayPay(int id)
{
  var WayPayAEliminar =await _context.WayPays
        .FirstOrDefaultAsync(w => w.waypay == id);
    if (WayPayAEliminar == null)
    {
        return NotFound();
    }
     _context.WayPays.Remove(WayPayAEliminar);
     await _context.SaveChangesAsync();
    return Ok(WayPayAEliminar);
}
        
    }
}