using Microsoft.EntityFrameworkCore;
using Steven_Javier_P1_AP1.Modelos;
using Steven_Javier_P1_AP1.DAL;
using System.Linq.Expressions;

namespace Steven_Javier_P1_AP1.Services;

public class ModelosService(IDbContextFactory<Contexto> DbFactory)
{
    // Guardar
    public async Task<bool> Guardar(Aportes aporte)
    {
        if (!await Existe(aporte.AportesId))
        {
            return await Insertar(aporte);
        }
        else
        {
            return await Modificar(aporte);
        }
    }

    // Existe
    private async Task<bool> Existe(int aporteId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Aportes
            .AnyAsync(a => a.AportesId == aporteId);
    }

    // Insertar
    private async Task<bool> Insertar(Aportes aporte)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.Aportes.Add(aporte);
        return await contexto.SaveChangesAsync() > 0;
    }

    // Modificar
    private async Task<bool> Modificar(Aportes aporte)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.Update(aporte);
        return await contexto.SaveChangesAsync() > 0;
    }

    // Buscar
    public async Task<Aportes?> Buscar(int aporteId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Aportes
            .FirstOrDefaultAsync(a => a.AportesId == aporteId);
    }

    // Eliminar
    public async Task<bool> Eliminar(int aporteId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Aportes
            .AsNoTracking()
            .Where(a => a.AportesId == aporteId)
            .ExecuteDeleteAsync() > 0;
    }

    // Listar
    public async Task<List<Aportes>> Listar(Expression<Func<Aportes, bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Aportes
            .Where(criterio)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<int> UltimoId()
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        var ultimoAporte = await contexto.Aportes
            .OrderByDescending(a => a.AportesId)
            .FirstOrDefaultAsync();
        return ultimoAporte != null ? ultimoAporte.AportesId : 0;
    }
}