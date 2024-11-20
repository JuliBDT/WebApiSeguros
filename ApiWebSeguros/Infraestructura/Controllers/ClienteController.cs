using AutoMapper;
using ApiWebSeguros.Dominio.Entidades.DTOs; 
using ApiWebSeguros.Dominio;
using ApiWebSeguros.Persistencia.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiWebSeguros.Infraestructura.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteRepository _clienteRepository; // Crea la interfaz de repositorio para Cliente.
        private readonly IMapper _mapper;

        public ClienteController(IClienteRepository clienteRepository, IMapper mapper)
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var clientes = await _clienteRepository.GetAllAsync();
            var clientesDto = _mapper.Map<List<ClienteToListDto>>(clientes);
            return Ok(clientesDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var cliente = await _clienteRepository.GetByIdAsync(id);
            if (cliente == null)
                return NotFound("Cliente no encontrado");
            
            var clienteDto = _mapper.Map<ClienteToListDto>(cliente);
            return Ok(clienteDto);
        }

        [HttpPost]
        public async Task<IActionResult> Post(ClienteToCreateDto clienteToCreateDto)
        {
            var clienteToCreate = _mapper.Map<Cliente>(clienteToCreateDto);
            clienteToCreate.fechaModificacion = DateTime.Now;

            var clienteCreated = await _clienteRepository.AddAsync(clienteToCreate);
            var clienteCreatedDto = _mapper.Map<ClienteToListDto>(clienteCreated);

            return Ok(clienteCreatedDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, ClienteToUpdateDto clienteToUpdateDto)
        {
            if (id != clienteToUpdateDto.cliente)
                return BadRequest("Error en los datos de entrada");

            var clienteToUpdate = await _clienteRepository.GetByIdAsync(id);
            if (clienteToUpdate == null)
                return NotFound("Cliente no encontrado");

            _mapper.Map(clienteToUpdateDto, clienteToUpdate);
            clienteToUpdate.fechaModificacion = DateTime.Now;

            var updated = await _clienteRepository.UpdateAsync(id, clienteToUpdate);

            if (!updated)
                return NoContent();

            var cliente = await _clienteRepository.GetByIdAsync(id);
            var clienteDto = _mapper.Map<ClienteToListDto>(cliente);

            return Ok(clienteDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var clienteToDelete = await _clienteRepository.GetByIdAsync(id);

            if (clienteToDelete == null)
                return NotFound("Cliente no encontrado");

            var deleted = await _clienteRepository.DeleteAsync(clienteToDelete);

            if (!deleted)
                return Ok("No se pudo borrar el cliente. Consulta el log para más detalles.");

            return Ok("Cliente borrado correctamente");
        }
    }
}
