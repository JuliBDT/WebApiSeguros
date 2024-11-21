using System.ComponentModel.DataAnnotations;

namespace ApiWebSeguros.Dominio
{
    public class Ramo
    {
        [Key]
        public int ramo { get; set; }
        public DateTime fechaComputo { get; set; }
        public string descripcion { get; set; } ="";
        public int estadoRegistro { get; set; }
        public int codUsuario { get; set; }
    }
}