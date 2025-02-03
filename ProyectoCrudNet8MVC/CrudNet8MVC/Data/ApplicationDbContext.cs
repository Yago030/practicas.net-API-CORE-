using CrudNet8MVC.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudNet8MVC.Data
{
    public class ApplicationDbContext : DbContext //siempre la clase debe extender de dbContext
    { 
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options) //siempre aqui deben ser asi inyectado
        {
            
        }
            
        //agregrar los modelos aqui (cada modelo es una tabla en la BD )

        public DbSet<Contacto> Contacto { get; set; }
        public DbSet<Contacto> Producto { get; set; }






    }
}
