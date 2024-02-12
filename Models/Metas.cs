using System.ComponentModel.DataAnnotations;

namespace Parcial1_Ap1_DelfryPaulino.Models;

public class Metas
{
    [Key]
    public int MetaId { get; set; }
    [Required(ErrorMessage = "La fecha es obligatoria")]
    public DateTime Fecha { get; set; }
    [Required(ErrorMessage = "La Descripcion es obligatoria")]
    public string? Descripcion { get; set; }
    [Range(0, double.MaxValue)]
    public double Monto { get; set;}

}
