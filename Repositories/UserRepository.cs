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
    public class UserRepository : BaseRepository<UserRepository, UserEntity, string>, IUserRepository
    {
        public UserRepository(ILogger<UserRepository> logger, ApplicationContext context) : base(logger, context)
        {
        }
    }
}
