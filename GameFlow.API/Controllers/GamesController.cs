using GameFlow.Application.Commands;
using GameFlow.Application.Commands.Games;
using GameFlow.Application.DTOs;
using GameFlow.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameFlow.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public GamesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GameResponse>>> GetGames()
        {
            var games = await _mediator.Send(new GetGamesQuery());
            return Ok(games);
        }

        [HttpGet("rent")]
        public async Task<ActionResult<IEnumerable<GameResponse>>> GetGamesForRent()
        {
            var games = await _mediator.Send(new GetGamesForRentQuery());
            return Ok(games);
        }

        [HttpGet("sale")]
        public async Task<ActionResult<IEnumerable<GameResponse>>> GetGamesForSale()
        {
            var games = await _mediator.Send(new GetGamesForSaleQuery());
            return Ok(games);
        }

        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<GameResponse>>> GetGamesWithFilters([FromQuery] GetGamesWithFiltersQuery query)
        {
            var games = await _mediator.Send(query);
            return Ok(games);
        }

        [HttpPost]
        public async Task<IActionResult> CreateGame([FromBody] CreateGameCommand command)
        {
            var gameId = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetGame), new { id = gameId }, new { Id = gameId });
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateGame(Guid id, [FromBody] UpdateGameCommand command)
        {
            command.Id = id;
            var result = await _mediator.Send(command);

            if (!result)
                return NotFound();

            return NoContent();
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<GameResponse>> GetGame(Guid id)
        {
            try
            {
                var query = new GetGameQuery(id);
                var game = await _mediator.Send(query);
                return Ok(game);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { Message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred while processing your request.", Details = ex.Message });
            }
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteGame(Guid id)
        {
            var command = new DeleteGameCommand { Id = id };
            var result = await _mediator.Send(command);

            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}
