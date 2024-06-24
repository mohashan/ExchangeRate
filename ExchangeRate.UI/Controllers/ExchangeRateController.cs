using ExchangeRate.Application.ExchangeRates.GetRate;
using ExchangeRate.Application.ExchangeRates.GetRates;
using ExchangeRate.Application.ExchangeRates.ProvideRate;
using ExchangeRate.Application.ExchangeRates.UpdateRate;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ExchangeRate.UI.Controllers;

[ApiController]
[Route("api/ExchangeRate")]

public class ExchangeRateController(ISender sender): ControllerBase
{
    [HttpGet("UpdateFromOrigin")]
    public async Task<ActionResult> UpdateFromOrigin()
    {
        var command = new ProvideRateCommand();
        var result = await sender.Send(command);

        if (result.IsFailure)
        {
            return BadRequest(result.Error.Code);
        }

        return Ok();
    }

    [HttpGet()]
    public async Task<ActionResult<List<string>>> GetAllSymbols()
    {
        var query = new GetAllRatesQuery();
        var result = await sender.Send(query);

        if (result.IsFailure)
        {
            return BadRequest();
        }

        return Ok(result.Value);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<KeyValuePair<string,decimal>>> GetSymbol(string id)
    {
        var query = new GetRateQuery(id);
        var result = await sender.Send(query);

        if (result.IsFailure)
        {
            return NotFound();
        }

        return Ok(new KeyValuePair<string, decimal>(result.Value.Item1,result.Value.Item2));
    }
}
