using System.Collections.Generic;
using System.Threading.Tasks;
using Academia.Domain.Entities;
using Academia.Domain.Interfaces;
using Academia.Domain.Interfaces.Services;

namespace Academia.Service.Services
{
    public class ProfessorService : IProfessorService
    {
        private IRepository<Professor> _repository;
        public ProfessorService(IRepository<Professor> repository)
        {
            _repository = repository;
        }
        public async Task<bool> Delete(long id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<Professor> Get(long id)
        {
            return await _repository.SelectAsync(id);
        }

        public async Task<IEnumerable<Professor>> GetAll()
        {
            return await _repository.SelectAsync();
        }

        public async Task<Professor> Post(Professor professor)
        {
            return await _repository.InsertAsync(professor);
        }

        public async Task<Professor> Put(Professor professor)
        {
            return await _repository.UpdateAsync(professor);
        }
    }
}