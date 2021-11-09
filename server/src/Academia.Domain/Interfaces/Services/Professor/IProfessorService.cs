using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Academia.Domain.Entities;

namespace Academia.Domain.Interfaces.Services
{
    public interface IProfessorService
    {
        Task<Professor> Get(long id);
        Task<IEnumerable<Professor>> GetAll();
         Task<ProfessorOutputGetAllDTO> GetByPageAsync(long academiaId, int limit, int page, CancellationToken cancellationToken);
        Task<Professor> Post(Professor professor);

        Task<Professor> Put(Professor professor);

        Task<bool> Delete(long id);
    }

    public class  ProfessorOutputGetAllDTO
    {
        public int CurrentPage { get; set; }

        public int TotalItems { get; set; }

        public int TotalPages { get; set; }

        public List<Professor> Items { get; set; }
    }
}