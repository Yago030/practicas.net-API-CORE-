namespace MinimalAPISeeds.DTOs
{
    public class CropDTO
    {
        public int Id { get; set; } // Identificador único
        public string Name { get; set; } = null!; // Nombre
        public List<SeasonDTO> Seasons { get; set; } = new(); // Relación con temporadas
        public List<PlantingMethodDTO> PlantingMethods { get; set; } = new(); // Relación con métodos de plantación
        public string Spacing { get; set; } = null!; // Distancia
        public int MinHarvestDays { get; set; } // Días mínimos a cosecha
        public int MaxHarvestDays { get; set; } // Días máximos a cosecha
        public string PlantingDates { get; set; } = null!; // Fechas de siembra
        public string Varieties { get; set; } = null!; // Variedades
        public string WaterRequirement { get; set; } = null!; // Requerimiento de agua
    }
}
