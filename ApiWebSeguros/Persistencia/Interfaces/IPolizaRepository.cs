using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiWebSeguros.Dominio;

namespace ApiWebSeguros.Persistencia.Interfaces
{
    public interface IPolizaRepository
    {
    Task<List<Poliza>> GetAllAsync();
    Task<Poliza> GetByIdAsync(int ramo, int producto, int poliza);
    Task<Poliza> AddAsync(Poliza poliza);
    Task<bool> UpdateAsync(Poliza poliza);
    Task<bool> DeleteAsync(Poliza poliza);
    }

}