using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AquaGuard_Dotnet.Models;

public class Relatorio
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string descricao { get; set; } = string.Empty;
    [Required]
    public int userId { get; set; }
    [Required]
    [ForeignKey("userId")]
    public Usuario usuario { get; set; }
}