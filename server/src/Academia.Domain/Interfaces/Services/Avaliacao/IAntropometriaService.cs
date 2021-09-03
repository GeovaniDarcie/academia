using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Academia.Domain.Entities;

namespace Academia.Domain.Interfaces.Services
{
    public interface IAntropometriaService
    {
        Task<Antropometria> Get(long id);
        Task<IEnumerable<Antropometria>> GetAll();
        Task<Antropometria> Post(Antropometria antropometria);

        Task<Antropometria> Put(Antropometria antropometria);

        Task<bool> Delete(long id);
    }
}