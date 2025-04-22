using Microsoft.EntityFrameworkCore;
using SuperColmadoDennys.Data;
using SuperColmadoDennys.Models;
using System.Linq.Expressions;

namespace SuperColmadoDennys.Services;

public class EstadoServices(IDbContextFactory<ApplicationDbContext> DbFactory)
{
    public async Task<List<Estados>> Listar(Expression<Func<Estados, bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Estados.AsNoTracking()
            .Where(criterio)
            .ToListAsync();
    }
}