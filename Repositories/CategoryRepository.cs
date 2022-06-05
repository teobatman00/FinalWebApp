using FinalWebApp.Context;
using FinalWebApp.Entities;
using FinalWebApp.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalWebApp.Repositories
{
    public class CategoryRepository : BaseRepository<CategoryRepository, CategoryEntity, string>, ICategoryRepository
    {
        public CategoryRepository(ILogger<CategoryRepository> logger, ApplicationContext context) : base(logger, context)
        {
        }
    }
}
