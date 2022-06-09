using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalWebApp.Controllers.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase, IOrderController
    {
    }
}
