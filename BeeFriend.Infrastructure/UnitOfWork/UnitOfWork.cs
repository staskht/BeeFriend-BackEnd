using BeeFriend.Core.Domain.RepositoryContracts;
using BeeFriend.Core.Domain.UnitOfWorkContract;
using BeeFriend.Infrastructure.DbContext;
using BeeFriend.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeeFriend.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IUserProfileRepository UserProfiles {  get; }


        public UnitOfWork(
            ApplicationDbContext context, 
            IUserProfileRepository userProfileRepository)
        {
            _context = context;
            UserProfiles = userProfileRepository;
             
        }
        public Task CommitAsync()
        {
            return _context.SaveChangesAsync();
        }
    }
}
