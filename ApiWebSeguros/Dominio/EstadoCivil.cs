using System.ComponentModel.DataAnnotations;

namespace ApiWebSeguros.Dominio
{
    public class EstadoCivil
    {
        [Key]
        public int id { get; set; }
        public string descripcion { get; set; } ="";
    }
}