using ITP_App.ApplicationLogic.Abstractions;
using ITP_App.ApplicationLogic.DataModel;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ITP_App.DataAccess
{
    public class AdminRepository : BaseRepository<Admin>, IAdminRepository
    {
        public AdminRepository(ITP_AppDbContext dbContext) : base(dbContext)
        {

        }

        public Admin GetAdminByUserId(Guid userId)
        {
            return dbContext.Admin
                            .Where(admin => admin.UserId == userId)
                            .FirstOrDefault();
        }
    }
}
