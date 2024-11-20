using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiWebSeguros.Dominio;

namespace ApiWebSeguros.Persistencia.Interfaces
{
    public interface IRamoRepository
    {
        Task<List<Ramo>> GetAllAsync();
        Task<Ramo> GetByIdAsync(int ramo);
        Task<Ramo> AddAsync(Ramo ramo);
        Task<bool> UpdateAsync(int ramoId, Ramo ramoToUpdate);
        Task<bool> DeleteAsync(Ramo ramoToDelete);
    }
}