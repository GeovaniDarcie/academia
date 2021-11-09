using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Academia.Data.Context;
using Academia.Domain.Entities;
using Academia.Domain.Interfaces;
using Academia.Domain.Interfaces.Services;
using Microsoft.EntityFrameworkCore;

namespace Academia.Service.Services
{
    public class ProfessorService : IProfessorService
    {
        private IRepository<Professor> _repository;

        private readonly AcademiaContext _context;
        public ProfessorService(IRepository<Professor> repository, AcademiaContext context)
        {
            _repository = repository;
            _context = context;
        }
        public async Task<bool> Delete(long id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<Professor> Get(long id)
        {
            return await _repository.SelectAsync(id);
        }

        public async Task<IEnumerable<Professor>> GetAll()
        {
            return await _repository.SelectAsync();
        }

        public async Task<ProfessorOutputGetAllDTO> GetByPageAsync(long academiaId, int limit, int page, CancellationToken cancellationToken) {
            var pagedModel = await _context.Professores
                    .AsNoTracking()
                    .Where(p => p.AcademiaId == academiaId)
                    .OrderBy(p => p.Id)
                    .PaginateAsync(page, limit, cancellationToken);

            if (!pagedModel.Items.Any()) {
                throw new Exception("Não existem professores cadastrados!");
            }

            return new ProfessorOutputGetAllDTO {
                CurrentPage = pagedModel.CurrentPage,
                TotalPages = pagedModel.TotalPages,
                TotalItems = pagedModel.TotalItems,
                Items = pagedModel.Items.Select(professor => professor).ToList()
            };
        }

        public async Task<Professor> Post(Professor professor)
        {
            return await _repository.InsertAsync(professor);
        }

        public async Task<Professor> Put(Professor professor)
        {
            return await _repository.UpdateAsync(professor);
        }
    }
}