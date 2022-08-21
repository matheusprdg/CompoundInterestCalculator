using CompoundInterestCalculator.Application.Queries.CalculateCompoundInterest;
using Microsoft.AspNetCore.Mvc;

namespace CompoundInterestCalculator.Api.CalculateCompoundInterest;

[ApiController]
[Route("api/compoundInterestCalculator")]
public class CalculateCompoundInterestController : ControllerBase
{
    private readonly ICalculateCompoundInterestQuery query;

    public CalculateCompoundInterestController(ICalculateCompoundInterestQuery query)
    {
        this.query = query;
    }

    [HttpGet("calculate")]
    public ActionResult<string> Get(
        [FromQuery] CalculateCompoundInterestInput input)
    {
        var items = this.query.Execute(new CalculateCompoundInterestInput());

        return "items";
    }
}
