using FinalWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalWebApp.Controllers.BaseInterfaces
{
    public interface IUpdateController<TReq, TResp> where TReq : class
    {
        ActionResult<Task<ApiResponse<TResp>>> UpdateAsync([FromBody] TReq resq);
    }
}
