using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Obligatorio2Web.Modelos
{
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdUsuario { get; private set; }
        public Huesped? Huesped { get; set; }
        [Required]
        public string? Nombre { get; set; }
        [Required]
        [EmailAddress]
        public string? CorreoElec { get; set; }
        [Required]
        [StringLength(40, MinimumLength = 8)]
        public string? Contrasenia { get; set; }
        public List<Reserva> Reservas { get; set; }
    }
}
