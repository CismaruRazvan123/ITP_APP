using ITP_App.ApplicationLogic.Abstractions;
using ITP_App.ApplicationLogic.DataModel;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ITP_App.DataAccess
{
    public class RuleRepository : BaseRepository<Rules>, IRuleRepository
    {
        public RuleRepository(ITP_AppDbContext dbContext) : base(dbContext)
        {


        }
    }
}
