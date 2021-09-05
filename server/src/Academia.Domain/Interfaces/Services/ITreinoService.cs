using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Academia.Domain.Entities;

namespace Academia.Domain.Interfaces.Services
{
    public interface ITreinoService
    {
        Task<Treino> Get(long id);
        Task<IEnumerable<Treino>> GetAll();
        Task<Treino> Post(Treino treino);

        Task<Treino> Put(Treino treino);

        Task<bool> Delete(long id);
    }
}