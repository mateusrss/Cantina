using System.ComponentModel.DataAnnotations;

namespace backend.Dtos;

public class AjustarEstoqueDto{
    [Range(-10000, 10000)]
    public int Ajuste {get; set; }
}
