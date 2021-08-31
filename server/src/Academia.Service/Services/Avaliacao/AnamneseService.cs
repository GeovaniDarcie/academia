using System.Collections.Generic;
using System.Threading.Tasks;
using Academia.Domain.Entities;
using Academia.Domain.Interfaces;
using Academia.Domain.Interfaces.Services;

namespace Academia.Service.Services
{
    public class AnamneseService : IAnamneseService
    {
        private IRepository<Anamnese> _repository;
        public AnamneseService(IRepository<Anamnese> repository)
        {
            _repository = repository;
        }
        public async Task<bool> Delete(long id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<Anamnese> Get(long id)
        {
            return await _repository.SelectAsync(id);
        }

        public async Task<IEnumerable<Anamnese>> GetAll()
        {
            return await _repository.SelectAsync();
        }

        public async Task<Anamnese> Post(Anamnese anamnese)
        {
            return await _repository.InsertAsync(anamnese);
        }

        public async Task<Anamnese> Put(Anamnese anamnese)
        {
            return await _repository.UpdateAsync(anamnese);
        }
    }
}