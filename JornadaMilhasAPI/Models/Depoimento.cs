namespace JornadaMilhasAPI.Models
{
    /// <summary>
    /// Classe de modelo de depoimentos
    /// </summary>
    public class Depoimento
    {
        public int Id { get; set; }
        public string Foto { get; set; }
        public string DepoimentoTexto { get; set; }
        public string Nome { get; set; }
    }
}
