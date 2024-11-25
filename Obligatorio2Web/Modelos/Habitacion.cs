using System.ComponentModel.DataAnnotations;

namespace Obligatorio2Web.Modelos
{
    public class Habitacion
    {
        [Key]
        public int NumHabitacion { get; set; }
        [Required]
        public string? TipoHabitacion { get; set; }
        public int CantidadPersonas { 
            get => CantidadPersonas;
            set
            {
                if (TipoHabitacion == "Simple")
                {
                    CantidadPersonas = 2;
                } else if (TipoHabitacion == "Doble" || TipoHabitacion == "Suite")
                {
                    CantidadPersonas = 4;
                }
            }
        }
        public int Tarifa { 
            get => Tarifa;
            set
            {
                if (TipoHabitacion == "Simple")
                {
                    Tarifa = 100;
                } else if (TipoHabitacion == "Doble")
                {
                    Tarifa = 150;
                } else if (TipoHabitacion == "Suite")
                {
                    Tarifa = 200;
                }
            }
        }
        public bool Estado = false;
        public int CountReservas = 0;
        //public Dictionary<DateTime, DateTime> FechasReservadas { get; set; } resolver luego
    }
}
