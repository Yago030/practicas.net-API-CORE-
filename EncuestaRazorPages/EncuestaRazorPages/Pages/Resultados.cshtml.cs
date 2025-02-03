using EncuestaRazorPages.Models;
using EncuestaRazorPages.Servicios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EncuestaRazorPages.Pages
{
    public class ResultadosModel : PageModel
    {
        private readonly ServicioEncuestas _servicioEncuestas;
        public ResultadosModel(ServicioEncuestas servicioEncuestas)
        {
            _servicioEncuestas = servicioEncuestas;
        }

        public List<Encuesta> Encuestas { get; set; }

        public void OnGet()
        {
            Encuestas = _servicioEncuestas.Encuestas.ToList();
        }
    }
}
