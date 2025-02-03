using EncuestaRazorPages.Models;
using EncuestaRazorPages.Servicios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EncuestaRazorPages.Pages
{
    public class EncuestaModel : PageModel
    {

        private readonly ServicioEncuestas _servicioEncuestas;
        public  EncuestaModel(ServicioEncuestas servicioEncuesta) { 
               _servicioEncuestas = servicioEncuesta;
        }


        [BindProperty]
        public Encuesta Encuesta { get; set; }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            _servicioEncuestas.Agregar(Encuesta);
            return RedirectToPage("Gracias");
        }

       
    }
}
