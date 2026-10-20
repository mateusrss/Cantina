namespace backend.Models;

public class Produto
{
    public int Id {get; private set;}
    public string Nome { get; set;} = String.Empty;
    public decimal Preco { get; set;}
    public int QuantidadeEstoque {get; set;}
    public bool Ativo {get; set;}
}
