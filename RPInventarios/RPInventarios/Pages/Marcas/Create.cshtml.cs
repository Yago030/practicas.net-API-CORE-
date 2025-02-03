using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RPInventarios.Data;
using RPInventarios.Models;

namespace RPInventarios.Pages.Marcas;

public class CreateModel : PageModel
{
    private readonly InventariosContext _context;
    private readonly INotyfService _servicioNotificacion;

    public CreateModel(InventariosContext context,INotyfService servicioNotificacion)
    {
        _context = context;
        _servicioNotificacion = servicioNotificacion;
    }

    public IActionResult OnGet()
    {
        return Page();
    }

    [BindProperty]
    public Marca Marca { get; set; }

    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            _servicioNotificacion.Error($"Es necesario corregir los problemas para poder crear la marca {Marca.Nombre}");
            return Page();
        }

        var existeMarcaBd = _context.Marcas.Any(u => u.Nombre.ToLower().Trim() == Marca.Nombre.ToLower().Trim());
        if (existeMarcaBd)
        {
            _servicioNotificacion.Warning($"Ya existe una marca con el nombre {Marca.Nombre}");
            return Page();
        }

        _context.Marcas.Add(Marca);
        await _context.SaveChangesAsync();
        _servicioNotificacion.Success($"ÉXITO al crear la marca {Marca.Nombre}");
        return RedirectToPage("./Index");
    }
}
