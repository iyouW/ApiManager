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

        private static ParameterDetailResponse? Compose(IEnumerable<ParameterDetailResponse> nodes)
        {
            if (!nodes.Any())
            {
                return null;
            }
            return TreeD.Compose(
                nodes,
                x => string.IsNullOrWhiteSpace(x.ParentId),
                (n1, n2) => n1.Id == n2.ParentId,
                (parent, children) => parent.Children = parent.Children.Union(children)
            ).FirstOrDefault();
        }
    }
}
