using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiWebSeguros.Dominio;

namespace ApiWebSeguros.Persistencia.Interfaces
{
    public interface ITipoRolesRepository
    {
        Task<List<TipoRoles>> GetAllAsync();
        Task<TipoRoles> GetByIdAsync(int rol);
        Task<TipoRoles> AddAsync(TipoRoles tipoRoles);
        Task<bool> UpdateAsync(int rolId, TipoRoles tipoRolesToUpdate);
        Task<bool> DeleteAsync(TipoRoles tipoRolesToDelete);
    }
}