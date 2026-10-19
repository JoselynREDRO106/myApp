using System.Security.Authentication;

namespace MyApp.Crosscutting.Exceptions;

public class UsernameNotFoundException : AuthenticationException
{
    public UsernameNotFoundException(string message) : base(message)
    {
    }
}
