using FinalWebApp.Controllers.Interfaces;
using FinalWebApp.Dto.Requests.Contact;
using FinalWebApp.Dto.Responses.Contact;
using FinalWebApp.Filters;
using FinalWebApp.Models;
using FinalWebApp.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase, IContactController
    {
        private IContactService contactService;

        public ContactController(IContactService contactService)
        {
            this.contactService = contactService;
        }

        [HttpPost("")]
        [ValidatedModel]
        public async Task<ActionResult<ApiResponse<bool>>> CreateAsync([FromBody] ContactCreateRequest request)
        {
            var result = await contactService.CreateAsync(request);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ApiResponse<bool>>> DeleteAsync(string id)
        {
            var result = await contactService.DeleteAsync(id);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<ContactGetDetailResponse>>> GetDetailAsync(string id)
        {
            var result = await contactService.GetDetailAsync(id);
            return Ok(result);
        }

        [HttpGet("")]
        public async Task<ActionResult<ApiResponse<PagePagination<ContactGetListResponse>>>> GetListAsync([FromQuery] BaseQueryFilter filter)
        {
            var result = await contactService.GetListAsync(filter);
            return Ok(result);
        }

        [HttpPut("{id}")]
        [ValidatedModel]
        public async Task<ActionResult<ApiResponse<bool>>> UpdateAsync([FromBody] ContactUpdateRequest resq, string id)
        {
            var result = await contactService.UpdateAsync(id, resq);
            return Ok(result);
        }
    }
}
