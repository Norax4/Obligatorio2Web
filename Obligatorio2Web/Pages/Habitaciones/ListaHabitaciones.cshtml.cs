using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Obligatorio2Web.Datos;
using Obligatorio2Web.Modelos;

namespace Obligatorio2Web.Pages.Habitaciones
{
    public class ListaHabitacionesModel : PageModel
    {
        private readonly AppDbContext _contexto;
        public ListaHabitacionesModel(AppDbContext contexto)
        {
            _contexto = contexto;
        }
        public IEnumerable<Habitacion> HabitacionesL { get; set; }
        public async Task OnGet()
        {
            HabitacionesL = await _contexto.Habitaciones.ToListAsync();
        }
    }
}
