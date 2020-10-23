using Bodeguin.Domain.Interface;
using Bodeguin.Infraestructure.Context;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Bodeguin.Infraestructure.Repository
{
    public class GenericRepository<TEntity, TId> : IRepository<TEntity, TId>
        where TEntity : class
        where TId : IComparable<TId>
    {
        protected PostgreSqlContext _context { get; }
        protected DbSet<TEntity> DbSet { get; set; }

        public GenericRepository(PostgreSqlContext context)
        {
            _context = context;
            DbSet = _context.Set<TEntity>();
        }

        public async Task<TEntity> GetAsync(TId id)
        {
            var keyProperty = _context.Model.FindEntityType(typeof(TEntity)).FindPrimaryKey().Properties[0];
            var keyId = (int)Convert.ChangeType(id, typeof(int));
            var dbSet = (IQueryable<TEntity>)DbSet;
            return await dbSet.FirstOrDefaultAsync(x => EF.Property<int>(x, keyProperty.Name) == keyId);
        }

        public virtual IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate, bool @readonly = true)
        {
            IQueryable<TEntity> query = DbSet;
            if (@readonly)
                query = query.AsNoTracking();
            return query.Where(predicate);
        }

        public async Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.Where(predicate).CountAsync();
        }

        public virtual IQueryable<TEntity> All(bool @readonly = true)
        {
            return @readonly ? DbSet.AsNoTracking() : DbSet;
        }

        public async Task<ValidationResult> AddAsync(TEntity entity, IValidator<TEntity> validation)
        {
            var validateEntityResult = await ValidateEntityAsync(entity, validation);
            if (validateEntityResult.IsValid)
                await _context.AddAsync(entity);
            return validateEntityResult;
        }

        public async Task<ValidationResult> UpdateAsync(TEntity entity, IValidator<TEntity> validation)
        {
            var validateEntityResult = await ValidateEntityAsync(entity, validation);
            if (validateEntityResult.IsValid)
                _context.Update(entity);
            return validateEntityResult;
        }

        public async Task<ValidationResult> DeleteAsync(TEntity entity, IValidator<TEntity> validation)
        {
            var validateEntityResult = await ValidateEntityAsync(entity, validation);
            if (validateEntityResult.IsValid) 
                _context.Remove(entity);
            return validateEntityResult;
        }

        public async Task<ValidationResult> ValidateEntityAsync(TEntity entity, IValidator<TEntity> validation)
        {
            if (validation != null)
            {
                var validationResultEntity = await validation.ValidateAsync(entity);
                return validationResultEntity;
            }
            return new ValidationResult();
        }
    }
}
