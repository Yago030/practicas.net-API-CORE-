﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RPInventarios.Data;
using RPInventarios.Models;

namespace RPInventarios.Pages.Marcas;

public class DetailsModel : PageModel
{
    private readonly InventariosContext _context;

    public DetailsModel(InventariosContext context)
    {
        _context = context;
    }

    public Marca Marca { get; set; }

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        Marca = await _context.Marcas
                            .AsNoTracking()
                            .FirstOrDefaultAsync(m => m.Id == id);

        if (Marca == null)
        {
            return NotFound();
        }
        return Page();
    }
}
