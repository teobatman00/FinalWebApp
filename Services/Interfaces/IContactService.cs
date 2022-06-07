using FinalWebApp.Dto.Requests.Contact;
using FinalWebApp.Dto.Responses.Contact;
using FinalWebApp.Models;
using FinalWebApp.Services.BaseInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalWebApp.Services.Interfaces
{
    public interface IContactService: IGetListService<ContactGetListResponse, BaseQueryFilter>,
        IGetDetailService<string, ContactGetDetailResponse>,
        ICreateService<ContactCreateRequest, bool>,
        IUpdateService<string, ContactUpdateRequest, bool>,
        IDeleteService<string, bool>
    {

    }
}
