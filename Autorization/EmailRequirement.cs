using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Autorization
{
    public class EmailRequrement : IAuthorizationRequirement
    {
        public string EmailSuffix { get; }
        public EmailRequrement(string emailSuffix)
        {
            EmailSuffix= emailSuffix;
        }
    }
}
