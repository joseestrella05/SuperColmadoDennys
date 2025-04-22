using Microsoft.EntityFrameworkCore;
using SuperColmadoDennys.Data;
using SuperColmadoDennys.Models;
using System.Linq.Expressions;
using System;

namespace SuperColmadoDennys.Services;

public class OrdenesService(IDbContextFactory<ApplicationDbContext> DbFactory)
{
    
    public async Task<List<Ordenes>> GetAllObject()
    {
        using var context = await DbFactory.CreateDbContextAsync();
        return await context.Ordenes
            .Include(d => d.OrdenesDetalle)
            .ToListAsync();
    }

    public async Task<Ordenes> GetObject(int id)
    {
        using var context = await DbFactory.CreateDbContextAsync();
        return await context.Ordenes
            .Include(d => d.OrdenesDetalle)
            .FirstOrDefaultAsync(r => r.OrdenId == id);
    }

    public async Task<Ordenes> AddObject(Ordenes orden)
    {
        using var context = await DbFactory.CreateDbContextAsync();
        context.Ordenes.Add(orden);
        await context.SaveChangesAsync();
        return orden;
    }

    public async Task<bool> UpdateObject(Ordenes orden)
    {
        using var context = await DbFactory.CreateDbContextAsync();

        var detalle = await context.OrdenItems.Where(r => r.DetalleId == orden.OrdenId).ToListAsync();
        foreach (var item in detalle)
        {
            var producto = await context.Productos.FindAsync(item.ProductoId);
            if (producto != null)
            {
                producto.Stock += item.Cantidad;
                context.Entry(producto).State = EntityState.Modified;
                await context.SaveChangesAsync();
            }
        }

        if (orden.EstadoId != 4)
        {
            foreach (var item in orden.OrdenesDetalle)
            {
                var producto = await context.Productos.FindAsync(item.ProductoId);
                if (producto != null)
                {
                    producto.Stock -= item.Cantidad;
                    context.Entry(producto).State = EntityState.Modified;
                    await context.SaveChangesAsync();
                }
            }
        }

        context.Entry(orden).State = EntityState.Modified;
        return await context.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteObject(int id)
    {
        using var context = await DbFactory.CreateDbContextAsync();
        var orden = await context.Ordenes.FindAsync(id);
        if (orden == null)
            return false;

        await context.OrdenItems.Where(r => r.OrdenId == id).ExecuteDeleteAsync();
        context.Ordenes.Remove(orden);
        await context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> Exist(int id, string? nombre)
    {
        using var context = await DbFactory.CreateDbContextAsync();
        return await context.Ordenes
            .AnyAsync(p => p.OrdenId != id && p.NombreCliente.ToLower().Equals(nombre.ToLower()));
    }

    public async Task<List<Ordenes>> GetObjectByCondition(Expression<Func<Ordenes, bool>> expression)
    {
        using var context = await DbFactory.CreateDbContextAsync();
        return await context.Ordenes
            .Include(d => d.OrdenesDetalle)
            .AsNoTracking()
            .Where(expression)
            .ToListAsync();
    }
}