using System.ComponentModel.DataAnnotations;

namespace ApiWebSeguros.Dominio
{
    public class Poliza
    {
        [Key]
        public int ramo { get; set; }
        public int producto { get; set; }
        public int poliza { get; set; }
        public string clienteTitular { get; set; } ="";
        public DateTime? nulldate { get; set; }
        public DateTime fechaEfecto { get; set; }
        public DateTime fechaVigencia { get; set; }
        public string domicilio { get; set; } ="";
        public int sumaAsegurada { get; set; }
        public int waypay { get; set; }
    }
}