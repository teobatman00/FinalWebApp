using FinalWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalWebApp.Controllers.BaseInterfaces
{
    public interface IGetListController<TResp, TFilter> where TResp : class where TFilter : class
    {
        ActionResult<Task<ApiResponse<PagePagination<TResp>>>> GetListAsync([FromQuery] TFilter filter);
    }
}
