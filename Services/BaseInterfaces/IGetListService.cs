using FinalWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalWebApp.Services.BaseInterfaces
{
    public interface IGetListService<TResp, TFilter> where TResp: class where TFilter: class
    {
        Task<ApiResponse<PagePagination<TResp>>> GetListAsync(TFilter filter);
    }
}
