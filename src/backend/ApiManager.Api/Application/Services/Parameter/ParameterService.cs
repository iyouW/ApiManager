using ApiManager.Api.Application.Model.Request.Api;
using ApiManager.Core.Repositories;
using ApiManager.Infra.Dal.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiManager.Api.Application.Services.Project
{
    public class ParameterService : IParameterService
    {
        private readonly IParameterRepository _repo;
        private readonly IDbContext _context;

        public ParameterService(IParameterRepository repo, IDbContext context)
        {
            _repo = repo;
            _context = context;
        }

        public Task<Core.Entities.Parameter> GetByIdAsync(string id)
        {
            return _repo.GetAsync(id);
        }

        public Task<IEnumerable<Core.Entities.Parameter>> GetListAsync()
        {
            return _repo.GetListAsync();
        }

        public Task<IEnumerable<Core.Entities.Parameter>> GetListByApiIdAsync(string apiId)
        {
            return _repo.GetListAsync(x => x.ApiId == apiId);
        }

        public async Task<Core.Entities.Parameter> AddAsync(Core.Entities.Parameter project)
        {
            _repo.Add(project);
            _ = await _context.SaveChangeAsync();
            return project;
        }

        public async Task SaveAsync(SaveApiParameterRequest request)
        {
            var parameters = PrepareParameter(request);
            if (parameters.Count == 0)
            {
                return;
            }
            var apiId = parameters[0].ApiId;
            _repo.Delete(x => x.ApiId == apiId);
            _repo.AddRange(parameters);
            _ = await _context.SaveChangeAsync();

            List<ParameterTree> PrepareParameter(SaveApiParameterRequest request)
            {
                var res = new List<ParameterTree>();
                if (request.Input is not null)
                {
                    FlattenParameter(request.Input,null, res);
                }
                if (request.Output is not null)
                {
                    FlattenParameter(request.Output,null, res);
                }
                if (request.Exception is not null)
                {
                    FlattenParameter(request.Exception,null, res);
                }
                return res;

                void FlattenParameter(ParameterTree tree, ParameterTree? parent, IList<ParameterTree> store)
                {
                    tree.Id = Guid.NewGuid().ToString();
                    tree.ParentId = parent?.Id;
                    store.Add(tree);
                    if (tree.Children is not null)
                    {
                        foreach (var child in tree.Children)
                        {
                            FlattenParameter(child, tree, store);
                        }
                    }
                }
            }
        }
    }
}
