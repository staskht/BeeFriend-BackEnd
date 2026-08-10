using System;
using System.Collections.Generic;
using System.Text;

namespace BeeFriend.Core.Options
{
    public class RefreshTokenOptions
    {
        public const string SectionName = "RefreshToken";
        public int ExpiryDays {  get; set; }
    }
}
