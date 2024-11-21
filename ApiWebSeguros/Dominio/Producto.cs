using System.ComponentModel.DataAnnotations;

namespace ApiWebSeguros.Dominio
{
    public class Producto
    {

        public int RAMO { get; set; }
        [Key]
        public int PRODUCTO { get; set; }
        public DateTime FECHACOMPUTO{ get; set; }
        public string DESCRIPCION { get; set; } ="";
        public int ESTADOREGISTRO { get; set; }
        public int CODUSUARIO { get; set; }
    }

    
}