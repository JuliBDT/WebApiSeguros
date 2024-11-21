using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace ApiWebSeguros.Dominio
{
    public class Cliente
    {
        [Key]
        public string cliente { get; set; } ="";
        public string nombre { get; set; } ="";
        public DateTime fechaNacimiento { get; set; }
        public DateTime? nulldate { get; set; }
        public DateTime fechaModificacion { get; set; }
        public int estadoCivil { get; set; }

    }
}