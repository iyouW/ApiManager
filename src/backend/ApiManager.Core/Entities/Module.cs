using ApiManager.Core.Entities.Abstractions;

namespace ApiManager.Core.Entities
{
    public class Module : EntityBase<string>
    {
        public string Name {get; set;}
        public string? Description {get; set;}
        public string ProjectId {get; set;}
    }
}
