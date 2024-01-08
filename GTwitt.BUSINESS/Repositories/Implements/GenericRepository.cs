using GTwitt.BUSINESS.Repositories.Interfaces;
using GTwitt.CORE.Entities.Common;
using GTwitt.DAL.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GTwitt.BUSINESS.Repositories.Implements
{
    public class GenericRepository<T> :  IGenericRepository<T> where T : BaseEntity
    {
        GTwittDbContext _context { get; }

        public GenericRepository(GTwittDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public IQueryable<T> GetAll(bool noTracking = true) => noTracking ? Table.AsNoTracking() : Table;

        public async Task<bool> IsExistAsync(Expression<Func<T, bool>> expression)
        {
            return await Table.AnyAsync(expression);
        }

        public async Task CreateAsync(T data)
        {
            await Table.AddAsync(data);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<T> GetByIdAsync(int id, bool noTracking = true)
        {
            return noTracking ? await Table.AsNoTracking().SingleOrDefaultAsync(t => t.ID == id) : await Table.FindAsync(id);
        }

        public void Remove(T data)
        {
            Table.Remove(data);
        }
    }
}
