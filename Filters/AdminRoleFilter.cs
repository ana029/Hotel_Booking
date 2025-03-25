using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HotelBookingAPI.Filters
{
    public class AdminRoleFilter : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = context.HttpContext.User;

            if (!user.HasClaim(x => x.Type == ClaimTypes.Role && x.Value == "Admin"))
            {
                context.Result = new ForbidResult();
            }
        }
    }
}
