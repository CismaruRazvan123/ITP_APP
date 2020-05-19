using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ITP_App.Data
{
    public class ITP_AppContext : IdentityDbContext<IdentityUser>
    {
        public ITP_AppContext(DbContextOptions<ITP_AppContext> options)
            : base(options)
        {
        }
    }
}
