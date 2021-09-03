using System.Collections.Generic;
using System.Threading.Tasks;
using Academia.Domain.Entities;
using Academia.Domain.Interfaces;
using Academia.Domain.Interfaces.Services;

namespace Academia.Service.Services
{
    public class DobrasCutaneasService : IDobrasCutaneasService
    {
        private IRepository<DobrasCutaneas> _repository;
        public DobrasCutaneasService(IRepository<DobrasCutaneas> repository)
        {
            _repository = repository;
        }
        public async Task<bool> Delete(long id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<DobrasCutaneas> Get(long id)
        {
            return await _repository.SelectAsync(id);
        }

        public async Task<IEnumerable<DobrasCutaneas>> GetAll()
        {
            return await _repository.SelectAsync();
        }

        public async Task<DobrasCutaneas> Post(DobrasCutaneas dobrasCutaneas)
        {
            return await _repository.InsertAsync(dobrasCutaneas);
        }

        public async Task<DobrasCutaneas> Put(DobrasCutaneas dobrasCutaneas)
        {
            return await _repository.UpdateAsync(dobrasCutaneas);
        }
    }
}