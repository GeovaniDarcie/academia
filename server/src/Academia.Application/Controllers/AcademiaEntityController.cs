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
    [Route("api/[controller]")]
    [Authorize(Roles = "Mestre")]
    public class AcademiaEntityController : ControllerBase
    {
        private IAcademiaEntityService _service;
        public AcademiaEntityController(IAcademiaEntityService service)
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
        public async Task<IActionResult> Post([FromBody] AcademiaInputDTO inputDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var academia = new AcademiaEntity(inputDTO.Nome, inputDTO.Endereco, inputDTO.Email);
                var result = await _service.Post(academia);
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
        public async Task<IActionResult> Put(long id, [FromBody] AcademiaInputDTO inputDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var academia = new AcademiaEntity(inputDTO.Nome, inputDTO.Endereco, inputDTO.Email);
                academia.Id = id;
                var result = await _service.Put(academia);
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