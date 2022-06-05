using FinalWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalWebApp.Services.BaseInterfaces
{
    public interface IDeleteService<TId, TResp>
    {
        Task<ApiResponse<TResp>> DeleteAsync(TId id);
    }
}
