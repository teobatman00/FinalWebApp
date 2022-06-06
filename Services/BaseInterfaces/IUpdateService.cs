﻿using FinalWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalWebApp.Services.BaseInterfaces
{
    public interface IUpdateService<TId ,TReq, TResp> where TReq : class
    {
        Task<ApiResponse<TResp>> UpdateAsync(TId id, TReq request);
    }
}
