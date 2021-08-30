using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Academia.Domain.Entities;

namespace Academia.Domain.Interfaces.Services
{
    public interface IAcademiaEntityService
    {
        Task<AcademiaEntity> Get(long id);
        Task<IEnumerable<AcademiaEntity>> GetAll();
        Task<AcademiaEntity> Post(AcademiaEntity academia);

        Task<AcademiaEntity> Put(AcademiaEntity academia);

        Task<bool> Delete(long id);
    }
}