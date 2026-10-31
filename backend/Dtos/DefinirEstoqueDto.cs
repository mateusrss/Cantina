using System.ComponentModel.DataAnnotations;

namespace backend.Dtos;

public class DefinirEstoqueDto
{
    [Range(0, 10000)]
    public int Quantidade {get; set; }
}
