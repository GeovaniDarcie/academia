using System;
using System.Net;
using System.Threading.Tasks;
using Academia.Domain.Entities;
using Academia.Domain.Interfaces.Services.Alunos;
using Microsoft.AspNetCore.Mvc;
using Academia.Domain.DTOs;
using Microsoft.AspNetCore.Authorization;
using System.Threading;

namespace Academia.Application.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class AlunosController : ControllerBase
    {
        private IAlunoService _service;
        public AlunosController(IAlunoService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<ActionResult> GetAll(CancellationToken cancellationToken, int limit = 5, int page = 1)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                return Ok(await _service.GetByPageAsync(limit, page, cancellationToken));
            }
            catch (ArgumentException e)
            {

                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpGet]
        [Route("{id}", Name = "GetWithId")]
        public async Task<IActionResult> Get(long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                return Ok(await _service.Get(id));
            }
            catch (ArgumentException e)
            {

                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AlunoInputDTO inputDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var aluno = new Aluno(inputDTO.Nome, inputDTO.Sobrenome, inputDTO.Email, inputDTO.Celular,
                    inputDTO.Cpf,  inputDTO.DataDeNascimento, inputDTO.Genero, inputDTO.InicioDeMatricula, inputDTO.AcademiaId);
                var result = await _service.Post(aluno);
                if (result != null)
                {
                    return Created(new Uri(Url.Link("GetWithId", new { id = result.Id })), result);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (ArgumentException e)
            {

                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, [FromBody] AlunoInputDTO inputDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var aluno = new Aluno(inputDTO.Nome, inputDTO.Sobrenome, inputDTO.Email, inputDTO.Celular,
                    inputDTO.Cpf,  inputDTO.DataDeNascimento, inputDTO.Genero, inputDTO.InicioDeMatricula, inputDTO.AcademiaId);
                aluno.Id = id;
        
                var result = await _service.Put(aluno);
                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (ArgumentException e)
            {

                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                return Ok(await _service.Delete(id));
            }
            catch (ArgumentException e)
            {

                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }


    }
}