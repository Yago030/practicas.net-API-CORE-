using System.ComponentModel.DataAnnotations;

namespace CrudNet8MVC.Models
{
    public class Contacto
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Name { get; set; }

        [Required(ErrorMessage = "El Telefono es obligatorio")]
        public string Telefono { get; set; }


        [Required(ErrorMessage = "El Celular es obligatorio")]
        public string Celular { get; set; }

        [Required(ErrorMessage = "El email es obligatorio")]
        [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "El formato del email no es válido")]
        public string Email { get; set; }

        [Display(Name = "Fecha de Creación / Edición")]
        public DateTime FechaCreacion { get; set; }



    }
}
