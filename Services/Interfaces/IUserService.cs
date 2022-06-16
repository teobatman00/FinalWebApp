using FinalWebApp.Dto.Requests.User;
using FinalWebApp.Dto.Responses.User;
using FinalWebApp.Models;
using FinalWebApp.Services.BaseInterfaces;

namespace FinalWebApp.Services.Interfaces;

public interface IUserService: IGetListService<UserGetListResponse, BaseQueryFilter>,
    IGetDetailService<string, UserGetDetailResponse>,
    ICreateService<UserCreateRequest, bool>,
    IUpdateService<string, UserUpdateRequest, bool>,
    IDeleteService<string, bool>
{
    
}