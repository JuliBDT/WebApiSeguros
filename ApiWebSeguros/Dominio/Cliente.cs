using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiWebSeguros.Dominio
{
    public class Cliente
    {
        public string cliente { get; set; } ="";
        public string nombre { get; set; } ="";
        public DateTime fechaNacimiento { get; set; }
        public DateTime? nulldate { get; set; }
        public DateTime fechaModificacion { get; set; }
        public int estadoCivil { get; set; }

    }
}