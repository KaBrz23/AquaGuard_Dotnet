using AquaGuard_Dotnet.Models;
using Microsoft.EntityFrameworkCore;

namespace AquaGuard_Dotnet.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }
    
    public DbSet<Usuario> TabelaUsuario { get; set; }
    public DbSet<Tanque> TabelaTanque { get; set; }
    public DbSet<Tilapia> TabelaTilapia { get; set; }
    public DbSet<Relatorio> TabelaRelatorio { get; set; }
}