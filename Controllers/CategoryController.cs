using FinalWebApp.Controllers.Interfaces;
using FinalWebApp.Dto.Requests.Category;
using FinalWebApp.Dto.Responses.Category;
using FinalWebApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase, ICategoryController
    {
        public ActionResult<Task<ApiResponse<bool>>> CreateAsync([FromBody] CategoryCreateRequest request)
        {
            throw new NotImplementedException();
        }

        public ActionResult<Task<ApiResponse<bool>>> DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public ActionResult<Task<ApiResponse<CategoryGetDetailResponse>>> GetDetailAsync(string id)
        {
            throw new NotImplementedException();
        }

        public ActionResult<Task<ApiResponse<PagePagination<CategoryGetListResponse>>>> GetListAsync([FromQuery] BaseQueryFilter filter)
        {
            throw new NotImplementedException();
        }

        public ActionResult<Task<ApiResponse<bool>>> UpdateAsync([FromBody] CategoryUpdateRequest resq)
        {
            throw new NotImplementedException();
        }
    }
}
