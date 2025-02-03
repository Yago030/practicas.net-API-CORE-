using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RPInventarios.Models;

namespace RPInventarios.Pages.Departamentos;

public class DeleteModel : PageModel
{
    private readonly Data.InventariosContext _context;
    private readonly INotyfService _servicioNotificacion;

    public DeleteModel(Data.InventariosContext context,INotyfService servicioNotificacion)
    {
        _context = context;
        _servicioNotificacion = servicioNotificacion;
    }

    [BindProperty]
    public Departamento Departamento { get; set; }

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null)
        {
            _servicioNotificacion.Warning($"El identificador debe tener un valor.");
            return NotFound();
        }

        Departamento = await _context.Departamentos.FirstOrDefaultAsync(m => m.Id == id);

        if (Departamento == null)
        {
            _servicioNotificacion.Warning($"No se ha encontrado el departamento con el identificador proporcionado.");
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

        Departamento = await _context.Departamentos.FindAsync(id);

        if (Departamento != null)
        {
            _context.Departamentos.Remove(Departamento);
            await _context.SaveChangesAsync();
        }
        _servicioNotificacion.Success($"ÉXITO al eliminar el departamento {Departamento.Nombre}");
        return RedirectToPage("./Index");
    }
}
