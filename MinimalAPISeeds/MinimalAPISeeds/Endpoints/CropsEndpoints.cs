using AutoMapper;
using MinimalAPISeeds.DTOs;
using MinimalAPISeeds.Entidades;
using MinimalAPISeeds.Repositorios;

namespace MinimalAPISeeds.Endpoints
{
    public static class CropsEndpoints
    {
        public static RouteGroupBuilder MapCrops(this RouteGroupBuilder group)
        {
            group.MapGet("", GetAllCrops);
            group.MapPost("", CreateCrop);
            group.MapGet("/{id:int}", GetCropById);
            group.MapPut("/{id:int}", UpdateCrop);
            group.MapDelete("/{id:int}", DeleteCrop);
            group.MapGet("/by-planting-method/{methodName}", GetCropsByPlantingMethod);

            return group;
        }

        static async Task<IResult> GetAllCrops(IRepositorioCrop repository, IMapper mapper)
        {
            var crops = await repository.GetAll();
            var cropDTOs = mapper.Map<List<CropDTO>>(crops);
            return TypedResults.Ok(cropDTOs);
        }

    

        static async Task<IResult> CreateCrop(CreateCropDTO createCropDTO, IRepositorioCrop repository, IMapper mapper)
        {
            var crop = mapper.Map<Crop>(createCropDTO);
            var seasonIds = createCropDTO.SeasonIds; // Obtiene las temporadas asociadas
            var plantingMethodIds = createCropDTO.PlantingMethodIds; // Obtiene los métodos de siembra asociados
            var id = await repository.Create(crop, seasonIds, plantingMethodIds);
            return TypedResults.Created($"/crops/{id}", new { id });
        }




        static async Task<IResult> GetCropById(int id, IRepositorioCrop repository, IMapper mapper)
        {
            var crop = await repository.GetById(id);
            if (crop == null) return TypedResults.NotFound();
            var cropDTO = mapper.Map<CropDTO>(crop);
            return TypedResults.Ok(cropDTO);
        }

        static async Task<IResult> UpdateCrop(int id, CreateCropDTO createCropDTO, IRepositorioCrop repository, IMapper mapper)
        {
            var exists = await repository.CropExists(id);
            if (!exists) return TypedResults.NotFound();

            var crop = mapper.Map<Crop>(createCropDTO);
            crop.Id = id;
            await repository.Update(crop);

            return TypedResults.NoContent();
        }

        static async Task<IResult> DeleteCrop(int id, IRepositorioCrop repository)
        {
            var exists = await repository.CropExists(id);
            if (!exists) return TypedResults.NotFound();

            await repository.Delete(id);
            return TypedResults.NoContent();
        }

        static async Task<IResult> GetCropsByPlantingMethod(string methodName, IRepositorioCrop repository, IMapper mapper)
        {
            var crops = await repository.GetCropsByPlantingMethod(methodName);
            if (crops == null || crops.Count == 0) return TypedResults.NotFound();
            var cropDTOs = mapper.Map<List<CropDTO>>(crops);
            return TypedResults.Ok(cropDTOs);
        }
    }
}
