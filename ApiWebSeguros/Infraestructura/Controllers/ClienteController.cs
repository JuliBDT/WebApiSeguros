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
        //private readonly IMapper _mapper;

        public ClienteController(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
            //_mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var clientes = await _clienteRepository.GetAllAsync();
            //var clientesDto = _mapper.Map<List<ClienteToListDto>>(clientes);
            return Ok(clientes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var cliente = await _clienteRepository.GetByIdAsync(id);
            if (cliente == null)
                return NotFound("Cliente no encontrado");
            
           // var clienteDto = _mapper.Map<ClienteToListDto>(cliente);
            return Ok(cliente);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Cliente clienteToCreate)
        {
           // var clienteToCreate = _mapper.Map<Cliente>(clienteToCreateDto);
            clienteToCreate.fechaModificacion = DateTime.Now;

            await _clienteRepository.AddAsync(clienteToCreate);
           // var clienteCreatedDto = _mapper.Map<ClienteToListDto>(clienteCreated);

            return Ok(clienteToCreate);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, Cliente clienteToUpdate)
        {
            if (id != clienteToUpdate.cliente)
                return BadRequest("Error en los datos de entrada");

            var cliente = await _clienteRepository.GetByIdAsync(id);
            if (cliente == null)
                return NotFound("Cliente no encontrado");

            //_mapper.Map(clienteToUpdateDto, clienteToUpdate);
            clienteToUpdate.fechaModificacion = DateTime.Now;

            var updated = await _clienteRepository.UpdateAsync(id, clienteToUpdate);

            if (!updated)
                return NoContent();

         //   var cliente = await _clienteRepository.GetByIdAsync(id);
          //  var clienteDto = _mapper.Map<ClienteToListDto>(cliente);

            return Ok(updated);
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
