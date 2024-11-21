using System.ComponentModel.DataAnnotations;

namespace ApiWebSeguros.Dominio
{
    public class Rol
    {
        public int ramo { get; set; }
        public int producto { get; set; }
        public int poliza { get; set; }
        [Key]
        public int rol { get; set; }
        public string cliente { get; set; } ="";
        public DateTime fechaEfecto { get; set; }
        public DateTime? nulldate { get; set; }
    }
}