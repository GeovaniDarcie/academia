using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Academia.Domain.Entities;

namespace Academia.Domain.Interfaces.Services
{
    public interface IAnamneseService
    {
        Task<Anamnese> Get(long id);
        Task<IEnumerable<Anamnese>> GetAll();
        Task<Anamnese> Post(Anamnese anamnese);

        Task<Anamnese> Put(Anamnese anamnese);

        Task<bool> Delete(long id);
    }
}