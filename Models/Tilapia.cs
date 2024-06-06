using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AquaGuard_Dotnet.Models;

public class Tilapia
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string isDoente { get; set; } = string.Empty;
    [Required]
    public string data { get; set; } = string.Empty;
    [Required]
    public int tanqueId { get; set; }
    [Required]
    [ForeignKey("tanqueId")]
    public Tanque tanque { get; set; }
}