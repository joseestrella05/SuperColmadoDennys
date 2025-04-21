using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SuperColmadoDennys.Models;

public class Ordenes
{
    [Key]
    public int OrdenId { get; set; }

    [ForeignKey("ApplicationUser")]
    public string? ClienteId { get; set; }

    [Required(ErrorMessage = "El Nombre del Cliente es Obligatorio")]
    [RegularExpression("^[a-zA-Z ]+$", ErrorMessage = "El Nombre debe Contener Solo letras.")]
    public string? NombreCliente { get; set; }

    [ForeignKey("Estados")]
    public int EstadoId { get; set; }

    public string? Observacion { get; set; } = string.Empty;

    [Required(ErrorMessage = "El Teléfono es obligatorio")]
    [RegularExpression(@"^\d{3}-\d{3}-\d{4}$", ErrorMessage = "El número de teléfono debe tener el formato 800-000-0000")]
    public string? Telefono { get; set; }

    public DateTime Fecha { get; set; } = DateTime.Now;

    [Range(0.01, 1000000000, ErrorMessage = "El Precio debe estar 0.01 y 1000000000")]
    public float Monto { get; set; }

    [Range(0.01, 1000000000, ErrorMessage = "El ITBIS debe estar 0.01 y 1000000000")]
    public float ITBIS { get; set; }

    // Navigation Properties
    public ICollection<OrdenItem> OrdenesDetalle { get; set; } = new List<OrdenItem>();

}
