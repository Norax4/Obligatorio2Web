using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Obligatorio2Web.Modelos
{
    public class Reserva
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdReserva { get; private set; }

        [Required]
        [ForeignKey("Usuario")]
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        [ForeignKey("Habitacion")]
        public int NumHabitacion { get; set; }
        public Habitacion? HabitacionElegida { get; set; }

        [Required]
        [Range(1,4, ErrorMessage = "La cantidad de huespedes debe ser mayor a cero.")]
        public int NumeroPersonas { get; set; }

        [Required]
        [Column(TypeName = "date")]
        public DateTime FechaInicio { get; set; }
        [Required]
        [Column(TypeName = "date")]
        public DateTime FechaFinal { get; set; }
        [Required]
        [Column(TypeName = "date")]
        public DateTime FechaReserva { get; set; }

        [ForeignKey("Pago")]
        public int PagoId { get; set; }
        public Pago PagoReserva { get; set; }
    }
}
