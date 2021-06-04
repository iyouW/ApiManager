using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CodeGeneratorController : ControllerBase
    {

        [HttpPost("bridge")]
        public IActionResult GenerateBridge()
        {
            throw new NotImplementedException();
        }
    }
}
