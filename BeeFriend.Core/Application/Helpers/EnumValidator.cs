using System;
using System.Collections.Generic;
using System.Text;

namespace BeeFriend.Core.Application.Helpers
{
    internal static class EnumValidator
    {
        public static bool IsValidEnum<TEnum>(TEnum? value)
            where TEnum : struct, Enum
        {
            return !value.HasValue || Enum.IsDefined(value.Value);
        }
    }
}
