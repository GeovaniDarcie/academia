using System;
using System.Net;
using System.Threading.Tasks;
using Academia.Domain.Entities;
using Academia.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Academia.Domain.DTOs;
using Microsoft.AspNetCore.Authorization;

namespace Academia.Application.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Roles = "Completo, Professor")]
    public class DobrasCutaneasController : ControllerBase
    {
        private IDobrasCutaneasService _service;
        public DobrasCutaneasController(IDobrasCutaneasService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<ActionResult> GetAll([FromServices] IDobrasCutaneasService service)
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
        public async Task<IActionResult> Post([FromBody] DobrasCutaneasInputDTO inputDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var dobrasCutaneas = new DobrasCutaneas(inputDTO.Triciptal, inputDTO.Subescapular, inputDTO.Biciptal, inputDTO.AxilarMedia, inputDTO.SupraIliaca,
                            inputDTO.Toracica, inputDTO.Coxa, inputDTO.Abdominal, inputDTO.PanturrilhaMedial, inputDTO.AlunoId);

                var result = await _service.Post(dobrasCutaneas);
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

        [HttpPut]
        public async Task<IActionResult> Put(long id, [FromBody] DobrasCutaneasInputDTO inputDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var dobrasCutaneas = new DobrasCutaneas(inputDTO.Triciptal, inputDTO.Subescapular, inputDTO.Biciptal, inputDTO.AxilarMedia, inputDTO.SupraIliaca,
                            inputDTO.Toracica, inputDTO.Coxa, inputDTO.Abdominal, inputDTO.PanturrilhaMedial, inputDTO.AlunoId);
                dobrasCutaneas.Id = id;
                var result = await _service.Put(dobrasCutaneas);
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