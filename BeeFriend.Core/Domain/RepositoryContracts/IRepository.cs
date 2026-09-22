using BeeFriend.Core.Domain.RepositoryContracts.CrudRepositoryContracts;
using BeeFriend.Core.Domain.RepositoryContracts.CrudRepositoryContracts.Getters;


namespace BeeFriend.Core.Domain.RepositoryContracts
{
    public interface IRepository<TEntity, TKey> : 
        IGetAllRepository<TEntity>,
        IGetByIdRepository<TEntity, TKey>,
        IUpdaterRepository<TEntity>,
        IDeleterRepository<TEntity>,
        ICreatorRepository<TEntity>

        where TEntity : class
        where TKey : struct

    {
        
    }
}
