using AutoMapper;
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
        private readonly IMapper _mapper;

        public PolizaController(IPolizaRepository polizaRepository, IMapper mapper)
        {
            _polizaRepository = polizaRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var polizas = await _polizaRepository.GetAllAsync();
            var polizasDto = _mapper.Map<List<PolizaToListDto>>(polizas);
            return Ok(polizasDto);
        }

        [HttpGet("{ramo}/{producto}/{poliza}")]
        public async Task<IActionResult> GetById(int ramo, int producto, int poliza)
        {
            var polizaEntity = await _polizaRepository.GetByIdAsync(ramo, producto, poliza);
            if (polizaEntity == null)
                return NotFound("Póliza no encontrada");
            
            var polizaDto = _mapper.Map<PolizaToListDto>(polizaEntity);
            return Ok(polizaDto);
        }

        [HttpPost]
        public async Task<IActionResult> Post(PolizaToCreateDto polizaToCreateDto)
        {
            var polizaToCreate = _mapper.Map<Poliza>(polizaToCreateDto);
            var polizaCreated = await _polizaRepository.AddAsync(polizaToCreate);

            var polizaCreatedDto = _mapper.Map<PolizaToListDto>(polizaCreated);
            return Ok(polizaCreatedDto);
        }

        [HttpPut("{ramo}/{producto}/{poliza}")]
        public async Task<IActionResult> Put(int ramo, int producto, int poliza, PolizaToUpdateDto polizaToUpdateDto)
        {
            if (ramo != polizaToUpdateDto.ramo || producto != polizaToUpdateDto.producto || poliza != polizaToUpdateDto.poliza)
                return BadRequest("Error en los datos de entrada");

            var polizaToUpdate = await _polizaRepository.GetByIdAsync(ramo, producto, poliza);
            if (polizaToUpdate == null)
                return NotFound("Póliza no encontrada");

            _mapper.Map(polizaToUpdateDto, polizaToUpdate);
            var updated = await _polizaRepository.UpdateAsync(polizaToUpdate);

            if (!updated)
                return NoContent();

            var polizaEntity = await _polizaRepository.GetByIdAsync(ramo, producto, poliza);
            var polizaDto = _mapper.Map<PolizaToListDto>(polizaEntity);

            return Ok(polizaDto);
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
