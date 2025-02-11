namespace Task1.Abstractions
{
    public interface IDbContext
    {
        IQueryable<TEntity> GetModelAsync<TEntity>() where TEntity : class;
        Task AddAsync<TEntity>(Model model) where TEntity : class;
        Task AddRangeAsync<TEntity>(IEnumerable<Model> models) where TEntity : class;
        void RemoveAll<TEntity>() where TEntity : class;
        Task<int> CommitChanges(CancellationToken token = default);
    }
}
