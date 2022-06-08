using FinalWebApp.Context;
using FinalWebApp.Entities;
using FinalWebApp.Models;
using FinalWebApp.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using FinalWebApp.Exceptions;

namespace FinalWebApp.Repositories
{
    public abstract class BaseRepository<TR, TE, TPk> : IBaseRepository<TE, TPk> where TE : BaseEntity<TPk>
    {
        private protected readonly ILogger<TR> logger;
        private protected readonly ApplicationContext context;
        private protected readonly DbSet<TE> _db;

        protected BaseRepository(ILogger<TR> logger, ApplicationContext context)
        {
            this.logger = logger;
            this.context = context;
            _db = context.Set<TE>();
        }

        public async Task DeleteAllAsync()
        {
            try
            {
                _db.RemoveRange(_db);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                throw;
            }
        }

        public async Task DeleteAsync(TE entity)
        {
            EnsureNotNull(entity);
            try
            {
                if(! await IsAvailable(entity))
                {
                    logger.LogError("Entity is not available");
                    throw new Exception("Entity is not available");
                }
                context.Entry(entity).State = EntityState.Deleted;
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                throw;
            }
        }

        public async Task DeleteRangeAsync(IEnumerable<TE> entities)
        {
            try
            {
                _db.RemoveRange(entities);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                throw;
            }
        }

        public async Task<bool> ExistsByIdAsync(TPk id)
        {
            try
            {
                return await _db.AnyAsync(s => s.Id.Equals(id));
            }
            catch (Exception e)
            {
                logger.LogError(e.Message);
                throw;
            }
        }

        public async Task<bool> ExistsByAsync(Expression<Func<TE, bool>> predicate)
        {
            try
            {
                return await _db.AnyAsync(predicate);
            }
            catch (Exception e)
            {
                logger.LogError(e.Message);
                throw;
            }
        }

        public async Task<IEnumerable<TE>> GetAllAsync()
        {
            try
            {
                return await _db.OrderByDescending(s => s.Id).ToListAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                throw;
            }
        }

        public async Task<TE> GetByIdAsync(TPk id)
        {
            try
            {
                return await _db.FindAsync(id);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                throw;
            }
        }

        public async Task<IEnumerable<TE>> GetAllByIdAsync(IEnumerable<TPk> id)
        {
            try
            {
                IList<TE> result = new List<TE>();
                foreach (var idItem in id)
                {
                    var entity = await GetByIdAsync(idItem);
                    if (entity is null)
                        throw new NotFoundDataException($"Cannot find {nameof(TE)} by id {idItem}");
                    result.Add(entity);
                }

                return result;
            }
            catch (Exception e)
            {
                logger.LogError(e.Message);
                throw;
            }
        }

        public async Task SaveAsync(TE entity)
        {
            EnsureNotNull(entity);
            try
            {
                if (await IsAvailable(entity))
                    await UpdateAsync(entity);
                else 
                    await AddNewAsync(entity);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                throw;
            }
        }

        private async Task<bool> IsAvailable(TE entity)
        {
            return await _db.AnyAsync(s => s.Id.Equals(entity.Id));
        }

        private async Task AddNewAsync(TE entity)
        {
            entity.CreatedDate = DateTime.Now;
            entity.UpdatedDate = DateTime.Now;
            await _db.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        private async Task UpdateAsync(TE entity)
        {
            entity.UpdatedDate = DateTime.Now;
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

        private void EnsureNotNull(TE entity)
        {
            if (entity is null)
            {
                logger.LogError("Entity is null");
                throw new Exception("Entity is null");
            }
        }

        public async Task<IEnumerable<TE>> GetAllAsync(Expression<Func<TE, bool>> predicate)
        {
            try
            {
                return await _db.Where(predicate).OrderByDescending(s => s.Id).ToListAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                throw;
            }
        }

        public async Task<IEnumerable<TE>> GetAllAsync(PageRequest pageRequest)
        {
            try
            {
                return await _db.Skip((pageRequest.Page - 1) * pageRequest.Size)
                    .Take(pageRequest.Size)
                    .OrderByDescending(s => s.Id).ToListAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                throw;
            }
        }

        public async Task<IEnumerable<TE>> GetAllAsync(Expression<Func<TE, bool>> predicate, PageRequest pageRequest)
        {
            try
            {
                return await _db.Where(predicate)
                    .Skip((pageRequest.Page - 1) * pageRequest.Size)
                    .Take(pageRequest.Size)
                    .OrderByDescending(s => s.Id).ToListAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                throw;
            }
        }
    }
}
