using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Academia.Domain.Entities;

namespace Academia.Domain.Interfaces.Services.Alunos
{
    public interface IAlunoService
    {
        Task<Aluno> Get(long id);
        Task<IEnumerable<Aluno>> GetAll();
        Task<Aluno> Post(Aluno aluno);

        Task<Aluno> Put(Aluno aluno);

        Task<bool> Delete(long id);
    }
}