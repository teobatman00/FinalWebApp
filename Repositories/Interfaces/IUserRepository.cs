using FinalWebApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalWebApp.Repositories.Interfaces
{
    public interface IUserRepository: IBaseRepository<UserEntity, string>
    {

    }
}
