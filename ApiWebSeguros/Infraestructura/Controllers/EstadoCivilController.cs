using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiWebSeguros.Data;
using ApiWebSeguros.Dominio;
using ApiWebSeguros.Dominio.Entidades.DTOs; // Importamos el DTO
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiWebSeguros.Infraestructura
{
    [ApiController]
    [Route("api/[controller]")]
    public class EstadoCivilController : ControllerBase
    {
        private DataContext _context;
        public EstadoCivilController(DataContext context)
        {
            _context = context;
        }

        // Crear un nuevo EstadoCivil
        [HttpPost]
        public async Task<ActionResult> PostEstadoCivil(EstadoCivil estadoCivil)
        {
            var nuevoEstadoCivil = new EstadoCivil
            {
                descripcion = estadoCivil.descripcion
            };

            _context.EstadosCiviles.Add(nuevoEstadoCivil);
            await _context.SaveChangesAsync();

            return Ok();
        }

        // Obtener todos los EstadoCiviles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EstadoCivilDto>>> GetEstadoCivils()
        {
            var estadosCiviles = await _context.EstadosCiviles
                .Select(e => new EstadoCivilDto { Descripcion = e.descripcion })
                .ToListAsync();

            return Ok(estadosCiviles);
        }

        // Obtener un EstadoCivil por ID
        [HttpGet("{id}")]
        public async Task<ActionResult<EstadoCivilDto>> GetEstadoCivil(int id)
        {
            var estadoCivil = await _context.EstadosCiviles
                .Where(e => e.id == id)
                .Select(e => new EstadoCivilDto { Descripcion = e.descripcion })
                .FirstOrDefaultAsync();

            if (estadoCivil == null)
            {
                return NotFound();
            }

            return Ok(estadoCivil);
        }

        // Actualizar un EstadoCivil
        [HttpPut("{id}")]
        public async Task<ActionResult> PutEstadoCivil(int id, EstadoCivil estadoCivilPut)
        {
            var estadoCivilAModificar = await _context.EstadosCiviles
                .FirstOrDefaultAsync(e => e.id == id);

            if (estadoCivilAModificar == null)
            {
                return NotFound();
            }

            estadoCivilAModificar.descripcion = estadoCivilPut.descripcion;

            await _context.SaveChangesAsync();
            return Ok();
        }

        // Eliminar un EstadoCivil
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEstadoCivil(int id)
        {
            var estadoCivilAEliminar = await _context.EstadosCiviles
                .FirstOrDefaultAsync(e => e.id == id);

            if (estadoCivilAEliminar == null)
            {
                return NotFound();
            }

            _context.EstadosCiviles.Remove(estadoCivilAEliminar);
            await _context.SaveChangesAsync();
            return Ok(estadoCivilAEliminar);
        }
    }
}
