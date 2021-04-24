using System;
using System.Net;
using System.Threading.Tasks;
using Academia.Domain.Interfaces.Services.Alunos;
using Microsoft.AspNetCore.Mvc;

namespace Academia.Application.Controllers
{
    [Route("academia/[controller]")]
    public class AlunosController : ControllerBase
    {
        private IAlunoService _service;
        public AlunosController(IAlunoService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<ActionResult> GetAll([FromServices] IAlunoService service)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                return Ok(await _service.GetAll());
            }
            catch (ArgumentException e)
            {

                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}