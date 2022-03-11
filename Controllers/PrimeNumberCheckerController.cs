using Microsoft.AspNetCore.Mvc;

namespace aspdockerapi.Controllers;

[ApiController]
[Route("[controller]")]
public class PrimeNumberCheckerController : ControllerBase
{
    private readonly ILogger<PrimeNumberCheckerController> _logger;

    public PrimeNumberCheckerController(ILogger<PrimeNumberCheckerController> logger)
    {
        _logger = logger;
    }

    [HttpGet("{checkNumber}")]
    public PrimeState Get(int checkNumber)
    {
        if (checkNumber == 1)
            return PrimeState.IsNoPrime;
        if (checkNumber <= 0)
            return PrimeState.Invalid;
        
        PrimeState state = PrimeState.IsPrime;
        for (int i = 2; i < checkNumber+1; i++)
        {
            if (checkNumber % i == 0 && checkNumber != i)
            {
                state = PrimeState.IsNoPrime;
            }
        }
        return state;
    }
}