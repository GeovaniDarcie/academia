using System.Collections.Generic;
using System.Threading.Tasks;
using Academia.Domain.Entities;
using Academia.Domain.Interfaces;
using Academia.Domain.Interfaces.Services;

namespace Academia.Service.Services
{
    public class AdminService : IAdminService
    {
        private IRepository<Admin> _repository;
        public AdminService(IRepository<Admin> repository)
        {
            _repository = repository;
        }
        public async Task<bool> Delete(long id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<Admin> Get(long id)
        {
            return await _repository.SelectAsync(id);
        }

        public async Task<IEnumerable<Admin>> GetAll()
        {
            return await _repository.SelectAsync();
        }

        public async Task<Admin> Post(Admin Admin)
        {
            return await _repository.InsertAsync(Admin);
        }

        public async Task<Admin> Put(Admin Admin)
        {
            return await _repository.UpdateAsync(Admin);
        }
    }
}