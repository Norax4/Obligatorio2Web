using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Obligatorio2Web.Datos;
using Obligatorio2Web.Modelos;

namespace Obligatorio2Web.Pages.Reservas
{
    public class PaginaReservasModel : PageModel
    {
        private readonly AppDbContext _contexto;
        public PaginaReservasModel(AppDbContext contexto)
        {
            _contexto = contexto;
        }
        public IEnumerable<Reserva> Reservas { get; set; }
        [TempData]
        public string Message { get; set; }
        public async Task OnGet()
        {
            Reservas = await _contexto.Reservas.ToListAsync();
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            var reserva = await _contexto.Reservas.FindAsync(id);

            if (reserva == null)
            {
                return NotFound();
            }

            _contexto.Reservas.Remove(reserva);
            await _contexto.SaveChangesAsync();
            Message = "Reserva borrada correctamente";

            return RedirectToPage();
        }
    }
}
