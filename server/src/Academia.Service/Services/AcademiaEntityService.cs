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
    public class AcademiaEntityService : IAcademiaEntityService
    {
        private readonly AcademiaContext _context;
        private IRepository<AcademiaEntity> _repository;
        public AcademiaEntityService(IRepository<AcademiaEntity> repository, AcademiaContext context)
        {
            _repository = repository;
            _context = context;
        }
        public async Task<bool> Delete(long id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<AcademiaEntity> Get(long id)
        {
            return await _repository.SelectAsync(id);
        }

        public async Task<AcademiaOutputGetAllDTO> GetByPageAsync(int limit, int page, CancellationToken cancellationToken) {
            var pagedModel = await _context.Academias
                    .AsNoTracking()
                    .OrderBy(p => p.Id)
                    .PaginateAsync(page, limit, cancellationToken);

            if (!pagedModel.Items.Any()) {
                throw new Exception("Não existem alunos cadastrados!");
            }

            return new AcademiaOutputGetAllDTO {
                CurrentPage = pagedModel.CurrentPage,
                TotalPages = pagedModel.TotalPages,
                TotalItems = pagedModel.TotalItems,
                Items = pagedModel.Items.Select(academia => academia).ToList()
            };
        }

        public async Task<IEnumerable<AcademiaEntity>> GetAll()
        {
            return await _repository.SelectAsync();
        }

        public async Task<AcademiaEntity> Post(AcademiaEntity academia)
        {
            return await _repository.InsertAsync(academia);
        }

        public async Task<AcademiaEntity> Put(AcademiaEntity academia)
        {
            return await _repository.UpdateAsync(academia);
        }
    }
}