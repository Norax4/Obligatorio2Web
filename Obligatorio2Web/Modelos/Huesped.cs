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
        public string? TipoDocumento { get; set; }
        [Required]
        public int NumDocumento { get; set; }
        [Required]
        public int Telefono { get; set; }
        [Required]
        [EmailAddress]
        public string? CorreoElec { get; set; }
    }
}
