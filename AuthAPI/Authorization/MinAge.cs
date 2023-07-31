using Microsoft.AspNetCore.Authorization;

namespace AuthAPI.Authorization;

public class MinAge : IAuthorizationRequirement
{
    public int Age { get; set; }

    public MinAge(int v)
    {
        Age = v;
    }
}