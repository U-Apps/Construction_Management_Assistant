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

    public async Task<TResult> FindWithSelectionAsync<TResult>(
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

        return await query.Select(selector).SingleOrDefaultAsync();
    }

    #endregion

    #region Read Data Methods

    public async Task<IEnumerable<T>> GetAllDataAsync(
        Expression<Func<T, object>> orderBy,
        Expression<Func<T, bool>>? criteria = null,
        params Expression<Func<T, object>>[] includes)
    {
        var query = BuildQuery(orderBy, criteria, includes);
        return await query.ToListAsync();
    }

    public async Task<IEnumerable<TResult>> GetAllDataWithSelectionAsync<TResult>(
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
        if (entity is IEntity softDeletableEntity)
        {
            softDeletableEntity.IsDeleted = true;
            softDeletableEntity.DeletedDate = DateTime.UtcNow;
            _context.Update(entity);
        }
        else
        {
            _context.Set<T>().Remove(entity);
        }
    }

    public void DeleteRange(IEnumerable<T> entities)
    {
        foreach (var entity in entities)
        {
            if (entity is IEntity softDeletableEntity)
            {
                softDeletableEntity.IsDeleted = true;
                softDeletableEntity.DeletedDate = DateTime.UtcNow;
                _context.Update(entity);
            }
            else
            {
                _context.Set<T>().Remove(entity);
            }
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

    public async Task<BaseResponse<string>> CheckDuplicatePhoneEmailNationalNumberAsync(
        string? phoneNumber,
        string? email,
        string? nationalNumber,
        int? id = null)
    {
        if (phoneNumber != null && await _context.People.IgnoreQueryFilters().AnyAsync(g => g.PhoneNumber == phoneNumber && (!id.HasValue || g.Id != id.Value)))
        {
            return new BaseResponse<string>
            {
                Success = false,
                Message = "A user with the same phone number already exists.",
            };
        }

        if (email != null && await _context.People.IgnoreQueryFilters().AnyAsync(g => g.Email == email && (!id.HasValue || g.Id != id.Value)))
        {
            return new BaseResponse<string>
            {
                Success = false,
                Message = "A user with the same email already exists.",
            };
        }

        if (email != null && await _context.People.IgnoreQueryFilters().AnyAsync(g => g.NationalNumber == nationalNumber && (!id.HasValue || g.Id != id.Value)))
        {
            return new BaseResponse<string>
            {
                Success = false,
                Message = "A user with the same NationalNumber already exists.",
            };
        }

        return new BaseResponse<string> { Success = true };
    }

    #endregion

}
