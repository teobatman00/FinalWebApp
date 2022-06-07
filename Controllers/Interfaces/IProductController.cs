using FinalWebApp.Controllers.BaseInterfaces;
using FinalWebApp.Dto.Requests.Product;
using FinalWebApp.Dto.Responses.Product;
using FinalWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalWebApp.Controllers.Interfaces
{
    public interface IProductController: IGetListController<ProductGetDetailResponse, BaseQueryFilter>,
        IGetDetailController<string, ProductGetDetailResponse>,
        ICreateController<ProductCreateRequest, bool>,
        IUpdateController<string, ProductUpdateRequest, bool>,
        IDeleteController<string, bool>
    {

    }
}
