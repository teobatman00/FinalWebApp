using FinalWebApp.Context;
using FinalWebApp.Entities;
using FinalWebApp.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalWebApp.Repositories
{
    public class ProductRepository : BaseRepository<ProductRepository, ProductEntity, string>, IProductRepository
    {
        public ProductRepository(ILogger<ProductRepository> logger, ApplicationContext context) : base(logger, context)
        {
        }
    }
}
