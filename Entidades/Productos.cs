
using System.ComponentModel.DataAnnotations;

namespace Pablo_Burgos_Ap1_p1.Entidades
{
    public class Productos
    {
        [Key]
        public int ProductosId { get; set; }
        public string Descripcion { get; set; }
        public float Existencia {get; set; }
        public float Costo { get; set; }
        public float ValorInventario { get; set; } 
    }
}