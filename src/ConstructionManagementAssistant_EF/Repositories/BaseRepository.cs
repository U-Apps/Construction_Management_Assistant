namespace RepositoryWithUWO.EF.Repositories;

public class BaseRepository<T>(AppDbContext _context) : IBaseRepository<T> where T : class
{

    #region GetByIdAsync Methods

    public async Task<T> GetByIdAsync(int id)
    {
        return await _context.Set<T>().FindAsync(id);
    }

    public async Task<T> GetByIdAsync(int? id)
    {
        if (id is null)
            return null;
        return await _context.Set<T>().FindAsync(id);
    }

    public async Task<T> GetByIdAsync(Guid id)
    {
        try
        {
            return await _context.Set<T>().FindAsync(id);
        }
        catch (Exception)
        {
            return null;
        }
    }

    public async Task<T?> GetByIdAsync(Guid? id)
    {
        try
        {
            if (!id.HasValue) return null;
            return await _context.Set<T>().FindAsync(id.Value);
        }
        catch (Exception)
        {
            return null;
        }
    }

    #endregion

    #region Find Methods

    public async Task<T> FindAsync(
        Expression<Func<T, bool>> criteria,
        params Expression<Func<T, object>>[] includes)
    {
        IQueryable<T> query = _context.Set<T>().Where(criteria);

        if (includes != null)
        {
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
        }

        return await query.SingleOrDefaultAsync();
    }

    public async Task<TResult?> FindWithSelectionAsync<TResult>(
        Expression<Func<T, TResult>> selector,
        Expression<Func<T, bool>> criteria,
        params Expression<Func<T, object>>[] includes)
    {
        IQueryable<T> query = _context.Set<T>().Where(criteria);

        if (includes != null)
        {
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
        }

        return await query.Select(selector).FirstOrDefaultAsync();
    }

    #endregion

    #region Read Data Methods

    public async Task<List<T>> GetAllDataAsync(
        Expression<Func<T, object>> orderBy,
        Expression<Func<T, bool>>? criteria = null,
        params Expression<Func<T, object>>[] includes)
    {
        var query = BuildQuery(orderBy, criteria, includes);
        return await query.ToListAsync();
    }

    public async Task<List<TResult>> GetAllDataWithSelectionAsync<TResult>(
        Expression<Func<T, object>> orderBy,
        Expression<Func<T, TResult>> selector,
        Expression<Func<T, bool>>? criteria = null,
        params Expression<Func<T, object>>[] includes)
    {
        var query = BuildQuery(orderBy, criteria, includes);
        var projectedQuery = query.Select(selector);

        return await projectedQuery.ToListAsync();
    }

    public async Task<PagedResult<T>> GetPagedDataAsync(
        Expression<Func<T, object>> orderBy,
        Expression<Func<T, bool>>? criteria = null,
        int pageNumber = 1,
        int pageSize = 10,
        params Expression<Func<T, object>>[] includes)
    {
        var query = BuildQuery(orderBy, criteria, includes);

        var totalItems = await query.CountAsync();
        var items = await query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();

        return new PagedResult<T>
        {
            CurrentPage = pageNumber,
            PageSize = pageSize,
            TotalItems = totalItems,
            Items = items,
            TotalPages = (int)Math.Ceiling(totalItems / (double)pageSize)
        };


        //return await PagedResult<T>.ToPagedResult(query, pageSize, pageNumber);
    }

    public async Task<PagedResult<TResult>> GetPagedDataWithSelectionAsync<TResult>(
        Expression<Func<T, object>> orderBy,
        Expression<Func<T, TResult>> selector,
        Expression<Func<T, bool>>? criteria = null,
        int pageNumber = 1,
        int pageSize = 10,
        params Expression<Func<T, object>>[] includes)
    {
        var query = BuildQuery(orderBy, criteria, includes);

        var totalItems = await query.CountAsync();

        var projectedQuery = query.Select(selector);

        var items = await projectedQuery.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();

        return new PagedResult<TResult>
        {
            CurrentPage = pageNumber,
            PageSize = pageSize,
            TotalItems = totalItems,
            Items = items,
            TotalPages = (int)Math.Ceiling(totalItems / (double)pageSize)
        };

    }

    #endregion

    #region Add Methods

    public async Task<T> AddAsync(T entity)
    {
        await _context.Set<T>().AddAsync(entity);
        return entity;
    }

