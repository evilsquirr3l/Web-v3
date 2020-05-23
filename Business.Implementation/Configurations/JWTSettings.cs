using System;

namespace Business.Implementation.Configurations
{
    public class JwtSettings
    {
        public string SecretKey { get; set; }
        
        public string WebAppName { get; set; }

        public string Issuer { get; set; }
        
        public string Audience { get; set; }
        
        public TimeSpan Lifetime { get; set; }
    }
}