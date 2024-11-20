namespace ApiWebSeguros.Dominio.Entidades.DTOs
{
    public class RolDto
    {
        public int Rol { get; set; }
        public string Cliente { get; set; } = "";
        public DateTime FechaEfecto { get; set; }
    }
}
