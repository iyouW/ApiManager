using System.IO;
using System.Threading.Tasks;

namespace ApiManager.Api.Application.Services.CodeGenerator
{
    public interface ICodeGeneratorService
    {
        Task<Stream> GenerateBridgeAsync(string projectId);
        Task<Stream> GenerateExampleAsync(string projectId);
    }
}