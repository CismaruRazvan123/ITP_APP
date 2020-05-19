using ITP_App.ApplicationLogic.Abstractions;
using ITP_App.ApplicationLogic.DataModel;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ITP_App.DataAccess
{
    public class ClientRepository : BaseRepository<Client>, IClientRepository
    {
        public ClientRepository(ITP_AppDbContext dbContext) : base(dbContext)
        {

        }

        public Client GetClientByUserId(Guid userId)
        {
            return dbContext.Client
                            .Where(client => client.UserId == userId)
                            .FirstOrDefault();
        }
    }
}
