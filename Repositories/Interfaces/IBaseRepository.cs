using FinalWebApp.Entities;
using FinalWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FinalWebApp.Repositories.Interfaces
{
    public interface IBaseRepository<TE, TPk> where TE: BaseEntity<TPk>
    {
        Task<IEnumerable<TE>> GetAllAsync();
        Task<IEnumerable<TE>> GetAllAsync(Expression<Func<TE, bool>> predicate);
        Task<IEnumerable<TE>> GetAllAsync(PageRequest pageRequest);
        Task<IEnumerable<TE>> GetAllAsync(Expression<Func<TE, bool>> predicate, PageRequest pageRequest);
        Task<long> CountAllAsync();
        Task<TE> GetByIdAsync(TPk id);
        Task<IEnumerable<TE>> GetAllByIdAsync(IEnumerable<TPk> id);
        Task SaveAsync(TE entity);
        Task DeleteAsync(TE entity);
        Task DeleteAllAsync();
        Task DeleteRangeAsync(IEnumerable<TE> entities);
        Task<bool> ExistsByIdAsync(TPk id);
        Task<bool> ExistsByAsync(Expression<Func<TE, bool>> predicate);
    }
}
