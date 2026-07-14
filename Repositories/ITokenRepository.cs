using Microsoft.AspNetCore.Identity;

namespace student_marking_system.Repositories
{
    public interface ITokenRepository
    {
        string CreateJwtToken(IdentityUser user, List<string> roles);
    }
}
