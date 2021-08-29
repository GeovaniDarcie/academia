using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Academia.Domain.Entities;

namespace Academia.Domain.Interfaces.Services
{
    public interface IAdminService
    {
        Task<Admin> Get(long id);
        Task<IEnumerable<Admin>> GetAll();
        Task<Admin> Post(Admin admin);

        Task<Admin> Put(Admin admin);

        Task<bool> Delete(long id);
    }
}