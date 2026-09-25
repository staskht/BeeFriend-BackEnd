using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace BeeFriend.Core.Application.DTO
{
    public abstract record ResponseBase<Tkey>
        where Tkey : struct
    {
        [JsonIgnore]
        public abstract Tkey Id {  get; }
    }
}
