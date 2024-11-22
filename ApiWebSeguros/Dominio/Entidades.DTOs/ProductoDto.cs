using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiWebSeguros.Dominio.Entidades.DTOs
{
    public class ProductoDto
    {
        public int Ramo { get; set; }
        public int Producto { get; set; }
        public string Descripcion { get; set; } = "";
    }
    public class ProductoCreateDTO
    {
        public int Ramo { get; set; }
        public int Producto { get; set; }
        public string Descripcion { get; set; } = "";
        public int EstadoRegistro { get; set; }
        public int CodUsuario { get; set; }
    }

        public class ProductoUpdateDTO
    {
        public string Descripcion { get; set; } = "";
        public int EstadoRegistro { get; set; }
        public int CodUsuario { get; set; }
    }

}