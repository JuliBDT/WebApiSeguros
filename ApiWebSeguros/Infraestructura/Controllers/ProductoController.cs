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
        //private readonly IMapper _mapper;
        public ProductoController(DataContext context )
        {
            _context = context;
       
        }

        // [HttpPost]
        // public async Task<ActionResult> PostProducto(ProductoCreateDTO productoPost)
        // {
        //     var nuevoProducto = _mapper.Map<Producto>(productoPost);
        //     nuevoProducto.fechaComputo = DateTime.Now;

        //     _context.Productos.Add(nuevoProducto);
        //     await _context.SaveChangesAsync();

        //     return Ok();
        // }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Producto>>> GetProductos()
        {
            var productos = await _context.Productos.ToListAsync();
           // var ProductoDtos = _mapper.Map<List<ProductoDto>>(productos);
            return Ok(productos);
        }

        [HttpGet("{idRamo}/{idProducto}")]
        public async Task<ActionResult<Producto>> GetProducto(int idRamo, int idProducto)
        {
            var producto = await _context.Productos
                .FirstOrDefaultAsync(p => p.RAMO == idRamo && p.PRODUCTO == idProducto);

            if (producto == null)
            {
                return NotFound();
            }
            //var ProductoDto = _mapper.Map<ProductoDto>(producto);
            return Ok(producto);
        }

        // [HttpPut("{idRamo}/{idProducto}")]
        // public async Task<ActionResult> PutProducto(int idRamo, int idProducto, ProductoUpdateDTO producto)
        // {
        //     var productoAModificar = await _context.Productos
        //         .FirstOrDefaultAsync(p => p.ramo == idRamo && p.producto == idProducto);

        //     if (productoAModificar == null)
        //     {
        //         return NotFound();
        //     }

        //     _mapper.Map(producto, productoAModificar);
        //     await _context.SaveChangesAsync();

        //     return Ok();
        // }

        
        // [HttpDelete("{idRamo}/{idProducto}")]
        // public async Task<ActionResult> DeleteProducto(int idRamo, int idProducto)
        // {
        //     var producto = await _context.Productos
        //         .FirstOrDefaultAsync(p => p.ramo == idRamo && p.producto == idProducto);

        //     if (producto == null)
        //     {
        //         return NotFound();
        //     }

        //     _context.Productos.Remove(producto);
        //     await _context.SaveChangesAsync();

        //     var ProductoDto = _mapper.Map<ProductoDto>(producto);

        //     return Ok(ProductoDto);
        // }
    }
}
