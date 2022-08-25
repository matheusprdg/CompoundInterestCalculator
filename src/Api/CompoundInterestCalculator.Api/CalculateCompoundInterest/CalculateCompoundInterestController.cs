using CompoundInterestCalculator.Application.Queries.CalculateCompoundInterest;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace CompoundInterestCalculator.Api.CalculateCompoundInterest;

[ApiController]
[Route("api/compoundInterest")]
public class CalculateCompoundInterestController : ControllerBase
{
    private readonly ICalculateCompoundInterestQuery query;

    public CalculateCompoundInterestController(ICalculateCompoundInterestQuery query)
    {
        this.query = query;
    }

    [HttpGet("calculate")]
    public ActionResult<ICalculateCompoundInterestOutput> Get(
        [FromQuery] [Required] CalculateCompoundInterestInput input,
        CancellationToken cancellationToken)
    {
        var items = this.query.Execute(input, cancellationToken);

        return Ok(items);
    }
}
