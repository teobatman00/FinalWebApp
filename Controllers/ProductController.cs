using FinalWebApp.Controllers.Interfaces;
using FinalWebApp.Dto.Requests.Product;
using FinalWebApp.Dto.Responses.Product;
using FinalWebApp.Models;
using FinalWebApp.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase, IProductController
    {

        private IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        public Task<ActionResult<ApiResponse<bool>>> CreateAsync([FromBody] ProductCreateRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<ApiResponse<bool>>> DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<ApiResponse<ProductGetDetailResponse>>> GetDetailAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<ApiResponse<PagePagination<ProductGetDetailResponse>>>> GetListAsync([FromQuery] BaseQueryFilter filter)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<ApiResponse<bool>>> UpdateAsync([FromBody] ProductUpdateRequest resq, string id)
        {
            throw new NotImplementedException();
        }
    }
}
