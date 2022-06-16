using FinalWebApp.Controllers.Interfaces;
using FinalWebApp.Dto.Requests.User;
using FinalWebApp.Dto.Responses.User;
using FinalWebApp.Filters;
using FinalWebApp.Models;
using FinalWebApp.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase, IUserController
    {
        private IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpPost(""), ValidatedModel]
        public async Task<ActionResult<ApiResponse<bool>>> CreateAsync([FromBody] UserCreateRequest request)
        {
            var result = await userService.CreateAsync(request);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ApiResponse<bool>>> DeleteAsync(string id)
        {
            var result = await userService.DeleteAsync(id);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<UserGetDetailResponse>>> GetDetailAsync(string id)
        {
            var result = await userService.GetDetailAsync(id);
            return Ok(result);
        }

        [HttpGet("")]
        public async Task<ActionResult<ApiResponse<PagePagination<UserGetListResponse>>>> GetListAsync([FromQuery] BaseQueryFilter filter)
        {
            var result = await userService.GetListAsync(filter);
            return Ok(result);
        }

        [HttpPut("{id}"), ValidatedModel]
        public async Task<ActionResult<ApiResponse<bool>>> UpdateAsync([FromBody] UserUpdateRequest resq, string id)
        {
            var result = await userService.UpdateAsync(id, resq);
            return Ok(result);
        }
    }
}
