using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiWebSeguros.Dominio
{
    public class Ramo
    {
        public int ramo { get; set; }
        public DateTime fechaComputo { get; set; }
        public string descripcion { get; set; } ="";
        public int estadoRegistro { get; set; }
        public int codUsuario { get; set; }
    }
}