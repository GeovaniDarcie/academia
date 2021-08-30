using System.Collections.Generic;
using System.Threading.Tasks;
using Academia.Domain.Entities;
using Academia.Domain.Interfaces;
using Academia.Domain.Interfaces.Services;

namespace Academia.Service.Services
{
    public class AcademiaEntityService : IAcademiaEntityService
    {
        private IRepository<AcademiaEntity> _repository;
        public AcademiaEntityService(IRepository<AcademiaEntity> repository)
        {
            _repository = repository;
        }
        public async Task<bool> Delete(long id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<AcademiaEntity> Get(long id)
        {
            return await _repository.SelectAsync(id);
        }

        public async Task<IEnumerable<AcademiaEntity>> GetAll()
        {
            return await _repository.SelectAsync();
        }

        public async Task<AcademiaEntity> Post(AcademiaEntity academia)
        {
            return await _repository.InsertAsync(academia);
        }

        public async Task<AcademiaEntity> Put(AcademiaEntity academia)
        {
            return await _repository.UpdateAsync(academia);
        }
    }
}