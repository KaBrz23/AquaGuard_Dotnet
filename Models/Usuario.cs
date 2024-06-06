using System.ComponentModel.DataAnnotations;

namespace AquaGuard_Dotnet.Models;

public class Usuario
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string nome { get; set; } = string.Empty;
    [Required]
    [EmailAddress]
    public string email { get; set; } = string.Empty;
    [Required]
    [DataType(DataType.Password)]
    public string senha { get; set; } = string.Empty;
    [Required]
    [DataType(DataType.PhoneNumber)]
    public string telefone { get; set; } = string.Empty;
    [Required]
    public string cpf { get; set; } = string.Empty;
    [Required] public string sexo { get; set; } = string.Empty;
}