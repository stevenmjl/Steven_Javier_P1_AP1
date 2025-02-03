using Microsoft.EntityFrameworkCore;
using Steven_Javier_P1_AP1.Modelos;

namespace RegistroTecnicos.DAL;

public class Contexto : DbContext
{
    public Contexto(DbContextOptions<Contexto> options) : base(options) { }
    public DbSet<Modelo> Modelo { get; set; }
}