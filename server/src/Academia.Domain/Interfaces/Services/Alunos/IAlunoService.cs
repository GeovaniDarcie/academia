using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Academia.Domain.DTOs;
using Academia.Domain.Entities;

namespace Academia.Domain.Interfaces.Services.Alunos
{
    public interface IAlunoService
    {
        Task<Aluno> Get(long id);
        Task<AlunoListOutputGetAllDTO> GetByPageAsync(int limit, int page, CancellationToken cancellationToken);
        Task<IEnumerable<Aluno>> GetAll();
        Task<Aluno> Post(Aluno aluno);

        Task<Aluno> Put(Aluno aluno);

        Task<bool> Delete(long id);
    }

    public class  AlunoListOutputGetAllDTO
    {
        public int CurrentPage { get; set; }

        public int TotalItems { get; set; }

        public int TotalPages { get; set; }

        public List<Aluno> Items { get; set; }
    }
}

