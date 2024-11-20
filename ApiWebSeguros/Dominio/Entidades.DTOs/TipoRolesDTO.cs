using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiWebSeguros.Dominio.Entidades.DTOs
{
    public class TipoRolesDto
    {
        public int rol { get; set; }
        public DateTime fechaComputo { get; set; }
        public string descripcion { get; set; } ="";
        public int estado { get; set; }
        public int codUsuario { get; set; }
    }

    public class TipoRolesToCreateDto
    {
        public string descripcion { get; set; } ="";
        public int estado { get; set; }
        public int codUsuario { get; set; }
    }

    public class TipoRolesToUpdateDto
    {
        public int rol { get; set; }
        public string descripcion { get; set; } ="";
        public int estado { get; set; }
        public int codUsuario { get; set; }
    }
}