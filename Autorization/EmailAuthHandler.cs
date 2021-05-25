using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Autorization
{
    public class EmailAuthHandler : AuthorizationHandler<EmailRequrement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, EmailRequrement requirement)
        {
            try
            {
                if (context.User.Identity.Name.EndsWith(requirement.EmailSuffix))
                {
                    context.Succeed(requirement);
                }
            }
            catch
            {
                Console.WriteLine("Error in EmailAuthHandler");
            }

            return Task.CompletedTask;
        }
    }
}
