using BeeFriend.Core.Domain.IdentityEntities;
using BeeFriend.Infrastructure.DbContext;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;


namespace BeeFriend.Infrastructure.IdentityStore
{
    public class ApplicationUserStore 
        : UserStore<ApplicationUser, ApplicationRole, ApplicationDbContext, Guid>
    {
        public ApplicationUserStore(ApplicationDbContext context) 
            : base(context) 
        {
            AutoSaveChanges = false;
        }
    }
}
