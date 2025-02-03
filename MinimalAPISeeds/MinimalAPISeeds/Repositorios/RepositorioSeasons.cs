using Microsoft.EntityFrameworkCore;
using MinimalAPISeeds.Entidades;

namespace MinimalAPISeeds.Repositorios
{
    public class RepositorioSeasons : IRepositorioSeasons
    {







        private readonly ApplicationDbContext context;

        public RepositorioSeasons(ApplicationDbContext context )
        {
            this.context = context;
        }

     
        public  async Task<List<Season>> GetAllSeasons()
        {
           return await context.Seasons.OrderBy(x=>x.Name).ToListAsync();
        }

        public async Task<Season?> GetSeasonForID(int id)
        {
            return await  context.Seasons.FirstOrDefaultAsync(x => x.Id == id) ;

        }


        public async Task<int> Crear(Season season)
        {
            context.Add(season);
            await context.SaveChangesAsync();
            return season.Id;
        }

        public async Task<bool> ExistSeason(int id)
        {
           return await context.Seasons.AnyAsync(x => x.Id == id);
        }



        public async Task UpdateSeason(Season season)
        {
            context.Update(season);
            await context.SaveChangesAsync();

        }



        public async Task DeleteSeason(int id)
        {
            await context.Seasons.Where(x => x.Id == id).ExecuteDeleteAsync();

        }
    }
}
