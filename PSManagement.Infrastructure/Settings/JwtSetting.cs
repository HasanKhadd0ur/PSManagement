using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSManagement.Infrastructure.Settings
{
    public class JwtSetting
    {
        public const string Section = "JwtSettings";

        public string Audience { get; set; } = null!;
        public string Issuer { get; set; } = null!;
        public string Secret { get; set; } = null!;
        public int ExpireMinutes { get; set; }
    }

}
