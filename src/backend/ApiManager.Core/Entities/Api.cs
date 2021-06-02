namespace ApiManager.Core.Entities
{
    public class Api
    {
        public string? Id {get; set;}
        public string? Name {get; set;}
        public string? Description {get; set;}
        public bool IsSupported {get; set;}
        public bool IsParameterStandard {get; set;}
        public string? MapName {get; set;}
        public string? ProjectId {get; set;}
        public string? ModuleId {get; set;}
        public string? ProxyId {get; set;}
    }
}