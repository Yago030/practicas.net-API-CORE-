namespace MinimalAPISeeds.DTOs
{
    public class CreateCropDTO
    {
        public string Name { get; set; } = null!; // Nombre (Ejemplo: "Tomate")
        public List<int> SeasonIds { get; set; } = new(); // IDs de las temporadas relacionadas
        public List<int> PlantingMethodIds { get; set; } = new(); // Lista de IDs de métodos de siembra
        public string Spacing { get; set; } = null!; // Distancia
        public int MinHarvestDays { get; set; } // Días mínimos a cosecha
        public int MaxHarvestDays { get; set; } // Días máximos a cosecha
        public string PlantingDates { get; set; } = null!; // Fechas de siembra
        public string Varieties { get; set; } = null!; // Variedades
        public string WaterRequirement { get; set; } = null!; // Cantidad de agua
    }
}
