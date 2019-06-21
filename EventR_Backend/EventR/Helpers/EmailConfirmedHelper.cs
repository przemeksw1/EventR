using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventR.Helpers
{
    public class EmailConfirmedHelper : AuthorizeAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = context.HttpContext.User;
            if (!user.Identity.IsAuthenticated)
                return;

            if (user.Claims.Where(c => c.Type == "Confirmed").Select(c => c.Value).SingleOrDefault() != "True")
                context.Result = new ForbidResult();
        }
    }
}
