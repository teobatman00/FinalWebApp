using FinalWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalWebApp.Controllers.BaseInterfaces
{
    public interface IUpdateController<TId, TReq, TResp> where TReq : class
    {
        Task<ActionResult<ApiResponse<TResp>>> UpdateAsync([FromBody] TReq resq, TId id);
    }
}
