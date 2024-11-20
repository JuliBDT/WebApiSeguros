using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiWebSeguros.Dominio.Entidades.DTOs
{
    public class PolizaToListDto
    {
        public int ramo { get; set; }
        public int producto { get; set; }
        public int poliza { get; set; }
        public string clienteTitular { get; set; }
        public DateTime fechaEfecto { get; set; }
        public DateTime fechaVigencia { get; set; }
        public int sumaAsegurada { get; set; }
        public int waypay { get; set; }
    }

    public class PolizaToCreateDto
    {
        public int ramo { get; set; }
        public int producto { get; set; }
        public string clienteTitular { get; set; }
        public DateTime fechaEfecto { get; set; }
        public DateTime fechaVigencia { get; set; }
        public string domicilio { get; set; }
        public int sumaAsegurada { get; set; }
        public int waypay { get; set; }
    }

    public class PolizaToUpdateDto : PolizaToCreateDto
    {
        public int poliza { get; set; }
        public DateTime? nulldate { get; set; }
    }
}
