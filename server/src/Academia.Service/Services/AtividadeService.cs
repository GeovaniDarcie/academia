using System.Collections.Generic;
using System.Threading.Tasks;
using Academia.Domain.Entities;
using Academia.Domain.Interfaces;
using Academia.Domain.Interfaces.Services;

namespace Academia.Service.Services
{
    public class AtividadeService : IAtividadeService
    {
        private IRepository<Atividade> _repository;
        public AtividadeService(IRepository<Atividade> repository)
        {
            _repository = repository;
        }
        public async Task<bool> Delete(long id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<Atividade> Get(long id)
        {
            return await _repository.SelectAsync(id);
        }

        public async Task<IEnumerable<Atividade>> GetAll()
        {
            return await _repository.SelectAsync();
        }

        public async Task<Atividade> Post(Atividade atividade)
        {
            return await _repository.InsertAsync(atividade);
        }

        public async Task<Atividade> Put(Atividade atividade)
        {
            return await _repository.UpdateAsync(atividade);
        }
    }
}