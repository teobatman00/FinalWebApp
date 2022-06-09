using AutoMapper;
using FinalWebApp.Services.Interfaces;

namespace FinalWebApp.Services;

public class UserService: BaseService<UserService>, IUserService
{
    public UserService(IMapper mapper, ILogger<UserService> logger) : base(mapper, logger)
    {
    }
}