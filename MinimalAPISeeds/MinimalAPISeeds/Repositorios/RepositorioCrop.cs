using Microsoft.EntityFrameworkCore;
using MinimalAPISeeds.Entidades;

namespace MinimalAPISeeds.Repositorios
{
    public class RepositorioCrops : IRepositorioCrop
    {
        private readonly ApplicationDbContext _context;

        public RepositorioCrops(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Create(Crop crop, List<int> seasonIds, List<int> plantingMethodIds)
        {
            // Vincular las temporadas al cultivo
            if (seasonIds.Any())
            {
                var existingSeasons = await _context.Seasons
                    .Where(s => seasonIds.Contains(s.Id))
                    .ToListAsync();

                crop.Seasons = existingSeasons;
            }

            // Vincular los métodos de siembra al cultivo
            if (plantingMethodIds.Any())
            {
                var existingMethods = await _context.PlantingMethods
                    .Where(pm => plantingMethodIds.Contains(pm.Id))
                    .ToListAsync();

                crop.PlantingMethods = existingMethods;
            }

            _context.Crops.Add(crop);
            await _context.SaveChangesAsync();
            return crop.Id;
        }


        public async Task<Crop?> GetById(int id)
        {
            // Incluir las relaciones de temporadas y métodos de siembra
            return await _context.Crops
                .Include(c => c.Seasons)
                .Include(c => c.PlantingMethods)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<List<Crop>> GetAll()
        {
            // Incluir las relaciones de temporadas y métodos de siembra
            return await _context.Crops
                .Include(c => c.Seasons)
                .Include(c => c.PlantingMethods)
                .OrderBy(c => c.Name)
                .ToListAsync();
        }

        public async Task Update(Crop crop)
        {
            var existingCrop = await _context.Crops
                .Include(c => c.PlantingMethods)
                .Include(c => c.Seasons)
                .FirstOrDefaultAsync(c => c.Id == crop.Id);

            if (existingCrop != null)
            {
                // Actualizar la relación de temporadas
                existingCrop.Seasons.Clear();
                if (crop.Seasons.Any())
                {
                    var existingSeasons = await _context.Seasons
                        .Where(s => crop.Seasons.Select(x => x.Id).Contains(s.Id))
                        .ToListAsync();

                    existingCrop.Seasons = existingSeasons;
                }

                // Actualizar la relación de métodos de siembra
                existingCrop.PlantingMethods.Clear();
                if (crop.PlantingMethods.Any())
                {
                    var existingMethods = await _context.PlantingMethods
                        .Where(pm => crop.PlantingMethods.Select(x => x.Id).Contains(pm.Id))
                        .ToListAsync();

                    existingCrop.PlantingMethods = existingMethods;
                }

                // Actualizar otras propiedades
                existingCrop.Name = crop.Name;
                existingCrop.Spacing = crop.Spacing;
                existingCrop.MinHarvestDays = crop.MinHarvestDays;
                existingCrop.MaxHarvestDays = crop.MaxHarvestDays;
                existingCrop.PlantingDates = crop.PlantingDates;
                existingCrop.Varieties = crop.Varieties;
                existingCrop.WaterRequirement = crop.WaterRequirement;

                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Crop>> GetByCriteria(string? name, string? waterRequirement)
        {
            var query = _context.Crops.AsQueryable();

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(c => c.Name.Contains(name));
            }

            if (!string.IsNullOrEmpty(waterRequirement))
            {
                query = query.Where(c => c.WaterRequirement.Contains(waterRequirement));
            }

            return await query
                .Include(c => c.Seasons)
                .Include(c => c.PlantingMethods)
                .OrderBy(c => c.Name)
                .ToListAsync();
        }

        public async Task<List<Crop>> GetByName(string name)
        {
            return await _context.Crops
                .Where(c => c.Name.Contains(name))
                .Include(c => c.Seasons)
                .Include(c => c.PlantingMethods)
                .OrderBy(c => c.Name)
                .ToListAsync();
        }

        public async Task<List<Crop>> GetByWaterRequirement(string waterRequirement)
        {
            return await _context.Crops
                .Where(c => c.WaterRequirement.Contains(waterRequirement))
                .Include(c => c.Seasons)
                .Include(c => c.PlantingMethods)
                .OrderBy(c => c.Name)
                .ToListAsync();
        }

        public async Task Delete(int id)
        {
            var crop = await _context.Crops
                .Include(c => c.PlantingMethods)
                .Include(c => c.Seasons)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (crop != null)
            {
                crop.PlantingMethods.Clear();
                crop.Seasons.Clear();
                _context.Crops.Remove(crop);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> CropExists(int id)
        {
            return await _context.Crops.AnyAsync(c => c.Id == id);
        }

        public async Task<List<Crop>> GetCropsByPlantingMethod(string plantingMethodName)
        {
            return await _context.Crops
                .Include(c => c.Seasons)
                .Include(c => c.PlantingMethods)
                .Where(c => c.PlantingMethods.Any(pm => pm.Name.Contains(plantingMethodName)))
                .ToListAsync();
        }
    }
}
