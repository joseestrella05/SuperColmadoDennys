using Microsoft.EntityFrameworkCore;
using SuperColmadoDennys.Data;
using SuperColmadoDennys.Models;
using System.Linq.Expressions;
using System;

namespace SuperColmadoDennys.Services;

public class ProductoService(IDbContextFactory<ApplicationDbContext> contextFactory) 
{
    private readonly IDbContextFactory<ApplicationDbContext> _contextFactory = contextFactory;

    public async Task<Productos?> BuscarNombres(string nombre)
    {
        await using var contexto = await _contextFactory.CreateDbContextAsync();
        return await contexto.Productos.AsNoTracking()
            .FirstOrDefaultAsync(t => t.Nombre == nombre);
    }
    
    public async Task<List<Productos>> ListarProducto()
    {
        using var context = _contextFactory.CreateDbContext();
        return await context.Productos
            .Include(c => c.Categoria)
            .ToListAsync();
    }

    private async Task<bool> Insertar(Productos producto)
    {
        await using var contexto = await _contextFactory.CreateDbContextAsync();
        contexto.Productos.Add(producto);
        return await contexto.SaveChangesAsync() > 0;
    }
    public async Task<bool> Modificar(Productos producto)
    {
        using var context = _contextFactory.CreateDbContext();
        context.Productos.Update(producto);
        var modificado = await context.SaveChangesAsync() > 0;
        context.Entry(producto).State = EntityState.Modified;
        return modificado;
    }

    public async Task<Productos?> Buscar(int productoId)
    {
        using var context = _contextFactory.CreateDbContext();
        return await context.Productos.AsNoTracking().FirstOrDefaultAsync(a => a.Id == productoId);
    }

    public async Task<bool> Eliminar(int id)
    {
        using var context = _contextFactory.CreateDbContext();
        var producto = await context.Productos.FindAsync(id);
        if (producto == null)
        {
            return false;
        }
        context.Productos.Remove(producto);
        return await context.SaveChangesAsync() > 0;
    }

    public async Task<bool> Guardar(Productos tecnico)
    {
        if (!await Existe(tecnico.Id))
            return await Insertar(tecnico);
        else
            return await Modificar(tecnico);
    }

    public async Task<bool> Existe(int id)
    {
        using var context = _contextFactory.CreateDbContext();
        return await context.Productos
            .AnyAsync(p => p.Id != id );
    }

    public async Task<List<Productos>> Listar(Expression<Func<Productos, bool>> expression)
    {
        using var context = _contextFactory.CreateDbContext();
        return await context.Productos
            .AsNoTracking()
            .Where(expression)
            .ToListAsync();
    }
}