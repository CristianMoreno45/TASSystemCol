using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace UnalColombia.Common.API
{
    public static class MinimalApiExtensions
    {
        public static void MapCrudEndpoints<T, CustomDbContext>(this WebApplication app, string route) where T : class
            where CustomDbContext : DbContext
        {
            app.MapGet($"/{route}", async (CustomDbContext db) => await db.Set<T>().ToListAsync());

            app.MapGet($"/{route}/{{id}}", async (CustomDbContext db, Guid id) =>
                await db.Set<T>().FindAsync(id) is T entity ? Results.Ok(entity) : Results.NotFound());

            app.MapPost($"/{route}", async (CustomDbContext db, T entity) =>
            {
                db.Set<T>().Add(entity);
                await db.SaveChangesAsync();
                return Results.Created($"/{route}/{entity}", entity);
            });

            app.MapPut($"/{route}/{{id}}", async (CustomDbContext db, Guid id, T entity) =>
            {
                db.Set<T>().Update(entity);
                await db.SaveChangesAsync();
                return Results.NoContent();
            });

            app.MapDelete($"/{route}/{{id}}", async (CustomDbContext db, Guid id) =>
            {
                var entity = await db.Set<T>().FindAsync(id);
                if (entity == null) return Results.NotFound();
                db.Set<T>().Remove(entity);
                await db.SaveChangesAsync();
                return Results.NoContent();
            });
        }
    }
}
