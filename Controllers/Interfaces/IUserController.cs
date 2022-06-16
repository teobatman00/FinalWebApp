using FinalWebApp.Controllers.BaseInterfaces;
using FinalWebApp.Dto.Requests.User;
using FinalWebApp.Dto.Responses.User;
using FinalWebApp.Models;

namespace FinalWebApp.Controllers.Interfaces;

public interface IUserController: IGetListController<UserGetListResponse, BaseQueryFilter>,
    IGetDetailController<string, UserGetDetailResponse>,
    ICreateController<UserCreateRequest, bool>,
    IUpdateController<string, UserUpdateRequest, bool>,
    IDeleteController<string, bool>
{
    
}