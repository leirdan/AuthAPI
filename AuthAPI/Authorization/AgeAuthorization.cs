using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace AuthAPI.Authorization
{
    public class AgeAuthorization : AuthorizationHandler<MinAge>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, MinAge requirement)
        {
            var userBirth = context.User.FindFirst(cl => cl.Type == ClaimTypes.DateOfBirth);
            if (userBirth is null)
            {
                return Task.CompletedTask;
            }
            var date = Convert.ToDateTime(userBirth.Value);
            var age = DateTime.Today.Year - date.Year;
            // Caso o usuário não tenha completado ano ainda
            if (date > DateTime.Today.AddYears(-age))
            {
                age--;
            }
            if (age >= requirement.Age)

            {
                context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }
    }
}
