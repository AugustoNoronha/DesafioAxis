namespace DesafioAxis.WepApi.Models
{
    public class Cooperativas
    {
        public long Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public List<Favorito>? Favoritos { get; set; } 
    }
}
