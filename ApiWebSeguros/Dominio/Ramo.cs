using System.ComponentModel.DataAnnotations;

namespace ApiWebSeguros.Dominio
{
    public class Ramo
    {
        [Key]
        public int RAMO { get; set; }
        public DateTime FECHACOMPUTO { get; set; }
        public string DESCRIPCION { get; set; } ="";
        public int ESTADOREGISTRO { get; set; }
        public int CODUSUARIO { get; set; }
    }
}