using ApiManager.Api.Application.Services.Project;
using ApiManager.Infra.CodeGenerator.Abstraction;
using System.IO.Compression;
using System;
using System.Collections.Generic;
using System.IO;

using System.Linq;
using System.Threading.Tasks;
using ApiManager.Api.Application.Model.Response;

namespace ApiManager.Api.Application.Services.CodeGenerator
{
    public class CodeGeneratorService : ICodeGeneratorService
    {
        private static readonly string TemporaryDirectory = "Temporary";
        private static readonly string TemporaryZipDirectory = "Temporary/Zips";
        private readonly ICodeGeneratorEngine _engine;
        private readonly IProjectService _projService;

        public CodeGeneratorService(ICodeGeneratorEngine engine, IProjectService projService)
        {
            _engine = engine;
            _projService = projService;
        }

        public async Task<Stream> GenerateBridgeAsync(string projectId)
        {
            var project = await _projService.GetDetailAsync(projectId);
            if (!project.Modules.Any())
            {
                throw new Exception("no api in project");
            }
            var projectDir = CreateProjectDirectory(project.Name);
            foreach (var module in project.Modules)
            {
                if (!module.Apis.Any())
                {
                    continue;
                }
                await CreateModuleBridgeFileAsync(project, module, projectDir);
            }
            var res = CreateProjectZip(project.Name, projectDir);
            Directory.Delete(projectDir, true);
            return res;
        }

        public async Task<Stream> GenerateExampleAsync(string projectId)
        {
            var project = await _projService.GetDetailAsync(projectId);
            var type = "example";
            var projectDir = CreateProjectDirectory(project.Name, type);
            foreach (var module in project.Modules)
            {
                if (!module.Apis.Any())
                {
                    continue;
                }
                await CreateModuleExampleAsync(project, module, projectDir);
            }
            var res = CreateProjectZip(project.Name, projectDir, type);
            Directory.Delete(projectDir, true);
            return res;
        }

        private string CreateProjectDirectory(string projectName, string type = "bridge")
        {
            var path = Path.Combine(TemporaryDirectory, $"{projectName}_type");
            if (Directory.Exists(path))
            {
                Directory.Delete(path, true);
            }
            Directory.CreateDirectory(path);
            return path;
        }

        private async Task CreateModuleBridgeFileAsync(ProjectDetailResponse project, ModuleDetailResponse module, string projectDir)
        {
            foreach (var api in module.Apis)
            {
                api.Proxy = project.Proxies.SingleOrDefault(x => x.Id == api.ProxyId);
            }
            var model = new
            {
                module,
                proxies = project.Proxies.Where(x => module.Apis.Any(o => o.ProxyId == x.Id))
            };
            var content = await _engine.GenerateAsync("template/bridge.liquid", model);
            var modulePath = Path.Combine(projectDir, $"{module.Name}.js");
            await File.WriteAllTextAsync(modulePath, content);
        }

        private FileStream CreateProjectZip(string projectName, string projectDir, string type="bridge")
        {
            var path = Path.Combine(TemporaryZipDirectory, $"{projectName}_{type}.zip");
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            ZipFile.CreateFromDirectory(projectDir, path);
            return new FileStream(path, FileMode.Open, FileAccess.Read);
        }


        private async Task CreateModuleExampleAsync(ProjectDetailResponse project, ModuleDetailResponse module, string projectDir)
        {
            var moduleDir = Directory.CreateDirectory(Path.Combine(projectDir, module.Name));
            foreach (var api in module.Apis)
            {
                api.Proxy = project.Proxies.SingleOrDefault(x => x.Id == api.ProxyId);
                var model = new
                {
                    api
                };
                var content = await _engine.GenerateAsync("template/demo.liquid", model);
                var file = Path.Combine(moduleDir.FullName, $"{api.Name}.vue");
                await File.WriteAllTextAsync(file, content);
            }
        }
    }
}
