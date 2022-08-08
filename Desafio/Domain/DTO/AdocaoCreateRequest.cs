using System.ComponentModel.DataAnnotations;

namespace Desafio.Domain.DTO;

public class AdocaoCreateRequest
{
    [Required(AllowEmptyStrings = false, ErrorMessage = "O Nome é obrigatório!")]
    public string Nome { get; set; }
    [Required(AllowEmptyStrings = false, ErrorMessage = "A Idade é obrigatória!")]
    public int Idade { get; set; }
    [Required]
    [RegularExpression("Cachorro|Gato|Coelho|Capivara", ErrorMessage = "As especies devem ser: Cachorro, Gato, Coelho ou Capivara")]
    public string Especie { get; set; }
    public DateTime? Nascimento { get; set; }
    [Range(1,5, ErrorMessage = "A fofura deve estar no range 1 a 5")]
    public int Fofura { get; set; }
    [Range(1, 5, ErrorMessage = "O carinho deve estar no range 1 a 5")]
    public int Carinho { get; set; }
    [EmailAddress]
    public string Email { get; set; }
}