using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Welsh.Api.Framebot.Controllers;
[ApiController]
[Route("api/[controller]/")]
public class FramebotController(ILogger<FramebotController> logger) : ControllerBase
{
    private readonly ILogger<FramebotController> _logger = logger;

    private static readonly Dictionary<int, Process> processes = [];

    [HttpGet]
    public void EnableBot([FromQuery] int userId, [FromQuery] bool enable)
    {

    }
}
