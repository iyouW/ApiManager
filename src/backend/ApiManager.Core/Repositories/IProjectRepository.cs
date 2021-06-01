using ApiManager.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiManager.Core.Repositories
{
    public interface IProjectRepository
    {
        Task<Project> GetById(string id);
        Task<string> AddAsync(Project project);
    }
}
