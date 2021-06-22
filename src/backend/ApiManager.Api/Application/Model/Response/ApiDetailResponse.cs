using ApiManager.Infra.Tree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiManager.Api.Application.Model.Response
{
    public class ApiDetailResponse : Core.Entities.Api
    {
        public IEnumerable<ParameterDetailResponse>? Parameters { get; set; }
        public ProxyDetailReponse? Proxy { get; set; }
        public IEnumerable<ParameterDetailResponse>? Input => Parameters?.Where(x => x.Category == Core.Entities.ParameterCategory.Input);
        public IEnumerable<ParameterDetailResponse>? Output => Parameters?.Where(x => x.Category == Core.Entities.ParameterCategory.Output);
        public IEnumerable<ParameterDetailResponse>? Exception => Parameters?.Where(x => x.Category == Core.Entities.ParameterCategory.Exception);
        public string OperationName => string.IsNullOrWhiteSpace(MapName) ? Name : MapName;

        public ParameterDetailResponse? InputRoot => Compose(Input);
        public ParameterDetailResponse? OutputRoot => Compose(Output);
        public ParameterDetailResponse? ExceptionRoot => Compose(Exception);

        public IEnumerable<ParameterDetailResponse>? InputObjects => Find(InputRoot);
        public IEnumerable<ParameterDetailResponse>? OutputObjects => Find(OutputRoot);
        public IEnumerable<ParameterDetailResponse>? ExceptionObjects => Find(ExceptionRoot);

        private static ParameterDetailResponse? Compose(IEnumerable<ParameterDetailResponse> nodes)
        {
            if (!nodes.Any())
            {
                return null;
            }
            return Tree<ParameterDetailResponse,string>.Compose(nodes).FirstOrDefault();
        }

        private static IEnumerable<ParameterDetailResponse>? Find(ParameterDetailResponse? node)
        {
            if (node is null)
            {
                return null;
            }
            return Tree<ParameterDetailResponse, string>.Find(node, x => x.Type == Core.Entities.ParameterType.Object);
        }
    }
}
