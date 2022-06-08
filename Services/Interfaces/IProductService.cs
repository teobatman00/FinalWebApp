using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalWebApp.Dto.Requests.Product;
using FinalWebApp.Dto.Responses.Product;
using FinalWebApp.Models;
using FinalWebApp.Services.BaseInterfaces;

namespace FinalWebApp.Services.Interfaces
{
    public interface IProductService: IGetDetailService<string, ProductGetDetailResponse>,
        IGetListService<ProductGetListResponse, BaseQueryFilter>,
        ICreateService<ProductCreateRequest, bool>,
        IUpdateService<string, ProductUpdateRequest, bool>,
        IDeleteService<string, bool>
    {

    }
}
