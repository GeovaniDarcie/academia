using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Academia.Domain.Entities;

namespace Academia.Domain.Interfaces.Services
{
    public interface IDobrasCutaneasService
    {
        Task<DobrasCutaneas> Get(long id);
        Task<IEnumerable<DobrasCutaneas>> GetAll();
        Task<DobrasCutaneas> Post(DobrasCutaneas dobrasCutaneas);

        Task<DobrasCutaneas> Put(DobrasCutaneas dobrasCutaneas);

        Task<bool> Delete(long id);
    }
}