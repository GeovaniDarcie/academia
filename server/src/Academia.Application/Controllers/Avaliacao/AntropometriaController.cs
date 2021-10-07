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
    public class AntropometriaController : ControllerBase
    {
        private IAntropometriaService _service;
        public AntropometriaController(IAntropometriaService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<ActionResult> GetAll([FromServices] IAntropometriaService service)
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
        public async Task<IActionResult> Post([FromBody] AntropometriaInputDTO inputDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var antropometria = new Antropometria(
                    inputDTO.Peso,
                    inputDTO.Altura, 
                    inputDTO.PercentualDeGordura,
                    inputDTO.MassaMuscular,
                    inputDTO.AlunoId
                );
                var result = await _service.Post(antropometria);

                var antropometriaOutput = new AntropometriaOutputDTO(
                    result.Id,
                    result.Peso, 
                    result.Altura, 
                    result.IMC,
                    result.PercentualDeGordura,
                    result.MassaMuscular,
                    result.AlunoId
                );

                if (antropometriaOutput != null)
                {
                    return Created(new Uri(Url.Link("GetWithId", new { id = antropometriaOutput.Id })), antropometriaOutput);
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
        public async Task<IActionResult> Put(long id, [FromBody] AntropometriaInputDTO inputDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var antropometria = new Antropometria(
                    inputDTO.Peso,
                    inputDTO.Altura, 
                    inputDTO.PercentualDeGordura,
                    inputDTO.MassaMuscular,
                    inputDTO.AlunoId
                );
                antropometria.Id = id;
                var result = await _service.Put(antropometria);

                var antropometriaOutput = new AntropometriaOutputDTO(
                    result.Id,
                    result.Peso, 
                    result.Altura, 
                    result.IMC,
                    result.PercentualDeGordura,
                    result.MassaMuscular,
                    result.AlunoId
                );
        
                if (antropometriaOutput != null)
                {
                    return Ok(antropometriaOutput);
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