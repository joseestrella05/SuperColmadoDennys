using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SuperColmadoDennys.Models;

public class ComprasDetalles
{
    [Key]
    public int DetalleId { get; set; }
    public int CompraId { get; set; }
    public int Cantidad { get; set; }
    public decimal Precio { get; set; }
    public int ProductoId { get; set; }

    [ForeignKey("ProductoId")]
    public Productos? Productos { get; set; }
}
