using MinimalAPISeeds.Entidades;

namespace MinimalAPISeeds.Repositorios
{
    public interface IRepositorioCrop
    {
        Task<int> Create(Crop crop, List<int> seasonIds, List<int> plantingMethodIds);
        Task<Crop?> GetById(int id); // Búsqueda por ID
        Task<List<Crop>> GetAll(); // Obtener todos los cultivos
        Task<List<Crop>> GetByName(string name); // Búsqueda por nombre
        Task<List<Crop>> GetByWaterRequirement(string waterRequirement); // Búsqueda por cantidad de agua
        Task Update(Crop crop);
        Task Delete(int id);
        Task<List<Crop>> GetByCriteria(string? name, string? waterRequirement); // Búsqueda combinada

        Task<bool> CropExists(int id);

        Task<List<Crop>> GetCropsByPlantingMethod(string plantingMethodName);

    }
}
