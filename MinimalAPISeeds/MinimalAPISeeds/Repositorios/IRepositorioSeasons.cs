using MinimalAPISeeds.Entidades;

namespace MinimalAPISeeds.Repositorios
{
    public interface IRepositorioSeasons
    {

              Task<int> Crear (Season season);
              Task<Season?> GetSeasonForID (int id);
              Task<List<Season>> GetAllSeasons();
              Task<bool> ExistSeason(int id);
               
              Task UpdateSeason(Season season);

              Task DeleteSeason(int id);
    }
}
