using System.Collections.Generic;

namespace TestProject.IntegrationTestsApi.Types
{
    public class LoginResponse
    {
        public string Token { get; set; } = default!;
        public string UserName { get; set; } = default!;
        public ICollection<string> Roles { get; set; } = default!;
    }
}