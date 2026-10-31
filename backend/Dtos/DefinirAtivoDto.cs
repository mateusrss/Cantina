using System.ComponentModel.DataAnnotations;

namespace backend.Dtos;

public class DefinirtAtivoDto
{
    [Required]
    public bool? Ativo { get; set; }
}
