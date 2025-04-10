using System.ComponentModel.DataAnnotations;

namespace SuperColmadoDennys.Models;

public class Categoria
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "El nombre de la categoría es obligatorio.")]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "El nombre debe tener entre 2 y 50 caracteres.")]
    [RegularExpression(@"^[a-zA-Z\sáéíóúÁÉÍÓÚñÑ]+$", ErrorMessage = "El nombre solo puede contener letras y espacios.")]
    public string? Nombre { get; set; }

    [StringLength(200, ErrorMessage = "La descripción no puede exceder 200 caracteres.")]
    public string? Descripcion { get; set; } 

    public bool EstaActiva { get; set; } = true; 

    
    public virtual ICollection<Productos> Productos { get; set; } = new List<Productos>();
}