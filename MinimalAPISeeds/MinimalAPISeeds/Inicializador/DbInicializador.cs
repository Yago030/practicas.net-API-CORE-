using MinimalAPISeeds.Entidades;
using MinimalAPISeeds.Inicializador;
using MinimalAPISeeds;
using Microsoft.EntityFrameworkCore;

public class DbInicializador : IDbInicializador
{
    private readonly ApplicationDbContext _db;

    public DbInicializador(ApplicationDbContext db)
    {
        _db = db;
    }

    public void Inicializar()
    {
     
        if (_db.Database.GetPendingMigrations().Count() > 0)
        {

            _db.Database.Migrate();
        }


        if (!_db.Seasons.Any())
        {
            _db.Seasons.AddRange(new[]
            {
                new Season { Name = "Verano" },
                new Season { Name = "Invierno" },
                new Season { Name = "Primavera" },
                new Season { Name = "Otoño" },
                new Season { Name = "Todo el año" }
            });
            _db.SaveChanges();
        }

        if (!_db.PlantingMethods.Any())
        {
            _db.PlantingMethods.AddRange(new[]
            {
                new PlantingMethod { Name = "Almácigo y transplante" },
                new PlantingMethod { Name = "Almácigo seguido de transplante" },
                new PlantingMethod { Name = "Siembra directa a chorrillo" },
                new PlantingMethod { Name = "Directa en línea o transplante" },
                new PlantingMethod { Name = "Directa a golpes" }
            });
            _db.SaveChanges();
        }

    }
}
