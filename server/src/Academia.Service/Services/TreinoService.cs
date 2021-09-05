using System.Collections.Generic;
using System.Threading.Tasks;
using Academia.Data.Context;
using Academia.Domain.Entities;
using Academia.Domain.Interfaces;
using Academia.Domain.Interfaces.Services;
using Microsoft.EntityFrameworkCore;

namespace Academia.Service.Services
{
    public class TreinoService : ITreinoService
    {
        private IRepository<Treino> _repository;
        private readonly AcademiaContext _context;
        public TreinoService(IRepository<Treino> repository, AcademiaContext context)
        {
            _repository = repository;
            _context = context;
        }
        public async Task<bool> Delete(long id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<Treino> Get(long id)
        {
            return await _repository.SelectAsync(id);
        }

        public async Task<IEnumerable<Treino>> GetAll()
        {
            return await _context
                    .Treinos
                    .AsNoTracking()
                    .Include(treino => treino.Atividades)
                    .ToListAsync();
        }

        public async Task<Treino> Post(Treino treino)
        {
            return await _repository.InsertAsync(treino);
        }

        public async Task<Treino> Put(Treino treino)
        {
            return await _repository.UpdateAsync(treino);
        }
    }
}