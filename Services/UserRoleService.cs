using AutoMapper;
using FinalWebApp.Services.Interfaces;

namespace FinalWebApp.Services;

public class UserRoleService: BaseService<UserRoleService>, IUserRoleService
{
    public UserRoleService(IMapper mapper, ILogger<UserRoleService> logger) : base(mapper, logger)
    {
    }
}