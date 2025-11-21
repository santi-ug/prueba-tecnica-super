using Microsoft.AspNetCore.Mvc;
using TaskApi.Services;

namespace TaskApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TasksController : ControllerBase
{
    private readonly TaskService _service;

    public TasksController(TaskService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult GetAll() => Ok(_service.GetAll());

    [HttpPost]
    public IActionResult Create([FromBody] dynamic body)
    {
        string title = body.title;
        return Ok(_service.Add(title));
    }

    [HttpPatch("{id}/complete")]
    public IActionResult Complete(int id)
    {
        var t = _service.Complete(id);
        return t == null ? NotFound() : Ok(t);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        return _service.Delete(id) ? NoContent() : NotFound();
    }
}

