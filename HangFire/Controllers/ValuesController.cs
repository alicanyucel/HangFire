using Hangfire;
using Microsoft.AspNetCore.Mvc;

namespace HangFire.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class ValuesController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        BackgroundJob.Enqueue(() => BackgroundTestService.Test());
        return Ok("hangifre çalıştı");
    }
}

public class BackgroundTestService
{
    public static void Test()
    {
        Console.WriteLine("hangfire çalısıyor:" + DateTime.Now);
    }
}
