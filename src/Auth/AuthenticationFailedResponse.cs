using System.Collections.Generic;

namespace Forum.Auth
{
    public class AuthenticationFailedResponse
    {
        public IEnumerable<string> Errors { get; set; }
    }
}