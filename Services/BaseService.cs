using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace FinalWebApp.Services
{
    public abstract class BaseService<TS>
    {
        protected BaseService(IMapper mapper, ILogger<TS> logger)
        {
            _mapper = mapper;
            _logger = logger;
        }

        private protected readonly IMapper _mapper;
        private protected readonly ILogger<TS> _logger;
    }
}
