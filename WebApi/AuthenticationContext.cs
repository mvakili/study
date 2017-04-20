using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace WebApi
{
    public class AuthenticationContext : IdentityDbContext<IdentityUser>
    {
        public AuthenticationContext()
            : base(@"data source=(LocalDb)\MSSQLLocalDB;initial catalog=Logic.Model;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework")
        {
        }
    }
}