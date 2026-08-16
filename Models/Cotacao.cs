namespace ApiCotacoes.Models;

public class Cotacao
{
    public int Id { get; set; }
    public string Descricao { get; set; } = string.Empty;
    public string Fornecedor { get; set; } = string.Empty;
    public decimal Valor { get; set; }
    public DateTime Data { get; set; }
}
