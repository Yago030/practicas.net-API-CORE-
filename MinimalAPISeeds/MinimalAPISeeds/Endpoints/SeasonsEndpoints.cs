using AutoMapper;
using MinimalAPISeeds.DTOs;
using MinimalAPISeeds.Entidades;
using MinimalAPISeeds.Repositorios;

namespace MinimalAPISeeds.Endpoints
{
    public static class SeasonsEndpoints
    {
        public static RouteGroupBuilder MapSeasons(this RouteGroupBuilder group)
        {
            group.MapGet("", ObtenerSeasons)
                .CacheOutput(c => c.Expire(TimeSpan.FromSeconds(10)).Tag("seasons-get"));

            group.MapPost("", CrearSeason);

            group.MapGet("/{id:int}", ObtenerSeasonPorId);

            group.MapPut("/{id:int}", ActualizarSeason);

            group.MapDelete("/{id:int}", BorrarSeason);

            return group;
        }

        static async Task<IResult> ObtenerSeasons(IRepositorioSeasons repositorio, IMapper mapper)
        {
            var seasons = await repositorio.GetAllSeasons();

            var seasonDTOs = mapper.Map<List<SeasonDTO>>(seasons);

            return TypedResults.Ok(seasonDTOs);
        }

        static async Task<IResult> CrearSeason(CrearSeasonDTO crearSeasonDTO, IRepositorioSeasons repositorio, IMapper mapper)
        {
            var season = mapper.Map<Season>(crearSeasonDTO);

            var id = await repositorio.Crear(season);

            return TypedResults.Created($"/seasons/{id}", new { id });
        }

        static async Task<IResult> ObtenerSeasonPorId(IRepositorioSeasons repositorio, int id, IMapper mapper)
        {
            var season = await repositorio.GetSeasonForID(id);

            if (season is null)
            {
                return TypedResults.NotFound();
            }

            var seasonDTO = mapper.Map<SeasonDTO>(season);

            return TypedResults.Ok(seasonDTO);
        }

        static async Task<IResult> ActualizarSeason(int id, SeasonDTO seasonDTO, IRepositorioSeasons repositorio, IMapper mapper)
        {
            var existe = await repositorio.ExistSeason(id);
            if (!existe)
            {
                return TypedResults.NotFound();
            }

            var season = mapper.Map<Season>(seasonDTO);
            season.Id = id; 

            await repositorio.UpdateSeason(season);

            return TypedResults.NoContent();
        }

        static async Task<IResult> BorrarSeason(int id, IRepositorioSeasons repositorio)
        {
            var existe = await repositorio.ExistSeason(id);
            if (!existe)
            {
                return TypedResults.NotFound();
            }

            await repositorio.DeleteSeason(id);

            return TypedResults.NoContent();
        }
    }
}
