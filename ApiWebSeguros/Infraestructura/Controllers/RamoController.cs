using AutoMapper;
using ApiWebSeguros.Dominio.Entidades.DTOs; // Asegúrate de crear los DTOs para Poliza.
using ApiWebSeguros.Dominio;
using ApiWebSeguros.Persistencia.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiWebSeguros.Infraestructura.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RamoController : ControllerBase
    {
        private readonly IRamoRepository _ramoRepository;
        private readonly IMapper _mapper;

        public RamoController(IRamoRepository ramoRepository, IMapper mapper)
        {
            _ramoRepository = ramoRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var ramos = await _ramoRepository.GetAllAsync();
            var ramosDto = _mapper.Map<List<RamoToListDto>>(ramos);
            return Ok(ramosDto);
        }

        [HttpGet("{ramo}")]
        public async Task<IActionResult> GetById(int ramo)
        {
            var ramoEntity = await _ramoRepository.GetByIdAsync(ramo);
            if (ramoEntity == null) return NotFound("Ramo no encontrado.");
            
            var ramoDto = _mapper.Map<RamoToListDto>(ramoEntity);
            return Ok(ramoDto);
        }

        [HttpPost]
        public async Task<IActionResult> Post(RamoToCreateDto ramoToCreateDto)
        {
            var ramoToCreate = _mapper.Map<Ramo>(ramoToCreateDto);
            ramoToCreate.fechaComputo = DateTime.Now;

            var ramoCreated = await _ramoRepository.AddAsync(ramoToCreate);
            var ramoCreatedDto = _mapper.Map<RamoToListDto>(ramoCreated);

            return Ok(ramoCreatedDto);
        }

        [HttpPut("{ramoId}")]
        public async Task<IActionResult> Put(int ramoId, RamoToUpdateDto ramoToUpdateDto)
        {
            if (ramoId != ramoToUpdateDto.ramo)
                return BadRequest("Error en los datos de entrada.");

            var ramoToUpdate = await _ramoRepository.GetByIdAsync(ramoId);
            if (ramoToUpdate == null) return NotFound("Ramo no encontrado.");

            _mapper.Map(ramoToUpdateDto, ramoToUpdate);
            var updated = await _ramoRepository.UpdateAsync(ramoId, ramoToUpdate);

            if (!updated) return NoContent();

            var ramoUpdated = await _ramoRepository.GetByIdAsync(ramoId);
            var ramoDto = _mapper.Map<RamoToListDto>(ramoUpdated);
            return Ok(ramoDto);
        }

        [HttpDelete("{ramoId}")]
        public async Task<IActionResult> Delete(int ramoId)
        {
            var ramoToDelete = await _ramoRepository.GetByIdAsync(ramoId);
            if (ramoToDelete == null) return NotFound("Ramo no encontrado.");

            var deleted = await _ramoRepository.DeleteAsync(ramoToDelete);
            if (!deleted) return BadRequest("Error al eliminar el ramo.");

            return Ok("Ramo eliminado correctamente.");
        }
    }
}