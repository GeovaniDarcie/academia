using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Academia.Data.Context;
using Academia.Domain.DTOs;
using Academia.Domain.Entities;
using Academia.Domain.Interfaces;
using Academia.Domain.Interfaces.Services.Alunos;
using Microsoft.EntityFrameworkCore;

namespace Academia.Service.Services
{
    public class AlunoService : IAlunoService
    {
        private IRepository<Aluno> _repository;
        private readonly AcademiaContext _context;
        public AlunoService(IRepository<Aluno> repository, AcademiaContext context)
        {
            _repository = repository;
            _context = context;
        }
        public async Task<bool> Delete(long id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<Aluno> Get(long id)
        {
            return await _repository.SelectAsync(id);
        }

        public async Task<IEnumerable<Aluno>> GetAll()
        {
            return await _repository.SelectAsync();
        }

    public async Task<AlunoListOutputGetAllDTO> GetByPageAsync(long academiaId, int limit, int page, CancellationToken cancellationToken) {
        var pagedModel = await _context.Alunos
                .AsNoTracking()
                .Where(a => a.AcademiaId == academiaId)
                .OrderBy(p => p.Id)
                .PaginateAsync(page, limit, cancellationToken);

        if (!pagedModel.Items.Any()) {
            throw new Exception("Não existem alunos cadastrados!");
        }

        return new AlunoListOutputGetAllDTO {
            CurrentPage = pagedModel.CurrentPage,
            TotalPages = pagedModel.TotalPages,
            TotalItems = pagedModel.TotalItems,
            Items = pagedModel.Items.Select(aluno => aluno).ToList()
        };
    }

        public async Task<Aluno> Post(Aluno aluno)
        {
            return await _repository.InsertAsync(aluno);
        }

        public async Task<Aluno> Put(Aluno aluno)
        {
            return await _repository.UpdateAsync(aluno);
        }
    }
}