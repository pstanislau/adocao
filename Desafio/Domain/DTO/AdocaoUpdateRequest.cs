using System.ComponentModel.DataAnnotations;

namespace Desafio.Domain.DTO;

public class AdocaoUpdateRequest
{
    [Required(AllowEmptyStrings = false, ErrorMessage = "A idade é obrigatória")]
    public int Idade { get; set; }
}