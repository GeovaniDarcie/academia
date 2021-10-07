using System;
using Academia.Domain.Interfaces;
using Academia.Domain.Entities;
using Academia.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace Academia.Data.Repository
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly AcademiaContext _context;
        private DbSet<T> _dataSet;

        public BaseRepository(AcademiaContext context)
        {
            _context = context;
            _dataSet = _context.Set<T>();
        }

        public async Task<Usuario> Get(string username, string password) 
        {
            return await _context.Usuarios
                .Where(
                    x => x.UserName.ToLower() == username.ToLower() &&
                    x.Password == password
                ).FirstOrDefaultAsync();
        }

        public async Task<T> InsertAsync(T item)
        {
            try
            {
                _dataSet.Add(item);

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return item;
        }

        public async Task<T> UpdateAsync(T item)
        {
            try
            {
                var result = await _dataSet.SingleOrDefaultAsync(a => a.Id.Equals(item.Id));
                if (result == null)
                    return null;

                _context.Entry(result).CurrentValues.SetValues(item);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return item;
        }

        public async Task<bool> DeleteAsync(long id)
        {
            try
            {
                var result = await _dataSet.SingleOrDefaultAsync(a => a.Id.Equals(id));
                if (result == null)
                    return false;

                _dataSet.Remove(result);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<bool> ExistAsync(long id)
        {
            return await _dataSet.AnyAsync(a => a.Id.Equals(id));
        }

        public async Task<T> SelectAsync(long id)
        {
            try
            {
                return await _dataSet.SingleOrDefaultAsync(a => a.Id.Equals(id));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<IEnumerable<T>> SelectAsync()
        {
            try
            {
                return await _dataSet.ToListAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}