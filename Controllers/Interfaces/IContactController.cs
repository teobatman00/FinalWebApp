using FinalWebApp.Controllers.BaseInterfaces;
using FinalWebApp.Dto.Requests.Contact;
using FinalWebApp.Dto.Responses.Contact;
using FinalWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalWebApp.Controllers.Interfaces
{
    public interface IContactController: IGetListController<ContactGetListResponse, BaseQueryFilter>,
        IGetDetailController<string, ContactGetDetailResponse>,
        ICreateController<ContactCreateRequest, bool>,
        IUpdateController<string,ContactUpdateRequest, bool>,
        IDeleteController<string, bool>
    {

    }
}
