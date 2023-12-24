namespace csharp.Models;

public class Produto{
    public int Id { get; set; }
    public required string Nome { get; set; }
    public required int Estoque { get; set; }
}