    public async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities)
    {
        await _context.Set<T>().AddRangeAsync(entities);
        return entities;
    }

    #endregion

    #region Update Methods

    public T Update(T entity)
    {
        _context.Update(entity);
        return entity;
    }

    #endregion

    #region Delete Methods

    public void Delete(T entity)
    {
        if (entity is ISoftDeletable softDeletableEntity)
        {
            softDeletableEntity.IsDeleted = true;
            softDeletableEntity.DeletedDate = DateTime.Now;
        }
        else
        {
            _context.Set<T>().Remove(entity);
        }
    }

    public async System.Threading.Tasks.Task DeleteRange(IEnumerable<T> entities)
    {

        if (entities == null || !entities.Any())
            return;

        var entityType = typeof(T);

        // Check if the entity implements ISoftDeletable
        if (typeof(ISoftDeletable).IsAssignableFrom(entityType))
        {
            // Soft delete: Update DateDeleted and IsDeleted
            var now = DateTime.UtcNow; // or DateTime.Now depending on your requirements
            await _context.Set<T>()
                .Where(e => entities.Contains(e))
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(e => ((ISoftDeletable)e).DeletedDate, now)
                    .SetProperty(e => ((ISoftDeletable)e).IsDeleted, true));
        }
        else
        {
            // Hard delete: Remove the entities
            _context.Set<T>().RemoveRange(entities);
            await _context.SaveChangesAsync();
        }
    }

    #endregion

    #region Attach Methods

    public void Attach(T entity)
    {
        _context.Set<T>().Attach(entity);
    }

    public void AttachRange(IEnumerable<T> entities)
    {
        _context.Set<T>().AttachRange(entities);
    }

    #endregion

    #region Query Methods

    public async Task<bool> AnyAsync(Expression<Func<T, bool>> criteria)
    {
        return await _context.Set<T>().AnyAsync(criteria);
    }

    public IQueryable<T> Where(Expression<Func<T, bool>> criteria)
    {
        return _context.Set<T>().Where(criteria);
    }

    public IQueryable<T> AsQueryable()
    {
        return _context.Set<T>();
    }

    public IEnumerable<T> ExecuteRawSql(string query)
    {
        return _context.Set<T>().FromSqlRaw(query).AsEnumerable();
    }

    public IQueryable<T> IgnoreQueryFilters()
    {
        return _context.Set<T>().IgnoreQueryFilters();
    }

    #endregion

    #region Helper Methods

    private IQueryable<T> BuildQuery(
        Expression<Func<T, object>> orderBy,
        Expression<Func<T, bool>>? criteria = null,
        params Expression<Func<T, object>>[] includes)
    {
        IQueryable<T> query = _context.Set<T>();

        if (criteria != null)
            query = query.Where(criteria);

        if (includes != null)
        {
            foreach (var include in includes)
                query = query.Include(include);
        }

        return query.OrderBy(orderBy);
    }

    public async Task<BaseResponse<string>> CheckDuplicatePropertiesAsync(
        Dictionary<string, object?> properties,
        int? id = null)
    {
        string? duplicateProperty = null;
        Type entityType = typeof(T);

        foreach (var property in properties)
        {
            var propertyName = property.Key;
            var propertyValue = property.Value;
            if (propertyValue == null) continue;

            // If the entity is Person or its derived types (Worker, SiteEngineer, etc.), check in Person table
            if (typeof(Person).IsAssignableFrom(entityType))
            {
                if (await CheckDuplicateInTable<Person>(propertyName, propertyValue, id))
                {
                    duplicateProperty = propertyName;
                    break;
                }
            }
            // If the entity is Client, check in Client table
            else if (entityType == typeof(Client))
            {
                if (await CheckDuplicateInTable<Client>(propertyName, propertyValue, id))
                {
                    duplicateProperty = propertyName;
                    break;
                }
            }
            // Otherwise, check in the given entity's own table
            else
            {
                if (await CheckDuplicateInTable<T>(propertyName, propertyValue, id))
                {
                    duplicateProperty = propertyName;
                    break;
                }
            }
        }

        if (duplicateProperty != null)
        {
            return new BaseResponse<string>
            {
                Success = false,
                Message = $"A user with the same {duplicateProperty} already exists.",
            };
        }

        return new BaseResponse<string> { Success = true };
    }

    // Generic method to check for duplicates in a specific table
    private async Task<bool> CheckDuplicateInTable<T>(string propertyName, object propertyValue, int? id = null) where T : class
    {
        var parameter = Expression.Parameter(typeof(T), "e");
        var propertyExpression = Expression.Property(parameter, propertyName);
        var valueExpression = Expression.Constant(propertyValue);

        var equalityExpression = Expression.Equal(propertyExpression, valueExpression);
        var lambda = Expression.Lambda<Func<T, bool>>(equalityExpression, parameter);

        var query = _context.Set<T>().IgnoreQueryFilters().Where(lambda);

        if (id.HasValue)
        {
            var idProperty = Expression.Property(parameter, "Id");
            var idValue = Expression.Constant(id.Value);
            var idNotEqualExpression = Expression.NotEqual(idProperty, idValue);
            var finalExpression = Expression.AndAlso(equalityExpression, idNotEqualExpression);
            lambda = Expression.Lambda<Func<T, bool>>(finalExpression, parameter);
            query = _context.Set<T>().IgnoreQueryFilters().Where(lambda);
        }

        return await query.AnyAsync();
    }

    #endregion

}
