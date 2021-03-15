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
        public async Task<IActionResult> Get()
        {
            var list = await _context.Alunos.OrderBy(x => x.Nome)
                                      .ToListAsync();
            return Ok(list);
        }

        [HttpPost]
        public async Task<string> Post([FromBody] Aluno aluno)
        {
            _context.Add(new Aluno(aluno.Nome, aluno.Sobrenome, aluno.DataDeNascimento,
            aluno.Sexo, aluno.Cpf, aluno.Email, aluno.DataDePagamento));
               await _context.SaveChangesAsync();
            return "sucess";
        }

        [HttpPut]
        public async Task<string> Put(Aluno aluno)
        {
            if (aluno.Id > 0)
            {
                var alunoNoDb = await _context.Alunos.FirstOrDefaultAsync(x => x.Id == aluno.Id);

                if (alunoNoDb == null) {
                    return null;
                }

                _context.Alunos.Update(alunoNoDb);
                await _context.SaveChangesAsync();
                return "sucess";
            }
            else
            {
                return "erro";
            }
        }

        [HttpDelete("{id}")]
        public async Task<string> Delete(long id)
        {
            var _aluno = _context.Alunos.Find(id);
            _context.Alunos.Remove(_aluno);
            await _context.SaveChangesAsync();

            return "deletado";
        }

    }
}
