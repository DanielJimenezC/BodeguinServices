using FluentValidation;
using FluentValidation.Results;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Bodeguin.Domain.Interface
{
    public interface IRepository<TEntity, in TId> where TEntity : class
    {
        Task<TEntity> GetAsync(TId id);
        IQueryable<TEntity> All(bool @readonly = true);
        IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate, bool @readonly = true);
        Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate);
        Task<ValidationResult> AddAsync(TEntity entity, IValidator<TEntity> validation);
        Task<ValidationResult> UpdateAsync(TEntity entity, IValidator<TEntity> validation);
        Task<ValidationResult> DeleteAsync(TEntity entity, IValidator<TEntity> validation);
        Task<ValidationResult> ValidateEntityAsync(TEntity entity, IValidator<TEntity> validation);
    }
}
