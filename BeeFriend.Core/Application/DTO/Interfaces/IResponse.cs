using System;
using System.Collections.Generic;
using System.Text;

namespace BeeFriend.Core.Application.DTO.Interfaces
{
    public interface IResponse<Tkey>
    {
        Tkey Id { get; }
    }
}
