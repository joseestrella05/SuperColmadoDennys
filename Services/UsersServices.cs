using Microsoft.EntityFrameworkCore;
using SuperColmadoDennys.Data;

namespace SuperColmadoDennys.Services;

public class UsersServices(IDbContextFactory<ApplicationDbContext> DbFactory)
{

    public async Task<ApplicationUser> GetObject(string id)
    {
        using var context = await DbFactory.CreateDbContextAsync();
        return (await context.Users.FindAsync(id))!;
    }

    public async Task<List<ApplicationUser>> GetAllObject()
    {
        using var context = await DbFactory.CreateDbContextAsync();
        return await context.Users.ToListAsync();
    }

    public async Task<ApplicationUser> AddObject(ApplicationUser type)
    {
        using var context = await DbFactory.CreateDbContextAsync();
        context.Users.Add(type);
        await context.SaveChangesAsync();
        return type;
    }

    public async Task<bool> UpdateObject(ApplicationUser type)
    {
        using var context = await DbFactory.CreateDbContextAsync();
        context.Entry(type).State = EntityState.Modified;
        return await context.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteObject(string id)
    {
        using var context = await DbFactory.CreateDbContextAsync();
        var user = await context.Users.FindAsync(id);
        if (user == null)
        {
            return false;
        }
        context.Users.Remove(user);
        return await context.SaveChangesAsync() > 0;
    }
}
