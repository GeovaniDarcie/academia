using System;
using System.Net;
using System.Threading.Tasks;
using Academia.Domain.Entities;
using Academia.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Academia.Domain.DTOs;
using Microsoft.AspNetCore.Authorization;
using System.Threading;

namespace Academia.Application.Controllers
{
    [Authorize(Roles = "Completo")]
    [Route("api/[controller]")]
    public class ProfessoresController : ControllerBase
    {
        private IProfessorService _service;
        public ProfessoresController(IProfessorService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<ActionResult> GetAll([FromQuery] long academiaId, CancellationToken cancellationToken, int limit = 5, int page = 1)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                return Ok(await _service.GetByPageAsync(academiaId, limit, page, cancellationToken));
            }
            catch (ArgumentException e)
            {

                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpGet]
        [Route("{id}")]
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
        public async Task<IActionResult> Post([FromBody] ProfessorInputDTO inputDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var professor = new Professor(inputDTO.Nome, inputDTO.Sobrenome, inputDTO.Email, inputDTO.AcademiaId);
                var result = await _service.Post(professor);
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
        public async Task<IActionResult> Put(long id, [FromBody] ProfessorInputDTO inputDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var professor = new Professor(inputDTO.Nome, inputDTO.Sobrenome, inputDTO.Email, inputDTO.AcademiaId);
                professor.Id = id;
                var result = await _service.Put(professor);
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