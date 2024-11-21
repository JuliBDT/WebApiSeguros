using System.ComponentModel.DataAnnotations;

namespace ApiWebSeguros.Dominio
{
    public class Poliza
    {
        [Key]
        public int RAMO { get; set; }
        public int PRODUCTO{ get; set; }
        public int POLIZA { get; set; }
        public string CLIENTE_TITULAR{ get; set; } ="";
        public DateTime? NULLDATE { get; set; }
        public DateTime FECHA_EFECTO{ get; set; }
        public DateTime FECHA_VIGENCIA{ get; set; }
        public string DOMICILIO { get; set; } ="";
        public int SUMA_ASEGURADA { get; set; }
        public int WAYPAY { get; set; }
    }
}