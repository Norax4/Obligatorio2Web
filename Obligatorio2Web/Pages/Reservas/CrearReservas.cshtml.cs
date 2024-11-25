using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Obligatorio2Web.Datos;
using Obligatorio2Web.Modelos;

namespace Obligatorio2Web.Pages.Reservas
{
    public class CrearReservasModel : PageModel
    {
		private readonly AppDbContext _contexto;
		public CrearReservasModel(AppDbContext contexto)
		{
			_contexto = contexto;
		}
		[BindProperty]
		public Reserva Reserva { get; set; }

		public Habitacion Habitacion { get; set; }
		[TempData]
		public string Message { get; set; }
		public async Task OnGet(int id)
		{
			Habitacion = await _contexto.Habitaciones.FindAsync(id);

			if (Habitacion != null)
			{
				Reserva.NumHabitacion = Habitacion.NumHabitacion;
			}
		}

		public async Task<IActionResult> OnPost()
		{
			if (!ModelState.IsValid)
			{
				return Page();
			}

			if (Reserva == null)
			{
				Reserva = new Reserva();
			}
			Reserva.FechaReserva = DateTime.Now;
			_contexto.Add(Reserva);
			await _contexto.SaveChangesAsync();
			Message = "Reserva realizada correctamente";
			return RedirectToPage("");
		}
	}
}
