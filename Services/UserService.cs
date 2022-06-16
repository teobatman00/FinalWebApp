using AutoMapper;
using FinalWebApp.Dto.Requests.User;
using FinalWebApp.Dto.Responses.User;
using FinalWebApp.Entities;
using FinalWebApp.Exceptions;
using FinalWebApp.Models;
using FinalWebApp.Repositories.Interfaces;
using FinalWebApp.Services.Interfaces;

namespace FinalWebApp.Services;

public class UserService: BaseService<UserService>, IUserService
{
    private IUserRepository userRepository;
    public UserService(IMapper mapper, ILogger<UserService> logger, IUserRepository userRepository) : base(mapper, logger)
    {
        this.userRepository = userRepository;
    }

    public async Task<ApiResponse<bool>> CreateAsync(UserCreateRequest request)
    {
        var existUsername = await userRepository.ExistsByAsync(s => s.Username.Equals(request.Username));
        if (existUsername)
            throw new BadRequestException("Username is exists");
        var entity = _mapper.Map<UserCreateRequest, UserEntity>(request);
        await userRepository.SaveAsync(entity);
        return new ApiResponse<bool>().Success(true);
    }

    public async Task<ApiResponse<bool>> DeleteAsync(string id)
    {
        var entity = await userRepository.GetByIdAsync(id);
        if (entity is null)
            throw new NotFoundDataException("Not found user");
        await userRepository.DeleteAsync(entity);
        return new ApiResponse<bool>().Success(true);
    }

    public async Task<ApiResponse<UserGetDetailResponse>> GetDetailAsync(string id)
    {
        var entity = await userRepository.GetByIdAsync(id);
        if (entity is null)
            throw new NotFoundDataException("User is not available");
        var response = _mapper.Map<UserEntity, UserGetDetailResponse>(entity);
        return new ApiResponse<UserGetDetailResponse>().Success(response);
    }

    public async Task<ApiResponse<PagePagination<UserGetListResponse>>> GetListAsync(BaseQueryFilter filter)
    {
        var listEntity = await userRepository.GetAllAsync(PageRequest.Of(filter.Page, filter.Size));
        var listResponse = _mapper.Map<IEnumerable<UserEntity>, IEnumerable<UserGetListResponse>>(listEntity);
        return new ApiResponse<PagePagination<UserGetListResponse>>().Success(
                new PagePagination<UserGetListResponse>
                {
                    Content = listResponse,
                    First = 1,
                    Last = filter.Page,
                    TotalElements = await userRepository.CountAllAsync()
                }
            );
    }

    public async Task<ApiResponse<bool>> UpdateAsync(string id, UserUpdateRequest request)
    {
        var entity = await userRepository.GetByIdAsync(id);
        if (entity is null)
            throw new NotFoundDataException("User is not available");
        var updateEntity = _mapper.Map(request, entity);
        await userRepository.SaveAsync(updateEntity);
        return new ApiResponse<bool>().Success(true);
    }
}