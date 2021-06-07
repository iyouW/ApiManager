using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiManager.Infra.CodeGenerator.Abstraction
{
    public interface ICodeGeneratorEngine
    {
        Task<string> GenerateAsync(string template, object model);
    }
}
