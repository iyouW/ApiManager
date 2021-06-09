using ApiManager.Api.Application.Model.Request.CodeGenerator;
using ApiManager.Api.Application.Services.CodeGenerator;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ApiManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CodeGeneratorController : ControllerBase
    {
        private readonly ICodeGeneratorService _service;

        public CodeGeneratorController(ICodeGeneratorService service)
        {
            _service = service;
        }

        [HttpPost("bridge")]
        public async Task<IActionResult> GenerateBridge(GenerateBridgeRequest request)
        {
            var stream = await _service.GenerateBridgeAsync(request.ProjectId);
            var fileName = "temp.zip";
            if (stream is FileStream s)
            {
                fileName = Path.GetFileName(s.Name);
            }
            Response.Headers.Add("Access-Control-Expose-Headers", "X-File-Name");
            Response.Headers.Add("X-File-Name", fileName);
            return File(stream, "application/octet-stream", HttpUtility.UrlEncode(fileName));
        }

        [HttpPost("example")]
        public async Task<IActionResult> GenerateExample(GenerateBridgeRequest request)
        {
            var stream = await _service.GenerateExampleAsync(request.ProjectId);
            var fileName = "temp.zip";
            if (stream is FileStream s)
            {
                fileName = Path.GetFileName(s.Name);
            }
            Response.Headers.Add("Access-Control-Expose-Headers", "X-File-Name");
            Response.Headers.Add("X-File-Name", fileName);
            return File(stream, "application/octet-stream", HttpUtility.UrlEncode(fileName));
        }
    }
}
