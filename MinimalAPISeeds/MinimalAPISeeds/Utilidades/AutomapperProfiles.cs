using AutoMapper;
using MinimalAPISeeds.DTOs;
using MinimalAPISeeds.Entidades;

public class AutomapperProfiles : Profile
{
    public AutomapperProfiles()
    {
        // Mapeos de Season
        CreateMap<CrearSeasonDTO, Season>();
        CreateMap<Season, SeasonDTO>();
        CreateMap<SeasonDTO, Season>();

        // Mapeos de PlantingMethod
        CreateMap<CreatePlantingMethodDTO, PlantingMethod>();
        CreateMap<PlantingMethod, PlantingMethodDTO>();

        // Mapeos de Crop
        CreateMap<CreateCropDTO, Crop>()
            .ForMember(dest => dest.PlantingMethods, opt => opt.Ignore()) // Ignorar la lista de métodos de siembra, se manejará en el repositorio
            .ForMember(dest => dest.Seasons, opt => opt.Ignore()); // Ignorar la lista de temporadas, se manejará en el repositorio

        CreateMap<Crop, CropDTO>()
            .ForMember(dest => dest.PlantingMethods, opt => opt.MapFrom(src => src.PlantingMethods.Select(pm => new PlantingMethodDTO
            {
                Id = pm.Id,
                Name = pm.Name
            }).ToList())) // Mapeo de la entidad PlantingMethod a PlantingMethodDTO
            .ForMember(dest => dest.Seasons, opt => opt.MapFrom(src => src.Seasons.Select(s => new SeasonDTO
            {
                Id = s.Id,
                Name = s.Name
            }).ToList())); // Mapeo de la entidad Season a SeasonDTO
    }
}
