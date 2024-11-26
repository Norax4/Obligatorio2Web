using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Obligatorio2Web.Modelos
{
    public class Persona
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPersona { get; set; }
        [Required]
        [StringLength(50)]
        public string? Nombre { get; set; }
        [Required]
        [StringLength(100)]
        public string? Apellidos { get; set; }
        [Required]
        [Column(TypeName = "date")]
        public DateTime FechaNacimiento { get; set; }
        [Required]
        public string? PaisOrigen { get; set; }
    }
}
