using Microsoft.EntityFrameworkCore;
using SuperColmadoDennys.Data;
using System.Linq.Expressions;
using System;
using SuperColmadoDennys.Models;
namespace SuperColmadoDennys.Services;

public class CategoriaService(IDbContextFactory<ApplicationDbContext> contextFactory)
{
    private readonly IDbContextFactory<ApplicationDbContext> _contextFactory = contextFactory;

    
    public async Task<List<Categoria>> ListarCategoriasAsync()
    {
        using var context = _contextFactory.CreateDbContext();
        return await context.Categorias.AsNoTracking().ToListAsync();
    }

    
    public async Task<Categoria?> ObtenerCategoriaPorIdAsync(int id)
    {
        using var context = _contextFactory.CreateDbContext();
        return await context.Categorias.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<Categoria> CrearCategoriaAsync(Categoria categoria)
    {
        using var context = _contextFactory.CreateDbContext();
        await context.Categorias.AddAsync(categoria);
        await context.SaveChangesAsync();
        return categoria;
    }

    public async Task<bool> ModificarCategoriaAsync(Categoria categoria)
    {
        using var context = _contextFactory.CreateDbContext();
        var categoriaExistente = await context.Categorias.FindAsync(categoria.Id);
        if (categoriaExistente == null)
            return false;

        context.Entry(categoriaExistente).CurrentValues.SetValues(categoria);
        return await context.SaveChangesAsync() > 0;
    }

    
    public async Task<bool> EliminarCategoriaAsync(int id)
    {
        using var context = _contextFactory.CreateDbContext();
        var categoria = await context.Categorias.FindAsync(id);
        if (categoria == null)
            return false;

        context.Categorias.Remove(categoria);
        return await context.SaveChangesAsync() > 0;
    }

    public async Task<bool> NombreCategoriaExisteAsync(int id, string? nombre)
    {
        if (string.IsNullOrWhiteSpace(nombre))
            return false;

        using var context = _contextFactory.CreateDbContext();
        return await context.Categorias
            .AsNoTracking()
            .AnyAsync(c => c.Id != id && c.Nombre.Trim().ToLower() == nombre.Trim().ToLower());
    }

    public async Task<List<Categoria>> FiltrarCategoriasAsync(Expression<Func<Categoria, bool>> filtro)
    {
        using var context = _contextFactory.CreateDbContext();
        return await context.Categorias
            .AsNoTracking()
            .Where(filtro)
            .ToListAsync();
    }
}
