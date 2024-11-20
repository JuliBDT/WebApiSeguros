
using ApiWebSeguros.Data;
using ApiWebSeguros.Dominio;
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


    [HttpPost]
    public async Task<ActionResult<Producto>> PostProducto (Producto productoPost)
    {
        var nuevoProducto = new Producto {
            ramo = productoPost.ramo,
            producto = productoPost.producto,
            fechaComputo = DateTime.Now,
            descripcion = productoPost.descripcion,
            estadoRegistro = productoPost.estadoRegistro,
            codUsuario = productoPost.codUsuario
        };

        _context.Productos.Add(nuevoProducto);
        await _context.SaveChangesAsync();

        return Ok();
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Producto>>> GetProductos()
    {
        return await _context.Productos.ToListAsync();
    }

[HttpGet("{idRamo}/{idProducto}")]
public async Task<ActionResult<Producto>> GetProducto(int idRamo, int idProducto)
{
    var producto = await _context.Productos
        .FirstOrDefaultAsync(p => p.ramo == idRamo && p.producto == idProducto);
    if (producto == null)
    {
        return NotFound();
    }
    return Ok(producto);
}

[HttpPut]
public async Task<ActionResult<Producto>> PutProducto (int idProducto, int idRamo, Producto producto)
{
     var productoAModificar = await _context.Productos
        .FirstOrDefaultAsync(p => p.ramo == idRamo && p.producto == idProducto);
    if (productoAModificar == null)
    {
        return NotFound();
    }

            productoAModificar.fechaComputo = producto.fechaComputo;
            productoAModificar.descripcion = producto.descripcion;
            productoAModificar.estadoRegistro = producto.estadoRegistro;
            productoAModificar.codUsuario = producto.codUsuario;

    await _context.SaveChangesAsync();
    return Ok();

}

[HttpDelete]
public async Task<ActionResult<Producto>> DeleteProducto(int idRamo, int idProducto)
{
    var producto = await _context.Productos
        .FirstOrDefaultAsync(p => p.ramo == idRamo && p.producto == idProducto);
    if (producto == null)
    {
        return NotFound();
    }
     _context.Productos.Remove(producto);
     await _context.SaveChangesAsync();
    return Ok(producto);
}

    }
}