using FinalWebApp.Controllers.Interfaces;
using FinalWebApp.Dto.Requests.Product;
using FinalWebApp.Dto.Responses.Product;
using FinalWebApp.Filters;
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

        [HttpPost("")]
        [ValidatedModel]
        public async Task<ActionResult<ApiResponse<bool>>> CreateAsync([FromBody] ProductCreateRequest request)
        {
            var result = await productService.CreateAsync(request);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ApiResponse<bool>>> DeleteAsync(string id)
        {
            var result = await productService.DeleteAsync(id);
            return Ok(result);
        }

        [HttpGet("id")]
        public async Task<ActionResult<ApiResponse<ProductGetDetailResponse>>> GetDetailAsync(string id)
        {
            var result = await productService.GetDetailAsync(id);
            return Ok(result);
        }

        [HttpGet("")]
        public async Task<ActionResult<ApiResponse<PagePagination<ProductGetDetailResponse>>>> GetListAsync([FromQuery] BaseQueryFilter filter)
        {
            var result = await productService.GetListAsync(filter);
            return Ok(result);
        }

        [HttpPut("{id}")]
        [ValidatedModel]
        public async Task<ActionResult<ApiResponse<bool>>> UpdateAsync([FromBody] ProductUpdateRequest resq, string id)
        {
            var result = await productService.UpdateAsync(id, resq);
            return Ok(result);
        }
    }
}
