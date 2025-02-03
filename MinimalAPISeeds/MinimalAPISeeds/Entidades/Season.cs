namespace MinimalAPISeeds.Entidades
{
    public class Season
    {
        public int Id { get; set; } // Identificador único
        public string Name { get; set; } = null!; // Nombre de la temporada
        public List<Crop> Crops { get; set; } = new(); // Relación muchos a muchos con Crops
    }
}
