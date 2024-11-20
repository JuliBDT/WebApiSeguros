using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiWebSeguros.Dominio;

namespace ApiWebSeguros.Persistencia.Interfaces
{
    public interface IClienteRepository
    {
        Task<List<Cliente>> GetAllAsync();
        Task<Cliente> GetByIdAsync(string cliente);
        Task<Cliente> AddAsync(Cliente cliente);
        Task<bool> UpdateAsync(string id, Cliente cliente);
        Task<bool> DeleteAsync(Cliente cliente);
    }
}