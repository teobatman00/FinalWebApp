using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalWebApp.Controllers.Interfaces;
using FinalWebApp.Dto.Requests.Order;
using FinalWebApp.Dto.Responses.Order;
using FinalWebApp.Filters;
using FinalWebApp.Models;
using FinalWebApp.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase, IOrderController
    {
        private IOrderService orderService;

        public OrderController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        [HttpPost("")]
        [ValidatedModel]
        public async Task<ActionResult<ApiResponse<bool>>> CreateAsync([FromBody] OrderCreateRequest request)
        {
            var result = await orderService.CreateAsync(request);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ApiResponse<bool>>> DeleteAsync(string id)
        {
            var result = await orderService.DeleteAsync(id);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<OrderGetDetailResponse>>> GetDetailAsync(string id)
        {
            var result = await orderService.GetDetailAsync(id);
            return Ok(result);
        }

        [HttpGet("")]
        public async Task<ActionResult<ApiResponse<PagePagination<OrderGetListResponse>>>> GetListAsync([FromQuery] BaseQueryFilter filter)
        {
            var result = await orderService.GetListAsync(filter);
            return Ok(result);
        }

        [HttpPut("{id}")]
        [ValidatedModel]
        public async Task<ActionResult<ApiResponse<bool>>> UpdateAsync([FromBody] OrderUpdateRequest resq, string id)
        {
            var result = await orderService.UpdateAsync(id, resq);
            return Ok(result);
        }
    }
}
