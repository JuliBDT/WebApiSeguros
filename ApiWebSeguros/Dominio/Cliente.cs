using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace ApiWebSeguros.Dominio
{
    public class Cliente
    {
        [Key]
        public string CLIENTE { get; set; } ="";
        public string NOM_COMPLETO { get; set; } ="";
        public DateTime FECHA_NACIMIENTO { get; set; }
        public DateTime? NULLDATE { get; set; }
        public int ESTADO_CIVIL { get; set; }

    }
}