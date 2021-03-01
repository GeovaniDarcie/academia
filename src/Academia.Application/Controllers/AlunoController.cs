using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Academia.Domain.Models;

namespace Academia.Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AlunoController : ControllerBase
    {
        [HttpGet]
        public Aluno[] Get()
        {
            Aluno[] aluno = { new Aluno("Aluno 1"), new Aluno("Aluno 2") };
            return aluno;
        }
    }
}
