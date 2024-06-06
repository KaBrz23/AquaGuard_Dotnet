using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AquaGuard_Dotnet.Models;

public class Tanque
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string nome { get; set; } = string.Empty;
    [Required]
    public string hasFissuras { get; set; } = string.Empty;
    [Required]
    public string data { get; set; } = string.Empty;
    [Required]
    public int userId { get; set; }
    [Required]
    [ForeignKey("userId")]
    public Usuario usuario { get; set; }
}