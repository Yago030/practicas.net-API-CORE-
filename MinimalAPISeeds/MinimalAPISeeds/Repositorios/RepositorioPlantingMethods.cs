using Microsoft.EntityFrameworkCore;
using MinimalAPISeeds.Entidades;

namespace MinimalAPISeeds.Repositorios
{
    public class RepositorioPlantingMethods : IRepositorioPlantingMethods
    {
        private readonly ApplicationDbContext _context;

        public RepositorioPlantingMethods(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Create(PlantingMethod method)
        {
            _context.PlantingMethods.Add(method);
            await _context.SaveChangesAsync();
            return method.Id;
        }

        public async Task<List<PlantingMethod>> GetAll()
        {
            return await _context.PlantingMethods.OrderBy(x => x.Name).ToListAsync();
        }

        public async Task<PlantingMethod?> GetById(int id)
        {
            return await _context.PlantingMethods.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task Update(PlantingMethod method)
        {
            _context.PlantingMethods.Update(method);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var method = await _context.PlantingMethods.FindAsync(id);
            if (method != null)
            {
                _context.PlantingMethods.Remove(method);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> Exists(int id)
        {
            return await _context.PlantingMethods.AnyAsync(x => x.Id == id);
        }
    }
}
