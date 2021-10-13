using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Academia.Domain.Entities;

namespace Academia.Domain.Interfaces.Services
{
    public interface IAcademiaEntityService
    {
        Task<AcademiaEntity> Get(long id);
        Task<IEnumerable<AcademiaEntity>> GetAll();
        Task<AcademiaOutputGetAllDTO> GetByPageAsync(int limit, int page, CancellationToken cancellationToken);
        Task<AcademiaEntity> Post(AcademiaEntity academia);

        Task<AcademiaEntity> Put(AcademiaEntity academia);

        Task<bool> Delete(long id);
    }

    
    public class  AcademiaOutputGetAllDTO
    {
        public int CurrentPage { get; set; }

        public int TotalItems { get; set; }

        public int TotalPages { get; set; }

        public List<AcademiaEntity> Items { get; set; }
    }
}