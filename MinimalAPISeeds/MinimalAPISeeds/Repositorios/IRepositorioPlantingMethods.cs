using MinimalAPISeeds.Entidades;

namespace MinimalAPISeeds.Repositorios
{
    public interface IRepositorioPlantingMethods
    {
        Task<int> Create(PlantingMethod method);
        Task<List<PlantingMethod>> GetAll();
        Task<PlantingMethod?> GetById(int id);
        Task Update(PlantingMethod method);
        Task Delete(int id);
        Task<bool> Exists(int id);
    }
}
