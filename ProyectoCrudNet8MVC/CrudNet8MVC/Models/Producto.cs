using System.ComponentModel.DataAnnotations;

namespace CrudNet8MVC.Models
{
    public class Producto
    {
        [Key]
        public int ProductoId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }   

        [Required]
        public decimal Price { get; set; }



    }
}
