using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Academia.Domain.Models;
using Academia.Data.Repositorios;
using Microsoft.EntityFrameworkCore;

namespace Academia.Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AlunoController : ControllerBase
    {
        private readonly AlunoContext _context;

        public AlunoController(AlunoContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IQueryable<string> Get()
        {

            var alunos = _context.Alunos.Select(a => a.Nome);
            return alunos;
        }

        [HttpPost]
        public async Task<string> Post(Aluno aluno)
        {
            _context.Alunos.Add(aluno);
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
