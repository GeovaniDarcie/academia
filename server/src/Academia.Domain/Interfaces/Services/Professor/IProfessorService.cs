using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Academia.Domain.Entities;

namespace Academia.Domain.Interfaces.Services
{
    public interface IProfessorService
    {
        Task<Professor> Get(long id);
        Task<IEnumerable<Professor>> GetAll();
        Task<Professor> Post(Professor professor);

        Task<Professor> Put(Professor professor);

        Task<bool> Delete(long id);
    }
}