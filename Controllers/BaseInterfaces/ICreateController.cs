using FinalWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalWebApp.Controllers.BaseInterfaces
{
    public interface ICreateController<TReq, TResp> where TReq : class
    {
        Task<ActionResult<ApiResponse<TResp>>> CreateAsync([FromBody] TReq request);
    }
}
