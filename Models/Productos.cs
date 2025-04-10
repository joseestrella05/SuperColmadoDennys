using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuperColmadoDennys.Models;

public class Productos
{
    [Key] 
    public int Id { get; set; }

    [Required(ErrorMessage = "El nombre del producto es obligatorio.")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "El nombre debe tener entre 2 y 100 caracteres.")]
    [RegularExpression(@"^[a-zA-Z0-9\sáéíóúÁÉÍÓÚñÑ]+$", ErrorMessage = "El nombre solo puede contener letras, números y espacios.")]
    public string? Nombre { get; set; }

    [StringLength(500, ErrorMessage = "La descripción no puede exceder 500 caracteres.")]
    public string? Descripcion { get; set; } 

    [Required(ErrorMessage = "El precio es obligatorio.")]
    [Range(0.01, double.MaxValue, ErrorMessage = "El precio debe ser mayor a 0.")]
    public decimal Precio { get; set; }

    [Range(0, 1000, ErrorMessage = "La Cantidad debe estar entre 0 y 1000")]
    [Required(ErrorMessage = "Indique la Cantidad")]
    public int Cantidad { get; set; } 

    public DateTime? FechaVencimiento { get; set; } 

    public bool EstaActivo { get; set; } = true;

    [ForeignKey("Categorias")]
    public int CategoriaId { get; set; }

    public Categoria? Categoria { get; set; }

    public decimal ITBIS { get; set; }
}
