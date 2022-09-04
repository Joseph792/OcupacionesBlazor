using System.ComponentModel.DataAnnotations;

namespace RegistroOcupaciones.Models
{
    public class Ocupaciones
    {
        [Key]
        public int OcupacionId { get; set; }

        [Required(ErrorMessage = "Es obligatoria la descripcion")]
        public String? Descripcion { get; set; }

        [Range(minimum: 1, maximum: 25000, ErrorMessage = "Es obligatorio el salario")]
        public int Salario { get; set; }
    }
}