using System.ComponentModel.DataAnnotations;

namespace ApiWebSeguros.Dominio
{
    public class TipoRoles
    {
        [Key]
        public int rol { get; set; }
        public DateTime fechaComputo { get; set; }
        public string descripcion { get; set; } ="";
        public int estado { get; set; }
        public int codUsuario { get; set; }
    }
}