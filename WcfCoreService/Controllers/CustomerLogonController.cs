using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WcfCoreService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerLogonController : ControllerBase
    {
        private readonly ILogger<CustomerLogonController> _logger;

        public CustomerLogonController(ILogger<CustomerLogonController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
           return null;
        }
    }
}
