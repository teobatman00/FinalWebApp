using FinalWebApp.Context;
using FinalWebApp.Entities;
using FinalWebApp.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalWebApp.Repositories
{
    public class UserRoleRepository : BaseRepository<UserRoleRepository, UserRoleEntity, string>, IUserRoleRepository
    {
        public UserRoleRepository(ILogger<UserRoleRepository> logger, ApplicationContext context) : base(logger, context)
        {
        }
    }
}
