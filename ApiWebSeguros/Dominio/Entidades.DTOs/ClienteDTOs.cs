using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiWebSeguros.Dominio.Entidades.DTOs
{
    public class ClienteToListDto
    {
        public string cliente { get; set; }
        public string nombre { get; set; }
        public DateTime fechaNacimiento { get; set; }
        public int estadoCivil { get; set; }
    }

    public class ClienteToCreateDto
    {
        public string cliente { get; set; }
        public string nombre { get; set; }
        public DateTime fechaNacimiento { get; set; }
        public int estadoCivil { get; set; }
    }

    public class ClienteToUpdateDto : ClienteToCreateDto
    {
        public DateTime? nulldate { get; set; }
    }
}

