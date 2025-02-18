using Microsoft.EntityFrameworkCore;
using Steven_Javier_P1_AP1.Modelos;

namespace Steven_Javier_P1_AP1.DAL;

public class Contexto : DbContext
{
    public Contexto(DbContextOptions<Contexto> options) : base(options) { }
    public DbSet<Aportes> Aportes { get; set; }
}