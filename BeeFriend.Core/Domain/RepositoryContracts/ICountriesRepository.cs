using BeeFriend.Core.Domain.Entities;
using BeeFriend.Core.Domain.RepositoryContracts.CrudRepositoryContracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeeFriend.Core.Domain.RepositoryContracts
{
    public interface ICountriesRepository : 
        IAllGetterRepository<Country>,
        ISingleGetterRepository<Country, int>
    {
    }
}
