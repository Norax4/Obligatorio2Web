using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Obligatorio2Web.Datos;
using Obligatorio2Web.Modelos;

namespace Obligatorio2Web.Pages.Reservas
{
    public class ModificarReservaModel : PageModel
    {
		private readonly AppDbContext _contexto;
		public ModificarReservaModel(AppDbContext contexto)
		{
			_contexto = contexto;
		}
		[BindProperty]
		public Reserva Reserva { get; set; }
        [TempData]
        public string Message { get; set; }
        public async Task OnGet(int id) 
        {
            Reserva = await _contexto.Reservas.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var ReservaDesdeBD = await _contexto.Reservas.FindAsync(Reserva.IdReserva);
                if (ReservaDesdeBD != null)
                {
                    ReservaDesdeBD.NumHabitacion = Reserva.NumHabitacion;
                    ReservaDesdeBD.FechaInicio = Reserva.FechaInicio;
                    ReservaDesdeBD.FechaFinal = Reserva.FechaFinal;
                    await _contexto.SaveChangesAsync();
                    Message = "Reserva modificada correctamente.";
                    return RedirectToPage("PaginaReservas");
                }
                else
                {
                    // Manejar el caso en que no se encuentre el curso en la base de datos
                    return NotFound();
                }
            }
            // ModelState no es válido, volver a mostrar la página con los errores
            return Page();
        }

    }
}
