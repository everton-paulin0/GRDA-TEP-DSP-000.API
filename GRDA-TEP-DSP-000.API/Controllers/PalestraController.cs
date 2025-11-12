using GRDA_TEP_DSP_000.Application.Command.DeletePalestra;
using GRDA_TEP_DSP_000.Application.Command.InsertPalestra;
using GRDA_TEP_DSP_000.Application.Command.UpdatePalestraCommand;
using GRDA_TEP_DSP_000.Application.Interface;
using GRDA_TEP_DSP_000.Application.Queries.GetAllPalestraQuery;
using GRDA_TEP_DSP_000.Application.Queries.GetPalestraByIdQuery;
using GRDA_TEP_DSP_000.Application.Queries.GetPalestraByTrailQuery;
using GRDA_TEP_DSP_000.Domain.Entities.Enum;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GRDA_TEP_DSP_000.API.Controllers
{
    [Route("api/palestra")]
    [ApiController]
    public class PalestraController : ControllerBase
    {
        private readonly IPalestraRepository _PalestraRepository;
        private readonly IMediator _mediator;
        public PalestraController(IPalestraRepository PalestraRepository, IMediator mediator)
        {
            _PalestraRepository = PalestraRepository;
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] InsertPalestraCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result.IsSucess)
            {
                return BadRequest(result.Message);
            }

            return CreatedAtAction(nameof(GetById), new { id = result.Data }, command);
        }

        [HttpGet]
        public async Task<IActionResult> Get(string search = "")
        {
            var query = new GetAllPalestraQuery();

            var result = await _mediator.Send(query);

            return Ok(result);

        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetById(int id)
        {
            var result = await _mediator.Send(new GetPalestraByIdQuery(id));

            if (!result.IsSucess)
                return NotFound(result.Message);

            return Ok(result.Data);
        }

        //[HttpGet("trilha/{trail}")]
        //public async Task<IActionResult> GetByTrailAsync(int trail)
        //{
        //    // Converte o inteiro para o enum
        //    if (!Enum.IsDefined(typeof(Trail), trail))
        //        return BadRequest("Trilha inválida.");

        //    var query = new GetPalestraByTrailQuery((Trail)trail);
        //    var result = await _mediator.Send(query);

        //    if (!result.IsSucess)
        //        return NotFound(result.Message);

        //    return Ok(result.Data);
        //}

        [HttpGet("trilha/{trail}/sessao/{sessionTime}")]
        public async Task<IActionResult> GetByTrailAsync(int trail, int sessionTime)
        {
            if (!Enum.IsDefined(typeof(Trail), trail))
                return BadRequest("Trilha inválida.");

            if (!Enum.IsDefined(typeof(SessionTimes), sessionTime))
                return BadRequest("Horário de sessão inválido.");

            var query = new GetPalestraByTrailQuery((Trail)trail, (SessionTimes)sessionTime);
            var result = await _mediator.Send(query);

            if (!result.IsSucess)
                return NotFound(result.Message);

            return Ok(result.Data);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdatePalestraCommand command)
        {
            if (id != command.IdPalestra)
                return BadRequest("O ID Inválido.");

            var result = await _mediator.Send(command);

            if (!result.IsSucess)
            {
                return BadRequest(result.Message);
            }

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeletePalestraCommand(id));

            if (!result.IsSucess)
            {
                return BadRequest(result.Message);
            }

            return NoContent();
        }
    }
}
