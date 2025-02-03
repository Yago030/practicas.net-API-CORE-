using MinimalAPISeeds.Entidades;

public class Crop
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public List<Season> Seasons { get; set; } = new(); // Muchos a muchos con Season
    public List<PlantingMethod> PlantingMethods { get; set; } = new(); // Relación ya configurada
    public string Spacing { get; set; } = null!;
    public int MinHarvestDays { get; set; }
    public int MaxHarvestDays { get; set; }
    public string PlantingDates { get; set; } = null!;
    public string Varieties { get; set; } = null!;
    public string WaterRequirement { get; set; } = null!;
}
