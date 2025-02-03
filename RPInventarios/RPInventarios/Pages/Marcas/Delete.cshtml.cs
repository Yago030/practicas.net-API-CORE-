using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RPInventarios.Data;
using RPInventarios.Models;

namespace RPInventarios.Pages.Marcas;

public class DeleteModel : PageModel
{
    private readonly InventariosContext _context;
    private readonly INotyfService _servicioNotificacion;

    public DeleteModel(InventariosContext context, INotyfService servicioNotificacion)
    {
        _context = context;
        _servicioNotificacion = servicioNotificacion;
    }

    [BindProperty]
    public Marca Marca { get; set; }

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null)
        {
            _servicioNotificacion.Warning($"El identificador debe tener un valor.");
            return NotFound();
        }

        Marca = await _context.Marcas.FirstOrDefaultAsync(m => m.Id == id);

        if (Marca == null)
        {
            _servicioNotificacion.Warning($"No se ha encontrado la marca con el identificador proporcionado.");
            return NotFound();
        }
        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        Marca = await _context.Marcas.FindAsync(id);

        if (Marca != null)
        {
            _context.Marcas.Remove(Marca);
            await _context.SaveChangesAsync();
        }

        _servicioNotificacion.Success($"ÉXITO al eliminar la marca {Marca.Nombre}");
        return RedirectToPage("./Index");
    }
}
