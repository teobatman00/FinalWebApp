using FinalWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalWebApp.Services.BaseInterfaces
{
    public interface IGetDetailService<TId, TResp> where TResp: class
    {
        Task<ApiResponse<TResp>> GetDetailAsync(TId id);
    }
}
