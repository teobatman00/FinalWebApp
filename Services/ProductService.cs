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
using FinalWebApp.Entities;
using FinalWebApp.Exceptions;
using FinalWebApp.Models;

namespace FinalWebApp.Services
{
    public class ProductService : BaseService<ProductService>, IProductService
    {
        private IProductRepository productRepository;
        private ICategoryRepository _categoryRepository;
        private IOrderRepository _orderRepository;
        public ProductService(IMapper mapper, ILogger<ProductService> logger, IProductRepository productRepository, IOrderRepository orderRepository) : base(mapper, logger)
        {
            this.productRepository = productRepository;
            _orderRepository = orderRepository;
        }

        public Task<ApiResponse<ProductGetDetailResponse>> GetDetailAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse<PagePagination<ProductGetListResponse>>> GetListAsync(BaseQueryFilter filter)
        {
            throw new NotImplementedException();
        }

        public async Task<ApiResponse<bool>> CreateAsync(ProductCreateRequest request)
        {
            var categoryEntity = await _categoryRepository.GetByIdAsync(request.CategoryId);
            if (categoryEntity is null)
                throw new NotFoundDataException($"Category {request.CategoryId} not found");
            var listOrder = await _orderRepository.GetAllByIdAsync(request.OrdersId);
            var createEntity = _mapper.Map<ProductCreateRequest, ProductEntity>(request);
            await productRepository.SaveAsync(createEntity);
            return new ApiResponse<bool>().Success(true);
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
