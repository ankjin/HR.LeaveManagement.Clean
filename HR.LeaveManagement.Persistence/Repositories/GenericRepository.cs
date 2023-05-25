using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Domain.Common;
using HR.LeaveManagement.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Persistence.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
{
    protected readonly HrDatabaseContext _context;

    public GenericRepository(HrDatabaseContext context)
    {
        _context = context;
    }
    public async ValueTask CreateAsync(T entity)
    {
        await _context.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async ValueTask DeleteAsync(T entity)
    {
        _context.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async ValueTask<IReadOnlyList<T>> GetAsync()
    {
        return await _context.Set<T>().AsNoTracking().ToListAsync();
    }

    public async ValueTask<T> GetByIdAsync(int id)
    {
        //return await _context.Set<T>().FirstOrDefaultAsync();
        return await _context.Set<T>().AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
    }

    public async ValueTask UpdateAsync(T entity)
    {
        //_context.Update(entity);
        _context.Entry(entity).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }
}
