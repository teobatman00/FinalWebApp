﻿using FinalWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalWebApp.Services.BaseInterfaces
{
    public interface ICreateService<TReq, TResp> where TReq : class where TResp : class
    {
        Task<ApiResponse<TResp>> CreateAsync(TReq request);
    }
}
