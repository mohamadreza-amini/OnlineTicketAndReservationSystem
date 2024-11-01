using Infrastructure.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.RepositoryClasses
{
    public class BaseRepository<T, KeyTypeId> : IBaseRepository<T, KeyTypeId> where T : BaseEntity<KeyTypeId> where KeyTypeId : struct
    {
        private readonly OnlineTicketAndReservationDbContext _dbContext;
        private readonly DbSet<T> _dbset;
        public BaseRepository(OnlineTicketAndReservationDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbset = dbContext.Set<T>();
        }
        public async Task<T> CreateDataAsync(T data)
        {
            await _dbset.AddAsync(data);
            await CommitAsync();
            return data;
        }

        public async Task<IQueryable<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null)
        {
            if (predicate == null)
            {
                return await Task.Run(() => _dbset.AsQueryable());
            }
            return await Task.Run(() => _dbset.Where(predicate));
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbset.FirstOrDefaultAsync(predicate);
        }

        public async Task<T> GetByIdAsync(KeyTypeId id)
        {
            return await GetAsync(x => x.Equals(id));
        }

        public async Task<T> UpdateDataAsync(T data)
        {
            _dbset.Update(data);
            await CommitAsync();
            return data;
        }

        public async Task<bool> DeleteDataAsync(KeyTypeId id)
        {
            var data = await GetByIdAsync(id);
            if (data != null)
            {
                _dbset.Remove(data);
                await CommitAsync();
                return true;
            }
            return false;
        }

        public async Task<int> CommitAsync() => await _dbContext.SaveChangesAsync();

        public async Task<bool> Exists(Expression<Func<T, bool>> predicate)
        {
            return await _dbContext.Set<T>().AnyAsync(predicate);
        }
    }
}
