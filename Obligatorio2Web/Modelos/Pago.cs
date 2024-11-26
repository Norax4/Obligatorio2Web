using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Obligatorio2Web.Modelos
{
    public class Pago
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPago { get; private set; }
        [Required]
        [ForeignKey("Reserva")]
        public int IdReserva { get; set; }
        public Reserva? Reserva { get; set; }
        [Required]
        [Column(TypeName = "date")]
        public DateTime FechaPago { get; set; }
        [Required]
        public int Monto { get; set; }
        [Required]
        public string? MetodoPago { get; set; }
        public bool RealizacionPago = false;
    }
}
