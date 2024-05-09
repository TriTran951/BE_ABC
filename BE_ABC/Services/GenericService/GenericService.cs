using BE_ABC.Models.Context;
using Microsoft.EntityFrameworkCore;

namespace BE_ABC.Services.GenericService
{
    public class GenericService<T> where T : class
    {
        public readonly MyDbContext db;
        public GenericService(MyDbContext context)
        {
            db = context;
        }
        public async Task<T?> FindByIdAsync(object primaryKey)
        {
            var entity = await db.Set<T>().FindAsync(primaryKey);

            return entity;
        }
        public async Task<T> InsertAsync(T entity)
        {
            db.Attach(entity);
            var entityEntry = await db.Set<T>().AddAsync(entity);

            await SaveDatabaseAsync();

            return entityEntry.Entity;
        }
        public async Task UpdateAsync(T entity, Func<T, bool> predicate = default!)
        {
            if (predicate != default)
            {
                DetachLocal(predicate);
            }

            db.Set<T>().Update(entity);

            await SaveDatabaseAsync();
        }
        public async Task DeleteAsync(T entity, Func<T, bool> predicate = default!)
        {
            if (predicate != default)
            {
                DetachLocal(predicate);
            }

            db.Set<T>().Remove(entity);

            await SaveDatabaseAsync();
        }
        private async Task SaveDatabaseAsync()
        {
            await db.SaveChangesAsync();
        }
        private void DetachLocal(Func<T, bool> predicate)
        {
            var local = db.Set<T>().Local.FirstOrDefault(predicate);

            if (local != null)
            {
                db.Entry(local).State = EntityState.Detached;
            }
        }
    }
}
