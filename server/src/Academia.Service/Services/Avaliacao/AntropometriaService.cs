using System.Collections.Generic;
using System.Threading.Tasks;
using Academia.Domain.Entities;
using Academia.Domain.Interfaces;
using Academia.Domain.Interfaces.Services;

namespace Academia.Service.Services
{
    public class AntropometriaService : IAntropometriaService
    {
        private IRepository<Antropometria> _repository;
        public AntropometriaService(IRepository<Antropometria> repository)
        {
            _repository = repository;
        }
        public async Task<bool> Delete(long id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<Antropometria> Get(long id)
        {
            return await _repository.SelectAsync(id);
        }

        public async Task<IEnumerable<Antropometria>> GetAll()
        {
            return await _repository.SelectAsync();
        }

        public async Task<Antropometria> Post(Antropometria antropometria)
        {
            return await _repository.InsertAsync(antropometria);
        }

        public async Task<Antropometria> Put(Antropometria antropometria)
        {
            return await _repository.UpdateAsync(antropometria);
        }
    }
}