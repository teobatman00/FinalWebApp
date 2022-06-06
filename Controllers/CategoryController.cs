﻿using FinalWebApp.Controllers.Interfaces;
using FinalWebApp.Dto.Requests.Category;
using FinalWebApp.Dto.Responses.Category;
using FinalWebApp.Filters;
using FinalWebApp.Models;
using FinalWebApp.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase, ICategoryController
    {

        private ICategoryService categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        [HttpPost("")]
        [ValidatedModel]
        public async Task<ActionResult<ApiResponse<bool>>> CreateAsync([FromBody] CategoryCreateRequest request)
        {
            var result = await categoryService.CreateAsync(request);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public Task<ActionResult<ApiResponse<bool>>> DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        [HttpGet("{id}")]
        public Task<ActionResult<ApiResponse<CategoryGetDetailResponse>>> GetDetailAsync(string id)
        {
            throw new NotImplementedException();
        }

        [HttpGet("")]
        [ValidatedModel]
        public async Task<ActionResult<ApiResponse<PagePagination<CategoryGetListResponse>>>> GetListAsync([FromQuery] BaseQueryFilter filter)
        {
            var result = await categoryService.GetListAsync(filter);
            return Ok(result);
        }

        [HttpPut("{id}")]
        [ValidatedModel]
        public Task<ActionResult<ApiResponse<bool>>> UpdateAsync([FromBody] CategoryUpdateRequest resq, string id)
        {
            throw new NotImplementedException();
        }
    }
}
