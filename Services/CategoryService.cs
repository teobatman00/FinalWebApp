using FinalWebApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FinalWebApp.Dto.Requests.Category;
using FinalWebApp.Dto.Responses.Category;
using FinalWebApp.Models;
using FinalWebApp.Repositories.Interfaces;
using FinalWebApp.Entities;
using FinalWebApp.Exceptions;
using FinalWebApp.Utils;

namespace FinalWebApp.Services
{
    public class CategoryService: BaseService<CategoryService>, ICategoryService
    {
        private ICategoryRepository _categoryRepository;
        public CategoryService(IMapper mapper, ILogger<CategoryService> logger, ICategoryRepository categoryRepository) : base(mapper, logger)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<ApiResponse<PagePagination<CategoryGetListResponse>>> GetListAsync(BaseQueryFilter filter)
        {
            _logger.LogInformation("Getting list");
            var listEntity = await _categoryRepository.GetAllAsync(PageRequest.Of(filter.Page, filter.Size));
            var listResponse = _mapper.Map<IEnumerable<CategoryEntity>, IEnumerable<CategoryGetListResponse>>(listEntity);
            return new ApiResponse<PagePagination<CategoryGetListResponse>>().Success(
                    new PagePagination<CategoryGetListResponse>
                    {
                        Content = listResponse,
                        First = 1,
                        Last = filter.Page,
                        TotalElements = await _categoryRepository.CountAllAsync()
                    }
                    );
        }

        public async Task<ApiResponse<bool>> CreateAsync(CategoryCreateRequest request)
        {
            _logger.LogInformation("Creating category");
            var entity = _mapper.Map<CategoryCreateRequest, CategoryEntity>(request);
            await _categoryRepository.SaveAsync(entity);
            return new ApiResponse<bool>().Success(true);
        }

        public async Task<ApiResponse<CategoryGetDetailResponse>> GetDetailAsync(string id)
        {
            _logger.LogInformation($"Getting category by id {id}");
            var entity = await _categoryRepository.GetByIdAsync(id);
            if (entity is null)
                throw new NotFoundDataException("Cannot find category");
            var result = _mapper.Map<CategoryEntity, CategoryGetDetailResponse>(entity);
            return new ApiResponse<CategoryGetDetailResponse>().Success(result);
        }

        public async Task<ApiResponse<bool>> DeleteAsync(string id)
        {
            _logger.LogInformation("Deleting category");
            var entity = await _categoryRepository.GetByIdAsync(id);
            if (entity is null)
                throw new NotFoundDataException("Cannot find category");
            await _categoryRepository.DeleteAsync(entity);
            return new ApiResponse<bool>().Success(true);
        }

        public async Task<ApiResponse<bool>> UpdateAsync(string id, CategoryUpdateRequest request)
        {
            _logger.LogInformation("Finding category");
            var entity = await _categoryRepository.GetByIdAsync(id);
            if (entity is null)
                throw new NotFoundDataException("Cannot find category");
            var updateEntity = _mapper.Map(request, entity);
            await _categoryRepository.SaveAsync(updateEntity);
            return new ApiResponse<bool>().Success(true);
        }
    }
}
