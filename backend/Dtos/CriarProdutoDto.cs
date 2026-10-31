using System.ComponentModel.DataAnnotations;

namespace backend.Dtos;

public class CriarProdutoDto{
    [Required]
    [StringLength(100)]
    public string Nome{ get; set;} = string.Empty;

    [Range(0.01, 100000)]
    public decimal Preco {get; set; }

    [Range(0, 10000)]
    public int QuantidadeEstoque{ get; set; }
}
