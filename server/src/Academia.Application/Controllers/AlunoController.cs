using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Academia.Domain.Models;
using Academia.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Academia.Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AlunoController : ControllerBase
    {
        private readonly AcademiaContext _context;

        public AlunoController(AcademiaContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IQueryable<string> Get()
        {
            return _context.Alunos.Select(a => $"{a.Id}, {a.Nome}");
        }

        [HttpPost]
        public async Task<string> Post([FromBody] Aluno aluno)
        {
            _context.Add(new Aluno(aluno.Nome));
            await _context.SaveChangesAsync();
            return "sucess";
        }

        [HttpPut]
        public async Task<string> Put(Aluno aluno)
        {
            if (aluno.Id > 0)
            {
                _context.Alunos.Update(aluno);
                await _context.SaveChangesAsync();
                return "sucess";
            }
            else
            {
                return "erro";
            }
        }

        [HttpDelete]
        public async Task<string> Delete(Aluno aluno)
        {
            var _aluno = _context.Alunos.Find(aluno.Id);
            _context.Alunos.Remove(_aluno);
            await _context.SaveChangesAsync();

            return "deletado";
        }

    }
}
