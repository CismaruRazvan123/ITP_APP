using ITP_App.ApplicationLogic.DataModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITP_App.DataAccess
{
    public class ITP_AppDbContext : DbContext
    {
        public ITP_AppDbContext(DbContextOptions<ITP_AppDbContext> options) : base(options) 
        {
        
        }
        public DbSet<Client> Client { get; set; }
        public DbSet<Admin> Admin { get; set; }
        public DbSet<Car> Car { get; set; }
        public DbSet<Owner> Owner { get; set; }
        public DbSet<Rules> Rule { get; set; }
        public DbSet<Review> Review { get; set; }

    }
}
