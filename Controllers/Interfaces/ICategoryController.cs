using FinalWebApp.Controllers.BaseInterfaces;
using FinalWebApp.Dto.Requests.Category;
using FinalWebApp.Dto.Responses.Category;
using FinalWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalWebApp.Controllers.Interfaces
{
    public interface ICategoryController : 
        IGetListController<CategoryGetListResponse, BaseQueryFilter>,
        IGetDetailController<string, CategoryGetDetailResponse>,
        ICreateController<CategoryCreateRequest, bool>,
        IUpdateController<string, CategoryUpdateRequest, bool>,
        IDeleteController<string, bool>
    {
    }
}
