using System.ComponentModel.DataAnnotations;

namespace RPInventarios.Models;
public class Marca
{
        public int Id { get; set; }


        [Required(ErrorMessage = "La marca es reqeurida")]
        [MinLength(3, ErrorMessage = "Debe ser al menos 5 letras el nombre")]
        [MaxLength(50, ErrorMessage ="Como maximo debe tener 50 letras")]
        [Display(Name = "Marca")]
        public string Nombre { get; set; }

        public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}

