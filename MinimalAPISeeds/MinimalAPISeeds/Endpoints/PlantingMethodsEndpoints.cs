using MinimalAPISeeds.DTOs;
using MinimalAPISeeds.Entidades;
using MinimalAPISeeds.Repositorios;
using AutoMapper;
using MinimalAPISeeds.DTOs;

namespace MinimalAPISeeds.Endpoints
{
    public static class PlantingMethodsEndpoints
    {
        public static RouteGroupBuilder MapPlantingMethods(this RouteGroupBuilder group)
        {
            group.MapPost("", CreatePlantingMethod);
            group.MapGet("", GetAllPlantingMethods);
            group.MapGet("/{id:int}", GetPlantingMethodById);
            group.MapPut("/{id:int}", UpdatePlantingMethod);
            group.MapDelete("/{id:int}", DeletePlantingMethod);

            return group;
        }

        static async Task<IResult> CreatePlantingMethod(CreatePlantingMethodDTO dto, IRepositorioPlantingMethods repository, IMapper mapper)
        {
            var plantingMethod = mapper.Map<PlantingMethod>(dto);
            var id = await repository.Create(plantingMethod);
            return TypedResults.Created($"/planting-methods/{id}", new { id });
        }

        static async Task<IResult> GetAllPlantingMethods(IRepositorioPlantingMethods repository)
        {
            var methods = await repository.GetAll();
            return TypedResults.Ok(methods);
        }

        static async Task<IResult> GetPlantingMethodById(int id, IRepositorioPlantingMethods repository)
        {
            var method = await repository.GetById(id);
            return method == null ? TypedResults.NotFound() : TypedResults.Ok(method);
        }

        static async Task<IResult> UpdatePlantingMethod(int id, CreatePlantingMethodDTO dto, IRepositorioPlantingMethods repository, IMapper mapper)
        {
            var exists = await repository.Exists(id);
            if (!exists) return TypedResults.NotFound();

            var plantingMethod = mapper.Map<PlantingMethod>(dto);
            plantingMethod.Id = id;

            await repository.Update(plantingMethod);
            return TypedResults.NoContent();
        }

        static async Task<IResult> DeletePlantingMethod(int id, IRepositorioPlantingMethods repository)
        {
            var exists = await repository.Exists(id);
            if (!exists) return TypedResults.NotFound();

            await repository.Delete(id);
            return TypedResults.NoContent();
        }
    }
}
