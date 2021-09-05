using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Academia.Domain.Entities;

namespace Academia.Domain.Interfaces.Services
{
    public interface IAtividadeService
    {
        Task<Atividade> Get(long id);
        Task<IEnumerable<Atividade>> GetAll();
        Task<Atividade> Post(Atividade atividade);

        Task<Atividade> Put(Atividade atividade);

        Task<bool> Delete(long id);
    }
}