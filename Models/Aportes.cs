using System.ComponentModel.DataAnnotations;

namespace Steven_Javier_P1_AP1.Modelos;
public class Aportes
{
    [Key]
    public int AportesId { get; set; }
    
    [Required(ErrorMessage = "La persona es requerida.")]
    [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "La persona solo puede contener letras y espacios.")]
    public String? Persona { get; set; }

    [Required(ErrorMessage = "La observacion es requerida.")]
    [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "La descripción solo puede contener letras y espacios.")]
    public string? Observacion { get; set; }

    [Required(ErrorMessage = "El monto es requerido.")]
    [Range(0, 10000000, ErrorMessage = "El monto no puede ser mayor a 10,000,000.")]
    public double Monto { get; set; }
}