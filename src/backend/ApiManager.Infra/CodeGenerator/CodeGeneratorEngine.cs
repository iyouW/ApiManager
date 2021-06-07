using ApiManager.Infra.CodeGenerator.Abstraction;
using Fluid;
using Fluid.Parser;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiManager.Infra.CodeGenerator
{
    public class CodeGeneratorEngine : ICodeGeneratorEngine
    {
        private static readonly ConcurrentDictionary<string, Task<IFluidTemplate>> _templateDict = new ConcurrentDictionary<string, Task<IFluidTemplate>>();
        public async Task<string> GenerateAsync(string template, object model)
        {
            var fluidTemplate = await GetTemplateAsync(template);
            var context = new TemplateContext(model);
            context.Options.MemberAccessStrategy = UnsafeMemberAccessStrategy.Instance;
            return await fluidTemplate.RenderAsync(context);
        }

        public Task<IFluidTemplate> GetTemplateAsync(string template)
        {
            return _templateDict.GetOrAdd(template, async key =>
            {
                if (!File.Exists(template))
                {
                    throw new FileNotFoundException($"{template}文件找不到");
                }
                var content = await File.ReadAllTextAsync(template);
                var parser = new FluidParser();
                if (parser.TryParse(content, out var res, out var err))
                {
                    return res;
                }
                else
                {
                    throw new Exception(err);
                }
            });
        }
    }
}
