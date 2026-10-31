using System.ComponentModel.DataAnnotations;

namespace backend.Dtos;

public class EditarProdutoDto
{
    [Required]
    public string Nome { get; set; } = string.Empty;

    [Range(0.01, 10000)]
    public decimal Preco { get; set; }
    

}
