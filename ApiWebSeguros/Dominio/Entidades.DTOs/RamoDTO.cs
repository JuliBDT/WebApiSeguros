using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiWebSeguros.Dominio;

namespace ApiWebSeguros.Dominio.Entidades.DTOs
{
    public class RamoToListDto
    {
        public int ramo { get; set; }
        public DateTime fechaComputo { get; set; }
        public string descripcion { get; set; }
        public int estadoRegistro { get; set; }
        public int codUsuario { get; set; }
    }

    public class RamoToCreateDto
    {
        public string descripcion { get; set; }
        public int estadoRegistro { get; set; }
        public int codUsuario { get; set; }
    }

    public class RamoToUpdateDto
    {
        public int ramo { get; set; }
        public string descripcion { get; set; }
        public int estadoRegistro { get; set; }
        public int codUsuario { get; set; }
    }
}
