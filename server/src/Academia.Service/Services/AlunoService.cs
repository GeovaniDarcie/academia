using System.Collections.Generic;
using System.Threading.Tasks;
using Academia.Domain.Entities;
using Academia.Domain.Interfaces;
using Academia.Domain.Interfaces.Services.Alunos;

namespace Academia.Service.Services
{
    public class AlunoService : IAlunoService
    {
        private IRepository<Aluno> _repository;
        public AlunoService(IRepository<Aluno> repository)
        {
            _repository = repository;
        }
        public async Task<bool> Delete(long id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<Aluno> Get(long id)
        {
            return await _repository.SelectAsync(id);
        }

        public async Task<IEnumerable<Aluno>> GetAll()
        {
            return await _repository.SelectAsync();
        }

        public async Task<Aluno> Post(Aluno aluno)
        {
            return await _repository.InsertAsync(aluno);
        }

        public async Task<Aluno> Put(Aluno aluno)
        {
            return await _repository.UpdateAsync(aluno);
        }
    }
}