namespace MinimalAPISeeds.Entidades
{
    public class PlantingMethod
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!; // Inicialización para evitar errores de no nulabilidad
        public List<Crop> Crops { get; set; } = new List<Crop>(); // Inicialización de la lista
    }
}
