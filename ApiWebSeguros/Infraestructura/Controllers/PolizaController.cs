using ApiWebSeguros.Dominio.Entidades.DTOs;
using ApiWebSeguros.Dominio;
using ApiWebSeguros.Persistencia.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiWebSeguros.Infraestructura.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PolizaController : ControllerBase
    {
        private readonly IPolizaRepository _polizaRepository; // Crea la interfaz del repositorio para Poliza.

        public PolizaController(IPolizaRepository polizaRepository )
        {
            _polizaRepository = polizaRepository;
          
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var polizas = await _polizaRepository.GetAllAsync();
            //var polizasDto = _mapper.Map<List<PolizaToListDto>>(polizas);
            return Ok(polizas);
        }

        [HttpGet("{ramo}/{producto}/{poliza}")]
        public async Task<IActionResult> GetById(int ramo, int producto, int poliza)
        {
            var polizaEntity = await _polizaRepository.GetByIdAsync(ramo, producto, poliza);
            if (polizaEntity == null)
                return NotFound("Póliza no encontrada");
            
          //  var polizaDto = _mapper.Map<PolizaToListDto>(polizaEntity);
            return Ok(polizaEntity);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Poliza polizaToCreate)
        {
            //var polizaToCreate = _mapper.Map<Poliza>(polizaToCreateDto);
            var polizaCreated = await _polizaRepository.AddAsync(polizaToCreate);

           // var polizaCreatedDto = _mapper.Map<PolizaToListDto>(polizaCreated);
            return Ok(polizaToCreate);
        }

        [HttpPut("{ramo}/{producto}/{poliza}")]
        public async Task<IActionResult> Put(int ramo, int producto, int poliza, Poliza polizaToUpdate)
        {
            if (ramo != polizaToUpdate.ramo || producto != polizaToUpdate.producto || poliza != polizaToUpdate.poliza)
                return BadRequest("Error en los datos de entrada");

            var polizaModificar = await _polizaRepository.GetByIdAsync(ramo, producto, poliza);
            if (polizaModificar == null)
                return NotFound("Póliza no encontrada");

            //_mapper.Map(polizaToUpdateDto, polizaToUpdate);
            var updated = await _polizaRepository.UpdateAsync(polizaToUpdate);

            if (!updated)
                return NoContent();

            var polizaEntity = await _polizaRepository.GetByIdAsync(ramo, producto, poliza);
           // var polizaDto = _mapper.Map<PolizaToListDto>(polizaEntity);

            return Ok(updated);
        }

        [HttpDelete("{ramo}/{producto}/{poliza}")]
        public async Task<IActionResult> Delete(int ramo, int producto, int poliza)
        {
            var polizaToDelete = await _polizaRepository.GetByIdAsync(ramo, producto, poliza);

            if (polizaToDelete == null)
                return NotFound("Póliza no encontrada");

            var deleted = await _polizaRepository.DeleteAsync(polizaToDelete);

            if (!deleted)
                return Ok("No se pudo borrar la póliza. Consulta el log para más detalles.");

            return Ok("Póliza borrada correctamente");
        }
    }
}
