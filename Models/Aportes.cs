using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Steven_Javier_P1_AP1.Modelos;
public class Aportes
{
    [Key]
    public int AportesId { get; set; }
    
    [Required(ErrorMessage = "Se debe agregar el nombre completo.")]
    [RegularExpression(@"^[a-zA-ZñÑáéíóúÁÉÍÓÚ\s]+$",
    ErrorMessage = "La persona no debe contener números ni caracteres especiales.")]
    [MaxLength(50, ErrorMessage = "La persona no puede tener más de 50 carácteres.")]
    public String? Persona { get; set; }

    [Required(ErrorMessage = "La observacion es requerida.")]
    [MaxLength(100, ErrorMessage = "La observación no puede tener más de 100 caracteres.")]
    public string? Observacion { get; set; }

    [Required(ErrorMessage = "El monto es requerido.")]
    [Range(0, 10000000, ErrorMessage = "El monto no puede ser mayor a 10,000,000.")]
    public double Monto { get; set; }
}