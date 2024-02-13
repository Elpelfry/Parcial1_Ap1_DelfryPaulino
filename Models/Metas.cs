using System.ComponentModel.DataAnnotations;

namespace Parcial1_Ap1_DelfryPaulino.Models;

public class Metas
{
    [Key]
    public int MetaId { get; set; }
    [Required(ErrorMessage = "La Fecha es obligatoria")]
    public DateTime Fecha { get; set; }
    [Required(ErrorMessage = "La Descripción es obligatoria")]
    public string? Descripcion { get; set; }
    [Range(1000, double.MaxValue, ErrorMessage ="El Monto debe ser mayor a 1000")]
    public double Monto { get; set;}

}
