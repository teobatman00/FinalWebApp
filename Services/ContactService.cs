using AutoMapper;
using FinalWebApp.Dto.Requests.Contact;
using FinalWebApp.Dto.Responses.Category;
using FinalWebApp.Dto.Responses.Contact;
using FinalWebApp.Entities;
using FinalWebApp.Exceptions;
using FinalWebApp.Models;
using FinalWebApp.Repositories.Interfaces;
using FinalWebApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalWebApp.Services
{
    public class ContactService : BaseService<ContactService>, IContactService
    {
        private IContactRepository contactRepository;
        public ContactService(IMapper mapper, ILogger<ContactService> logger, IContactRepository contactRepository) : base(mapper, logger)
        {
            this.contactRepository = contactRepository;
        }

        public async Task<ApiResponse<bool>> CreateAsync(ContactCreateRequest request)
        {
            _logger.LogInformation("Creating new contact");
            var entity = _mapper.Map<ContactCreateRequest, ContactEntity>(request);
            await contactRepository.SaveAsync(entity);
            return new ApiResponse<bool>().Success(true);
        }

        public async Task<ApiResponse<bool>> DeleteAsync(string id)
        {
            var entity = await contactRepository.GetByIdAsync(id);
            if (entity is null)
            {
                throw new NotFoundDataException("Contact is not available");
            }
            _logger.LogInformation("Deleting contact");
            await contactRepository.DeleteAsync(entity);
            return new ApiResponse<bool>().Success(true);
        }

        public async Task<ApiResponse<ContactGetDetailResponse>> GetDetailAsync(string id)
        {
            var entity = await contactRepository.GetByIdAsync(id);
            if (entity is null)
                throw new NotFoundDataException("Contact is not available");
            var response = _mapper.Map<ContactEntity, ContactGetDetailResponse>(entity);
            return new ApiResponse<ContactGetDetailResponse>().Success(response);
        }

        public async Task<ApiResponse<PagePagination<ContactGetListResponse>>> GetListAsync(BaseQueryFilter filter)
        {
            var listEntity = await contactRepository.GetAllAsync(PageRequest.Of(filter.Page, filter.Size));
            var listResponse = _mapper.Map<IEnumerable<ContactEntity>, IEnumerable<ContactGetListResponse>>(listEntity);
            return new ApiResponse<PagePagination<ContactGetListResponse>>().Success(
                    new PagePagination<ContactGetListResponse>
                    {
                        Content = listResponse,
                        First = 1,
                        Last = listResponse.Count()
                    }
                );
        }

        public async Task<ApiResponse<bool>> UpdateAsync(string id, ContactUpdateRequest request)
        {
            var entity = await contactRepository.GetByIdAsync(id);
            if (entity is null)
                throw new NotFoundDataException("Contact is not available");
            var updateEntity = _mapper.Map(request, entity);
            await contactRepository.SaveAsync(updateEntity);
            return new ApiResponse<bool>().Success(true);
        }
    }
}
