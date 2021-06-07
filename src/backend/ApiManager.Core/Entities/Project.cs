using ApiManager.Core.Entities.Abstractions;

namespace ApiManager.Core.Entities
{
    public class Project : EntityBase<string>
    {
        public string Name {get; set;}
        public string? Description {get; set;}
    }
}