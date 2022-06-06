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

namespace FinalWebApp.Services
{
    public class CategoryService: BaseService<CategoryService>, ICategoryService
    {
        private ICategoryRepository _categoryRepository;
        public CategoryService(IMapper mapper, ILogger<CategoryService> logger, ICategoryRepository categoryRepository) : base(mapper, logger)
        {
            _categoryRepository = categoryRepository;
        }

        public Task<ApiResponse<PagePagination<CategoryGetListResponse>>> GetListAsync(BaseQueryFilter filter)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse<bool>> CreateAsync(CategoryCreateRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
