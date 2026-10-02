using AutoMapper;
using BeeFriend.Core.Application.Results;
using BeeFriend.Core.Application.ServiceContracts;
using BeeFriend.Core.Domain.RepositoryContracts;
using BeeFriend.Core.Domain.UnitOfWorkContract;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeeFriend.Core.Application.Service
{
    public class CrudService<TEntity, TRequest, TResponse, TKey, TRepository> :
        ICrudService<TRequest, TResponse, TKey>

        where TEntity :class
        where TRequest : class
        where TResponse : class
        where TKey : struct
        where TRepository : IRepository<TEntity, TKey>
    {
        protected readonly TRepository _repository;
        protected readonly IMapper _mapper;
        protected readonly IUnitOfWork _unitOfWork;

        public CrudService(
            TRepository repository,
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public virtual async Task<Result<TResponse>> AddAsync(
            TRequest requestDto, 
            CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(requestDto);

            var entity = _mapper.Map<TEntity>(requestDto);

            await _repository.AddAsync(entity, cancellationToken);
            await _unitOfWork.CommitAsync(cancellationToken);

            return _mapper.Map<TResponse>(entity);
        }

        public virtual async Task<Result> DeleteByIdAsync(
            TKey id, 
            CancellationToken cancellationToken)
        {
            var result = await FindEntityAsync(id, cancellationToken);

            if (result.IsFailure)
                return result.Error!;

            var entity = result.Value;

            _repository.Delete(entity!);

            await _unitOfWork.CommitAsync(cancellationToken);

            return Result.Success();
        }

        public virtual async Task<Result<IEnumerable<TResponse>>> GetAllAsync(CancellationToken cancellationToken)
        {
            var entities = await _repository.GetAllAsync(cancellationToken);

            return _mapper.Map<List<TResponse>>(entities);
        }

        public virtual async Task<Result<TResponse>> GetByIdAsync(
            TKey id, 
            CancellationToken cancellationToken)
        {
            var result = await FindEntityAsync(id, cancellationToken);

            if (result.IsFailure)
                return result.Error!;

            var entity = result.Value;

            return _mapper.Map<TResponse>(entity);
        }

        public virtual async Task<Result<TResponse>> UpdateAsync(
            TKey id, 
            TRequest requestDto, 
            CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(requestDto);

            var result = await FindEntityAsync(id, cancellationToken);

            if (result.IsFailure)
                return result.Error!;

            var entity = result.Value;

            _mapper.Map(requestDto, entity);

            _repository.Update(entity!);

            await _unitOfWork.CommitAsync(cancellationToken);

            return _mapper.Map<TResponse>(entity);
        }

        protected async Task<Result<TEntity>> FindEntityAsync(
            TKey id, 
            CancellationToken cancellationToken)
        {
            if (EqualityComparer<TKey>.Default.Equals(id, default))
                return Errors.InvalidId("InvalidId", "Invalid id value.");

            var entity = await _repository.GetByIdAsync(id, cancellationToken);

            if (entity == null)
                return Errors.EntityNotFound("EntityNotFound", $"Entity not found");

            return entity;
        }
    }
}
