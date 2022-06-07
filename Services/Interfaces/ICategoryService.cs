using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalWebApp.Dto.Requests.Category;
using FinalWebApp.Dto.Responses.Category;
using FinalWebApp.Models;
using FinalWebApp.Services.BaseInterfaces;

namespace FinalWebApp.Services.Interfaces
{
    public interface ICategoryService: 
        IGetListService<CategoryGetListResponse, BaseQueryFilter>,
        ICreateService<CategoryCreateRequest, bool>,
        IGetDetailService<string, CategoryGetDetailResponse>,
        IDeleteService<string, bool>,
        IUpdateService<string, CategoryUpdateRequest, bool>
    {

    }
}
