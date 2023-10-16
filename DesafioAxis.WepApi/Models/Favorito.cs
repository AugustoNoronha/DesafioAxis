namespace DesafioAxis.WepApi.Models
{
    public class Favorito
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public PixType PixType { get; set; }
        public string PixKey { get; set; } = string.Empty;


    }

    public enum PixType
    {
        CPF = 0,
        CNPJ = 1,
        EMAIL = 2,
        TELEFONE = 3,
        ALEATORIA = 4
    }
}
