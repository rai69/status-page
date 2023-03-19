using Microsoft.AspNetCore.Mvc;

namespace status_page.Controllers;

[ApiController]
[Route("[controller]")]
public class StatusController : ControllerBase
{
    [HttpGet()]
    public IActionResult Get()
    {
        var status = System.IO.File.ReadAllText("./status.txt");
        var response = System.Text.Json.JsonSerializer.Deserialize<StatusResponse>(status, new System.Text.Json.JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        return Ok(response);
    }

    public class StatusResponse
    {
        public int Status { get; set; }

        public string Description { get; set; }

        public string EstimatedEndTime { get; set; }
    }
}

