using AutoMapper;
using FinalWebApp.Repositories.Interfaces;
using FinalWebApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalWebApp.Dto.Requests.Product;
using FinalWebApp.Dto.Responses.Product;
using FinalWebApp.Models;

namespace FinalWebApp.Services
{
    public class ProductService : BaseService<ProductService>, IProductService
    {
        private IProductRepository productRepository;
        private ICategoryRepository _categoryRepository;
        public ProductService(IMapper mapper, ILogger<ProductService> logger, IProductRepository productRepository) : base(mapper, logger)
        {
            this.productRepository = productRepository;
        }

        public Task<ApiResponse<ProductGetDetailResponse>> GetDetailAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse<PagePagination<ProductGetListResponse>>> GetListAsync(BaseQueryFilter filter)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse<bool>> CreateAsync(ProductCreateRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse<bool>> UpdateAsync(string id, ProductUpdateRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse<bool>> DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }
    }
}
