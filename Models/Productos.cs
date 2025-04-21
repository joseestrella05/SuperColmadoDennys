using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuperColmadoDennys.Models;

public class Productos
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "El nombre del producto es obligatorio.")]
    [StringLength(100, MinimumLength = 2)]
    [RegularExpression(@"^[a-zA-Z0-9\sáéíóúÁÉÍÓÚñÑ]+$")]
    public string? Nombre { get; set; }

    [StringLength(500)]
    public string? Descripcion { get; set; }

    [Required(ErrorMessage = "El precio es obligatorio.")]
    [Range(0.01, double.MaxValue)]
    public float Precio { get; set; }

    [Required(ErrorMessage = "El stock es obligatorio.")]
    [Range(0, int.MaxValue)]
    public int Stock { get; set; }

    [Required(ErrorMessage = "El código de barras es obligatorio.")]
    [StringLength(13, MinimumLength = 8)]
    [RegularExpression(@"^[0-9]+$")]
    public string? CodigoBarras { get; set; }

    public DateTime? FechaVencimiento { get; set; }

    public bool EstaActivo { get; set; } = true;

    [Required(ErrorMessage = "La imagen es obligatoria.")]
    [StringLength(200)]
    public string? ImagenUrl { get; set; }

    // Relación muchos-a-uno con Categoria
    [ForeignKey("Categoria")]
    public int CategoriaId { get; set; }
    public virtual Categoria? Categoria { get; set; }

    [Required(ErrorMessage = "Debe seleccionar una provedor.")]
    public int ProveedorId { get; set; }
    [ForeignKey("ProveedorId")]
    public Provedores? Proveedor { get; set; }

    public float ITBIS { get; set; } = 0.18f; 
}
