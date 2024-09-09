using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSManagement.Api.Settings
{
    public class CorsSettings
    {
        public const string SectionName ="CorsSettings";
        public Policy[] Policies { get; set; } = null!;
    }

    public class Policy
    {

        public string PolicyName { get; set; }= string.Empty;
        public string AllowedOrigins { get; set; }= string.Empty;
        
    }
}
