using AutoMapper;
using FinalWebApp.Repositories.Interfaces;
using FinalWebApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalWebApp.Services
{
    public class ProductService : BaseService<ProductService>, IProductService
    {
        private IProductRepository productRepository;
        public ProductService(IMapper mapper, ILogger<ProductService> logger, IProductRepository productRepository) : base(mapper, logger)
        {
            this.productRepository = productRepository;
        }
    }
}
