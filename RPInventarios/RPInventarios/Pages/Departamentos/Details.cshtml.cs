using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RPInventarios.Data;
using RPInventarios.Models;

namespace RPInventarios.Pages.Departamentos;

public class DetailsModel : PageModel
{
    private readonly InventariosContext _context;

    public DetailsModel(InventariosContext context)
    {
        _context = context;
    }

    public Departamento Departamento { get; set; }

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        Departamento = await _context.Departamentos
                                .AsNoTracking()
                                .FirstOrDefaultAsync(m => m.Id == id);

        if (Departamento == null)
        {
            return NotFound();
        }
        return Page();
    }
}
