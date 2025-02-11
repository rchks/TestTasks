using Microsoft.EntityFrameworkCore;
using Task1.Abstractions;
using Task1.Models;

namespace Task1.Context
{
    public class DataContext: DbContext, IDbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<UserDataModel> UserData { get; set; }
        public DbSet<ResponseLogModel> ResponseLog { get; set; }

        public IQueryable<TEntity> GetModelAsync<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }

        public async Task AddAsync<TEntity>(Model model) where TEntity : class
        {
            await base.AddAsync(model);
        }

        public async Task AddRangeAsync<TEntity>(IEnumerable<Model> models) where TEntity : class
        {
            await base.AddRangeAsync(models);
        }

        public void RemoveAll<TEntity>() where TEntity : class
        {
            var entities = GetModelAsync<TEntity>();
            base.RemoveRange(entities);
        }

        public async Task<int> CommitChanges(CancellationToken token = default) 
        { 
            var result = await this.SaveChangesAsync(token);
            return result;
        }
    }
}
