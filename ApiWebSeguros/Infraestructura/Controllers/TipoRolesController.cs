using AutoMapper;
using ApiWebSeguros.Dominio.Entidades.DTOs;
using ApiWebSeguros.Dominio;
using ApiWebSeguros.Persistencia.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiWebSeguros.Infraestructura.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TipoRolesController : ControllerBase
    {
        private readonly ITipoRolesRepository _tipoRolesRepository;
        private readonly IMapper _mapper;

        public TipoRolesController(ITipoRolesRepository tipoRolesRepository, IMapper mapper)
        {
            _tipoRolesRepository = tipoRolesRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tipoRoles = await _tipoRolesRepository.GetAllAsync();
            var tipoRolesDto = _mapper.Map<List<TipoRolesDto>>(tipoRoles);
            return Ok(tipoRolesDto);
        }

        [HttpGet("{rol}")]
        public async Task<IActionResult> GetById(int rol)
        {
            var tipoRol = await _tipoRolesRepository.GetByIdAsync(rol);
            if (tipoRol == null) return NotFound("Rol no encontrado.");
            
            var tipoRolDto = _mapper.Map<TipoRolesDto>(tipoRol);
            return Ok(tipoRolDto);
        }

        [HttpPost]
        public async Task<IActionResult> Post(TipoRolesToCreateDto tipoRolesToCreateDto)
        {
            var tipoRolesToCreate = _mapper.Map<TipoRoles>(tipoRolesToCreateDto);
            tipoRolesToCreate.fechaComputo = DateTime.Now;

            var tipoRolesCreated = await _tipoRolesRepository.AddAsync(tipoRolesToCreate);
            var tipoRolesCreatedDto = _mapper.Map<TipoRolesDto>(tipoRolesCreated);

            return Ok(tipoRolesCreatedDto);
        }

        [HttpPut("{rolId}")]
        public async Task<IActionResult> Put(int rolId, TipoRolesToUpdateDto tipoRolesToUpdateDto)
        {
            if (rolId != tipoRolesToUpdateDto.rol)
                return BadRequest("Error en los datos de entrada.");

            var tipoRolesToUpdate = await _tipoRolesRepository.GetByIdAsync(rolId);
            if (tipoRolesToUpdate == null) return NotFound("Rol no encontrado.");

            _mapper.Map(tipoRolesToUpdateDto, tipoRolesToUpdate);
            var updated = await _tipoRolesRepository.UpdateAsync(rolId, tipoRolesToUpdate);

            if (!updated) return NoContent();

            var tipoRolesUpdated = await _tipoRolesRepository.GetByIdAsync(rolId);
            var tipoRolesDto = _mapper.Map<TipoRolesDto>(tipoRolesUpdated);
            return Ok(tipoRolesDto);
        }

        [HttpDelete("{rolId}")]
        public async Task<IActionResult> Delete(int rolId)
        {
            var tipoRolesToDelete = await _tipoRolesRepository.GetByIdAsync(rolId);
            if (tipoRolesToDelete == null) return NotFound("Rol no encontrado.");

            var deleted = await _tipoRolesRepository.DeleteAsync(tipoRolesToDelete);
            if (!deleted) return BadRequest("Error al eliminar el rol.");

            return Ok("Rol eliminado correctamente.");
        }
    }
}