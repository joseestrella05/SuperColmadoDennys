using System.ComponentModel.DataAnnotations;

namespace SuperColmadoDennys.Models;

public class Estados
{
    [Key]
    public int EstadoId { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    public string? Nombre { get; set; }
}
