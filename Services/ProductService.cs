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
        public ProductService(IMapper mapper, ILogger<ProductService> logger, IProductRepository productRepository, IOrderRepository orderRepository, ICategoryRepository categoryRepository) : base(mapper, logger)
        {
            this.productRepository = productRepository;
            _orderRepository = orderRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task<ApiResponse<ProductGetDetailResponse>> GetDetailAsync(string id)
        {
            _logger.LogInformation("Get product detail");
            var entity = await productRepository.GetByIdAsync(id);
            if (entity is null)
                throw new NotFoundDataException("Product not found");
            var response = _mapper.Map<ProductEntity, ProductGetDetailResponse>(entity);
            return new ApiResponse<ProductGetDetailResponse>().Success(response);
        }

        public async Task<ApiResponse<PagePagination<ProductGetListResponse>>> GetListAsync(BaseQueryFilter filter)
        {
            _logger.LogInformation("Get List product");
            var listEntity = await productRepository.GetAllAsync(PageRequest.Of(filter.Page, filter.Size));
            var listResponse = _mapper.Map<IEnumerable<ProductEntity>, IEnumerable<ProductGetListResponse>>(listEntity).ToList();
            return new ApiResponse<PagePagination<ProductGetListResponse>>().Success(
                    new PagePagination<ProductGetListResponse>
                    {
                        Content = listResponse,
                        First = 1,
                        Last = filter.Page,
                        TotalElements = await _categoryRepository.CountAllAsync()
                    }
                );
        }

        public async Task<ApiResponse<bool>> CreateAsync(ProductCreateRequest request)
        {
            var isAvailableSlug = await productRepository.ExistsByAsync(s => s.Slugs.Equals(request.Slugs));
            if (isAvailableSlug)
                throw new BadRequestException("Slug is duplicate");
            var categoryEntity = await _categoryRepository.GetByIdAsync(request.CategoryId);
            if (categoryEntity is null)
                throw new NotFoundDataException($"Category {request.CategoryId} not found");
            IEnumerable<OrderEntity> listOrder = new List<OrderEntity>();
            if (request.OrdersId is not null)
                listOrder = await _orderRepository.GetAllByIdAsync(request.OrdersId);
            var createEntity = _mapper.Map<ProductCreateRequest, ProductEntity>(request);
            createEntity.Category = categoryEntity;
            createEntity.Orders = listOrder.ToList();
            await productRepository.SaveAsync(createEntity);
            return new ApiResponse<bool>().Success(true);
        }

        public async Task<ApiResponse<bool>> UpdateAsync(string id, ProductUpdateRequest request)
        {
            var availableEntity = await productRepository.GetByIdAsync(id);
            if (availableEntity is null)
                throw new NotFoundDataException("Product not found");
            var isAvailableSlug = await productRepository.ExistsByAsync(s => s.Slugs.Equals(request.Slugs));
            if (isAvailableSlug)
                throw new BadRequestException("Slug is duplicate");
            var categoryEntity = await _categoryRepository.GetByIdAsync(request.CategoryId);
            if (categoryEntity is null)
                throw new NotFoundDataException($"Category {request.CategoryId} not found");
            var listOrderEntity = await _orderRepository.GetAllByIdAsync(request.OrdersId);
            var updateEntity = _mapper.Map(request, availableEntity);
            await productRepository.SaveAsync(updateEntity);

            return new ApiResponse<bool>().Success(true);
        }

        public async Task<ApiResponse<bool>> DeleteAsync(string id)
        {
            var availableEntity = await productRepository.GetByIdAsync(id);
            if (availableEntity is null)
                throw new NotFoundDataException("Product not found");
            await productRepository.DeleteAsync(availableEntity);
            return new ApiResponse<bool>().Success(true);
        }
    }
}
