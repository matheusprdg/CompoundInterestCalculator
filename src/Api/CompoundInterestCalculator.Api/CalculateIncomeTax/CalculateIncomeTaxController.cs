using CompoundInterestCalculator.Application.Queries.CalculateIncomeTax;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace CompoundInterestCalculator.Api.CalculateIncomeTax;

[ApiController]
[Route("api/incomeTax")]
public class CalculateIncomeTaxController : ControllerBase
{
    private readonly ICalculateIncomeTaxQuery query;

    public CalculateIncomeTaxController(ICalculateIncomeTaxQuery query)
    {
        this.query = query;
    }

    [HttpGet("calculate")]
    public ActionResult<ICalculateIncomeTaxOutput> Get(
        [FromQuery] [Required] CalculateIncomeTaxInput input,
        CancellationToken cancellationToken)
    {
        var items = this.query.Execute(input, cancellationToken);

        return Ok(items);
    }
}
