using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Obligatorio2Web.Modelos
{
    [Index(nameof(NumDocumento), IsUnique = true)]
    [Index(nameof(Telefono), IsUnique = true)]
    [Index(nameof(CorreoElec), IsUnique = true)]
    public class Huesped
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdHuesped { get; private set; }
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
        public string? TipoDocumento { get; set; }
        [Required]
        public int NumDocumento { get; set; }
        [Required]
        public int Telefono { get; set; }
        [Required]
        [EmailAddress]
        public string? CorreoElec { get; set; }
        [ForeignKey("Usuario")]
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
    }
}
