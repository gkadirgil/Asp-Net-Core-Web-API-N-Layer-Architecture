using NLayerProject.Core.Repositories;
using NLayerProject.Core.Services;
using NLayerProject.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

using System.Text;
using System.Threading.Tasks;

namespace NLayerProject.Service.Services
{
    public class ServiceGeneric<TEntity> : IServicesGeneric<TEntity> where TEntity : class
    {
        public readonly IUnitOfWorks _unitOfWorks;
        private readonly IRepositoryGeneric<TEntity> _repositoryGeneric; //RepositoryGeneric içindeki hazır metotları

        public ServiceGeneric(IUnitOfWorks unitOfWorks, IRepositoryGeneric<TEntity> repositoryGeneric)
        {
            _unitOfWorks = unitOfWorks;  //Database kaydı yapar.
            _repositoryGeneric = repositoryGeneric;  //RepositoryGeneric içindeki hazır metotları çeker.
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await _repositoryGeneric.AddAsync(entity);

            await _unitOfWorks.CommitAsync();

            return entity;
        }

        public async Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await _repositoryGeneric.AddRangeAsync(entities);

            await _unitOfWorks.CommitAsync();

            return entities;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _repositoryGeneric.GetAllAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _repositoryGeneric.GetByIdAsync(id);
        }

        public void Remove(TEntity entity)
        {
            _repositoryGeneric.Remove(entity);

            _unitOfWorks.Commit();
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            _repositoryGeneric.RemoveRange(entities);

            _unitOfWorks.Commit();
        }

        public async Task<TEntity> SingleOtDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _repositoryGeneric.SingleOtDefaultAsync(predicate);
        }

        public TEntity Update(TEntity entity)
        {
            var updateEntity = _repositoryGeneric.Update(entity);

            _unitOfWorks.Commit();

            return updateEntity;
        }

        public async Task<IEnumerable<TEntity>> Where(Expression<Func<TEntity, bool>> predicate)
        {
            return await _repositoryGeneric.Where(predicate);
        }
    }
}
