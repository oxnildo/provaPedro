using Microsoft.AspNetCore.Mvc;
using provaOsnildo.Application.DTOs;
using provaOsnildo.Application.Interfaces;
using provaOsnildo.Domain.Exceptions;

namespace provaOsnildo.Controllers;

[ApiController]
[Route("api/tasks")]
public sealed class TasksController : ControllerBase
{
    private readonly ITaskService _service;

    public TasksController(ITaskService service)
    {
        _service = service;
    }

    [HttpPost]
    [ProducesResponseType(typeof(TaskResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<TaskResponse> Create([FromBody] CreateTaskRequest request)
    {
        try
        {
            var response = _service.Create(request);
            return Created($"/api/tasks/{response.Id}", response);
        }
        catch (DomainValidationException exception)
        {
            return BadRequest(new ValidationProblemDetails(new Dictionary<string, string[]>
            {
                [exception.Field] = new[] { exception.Message }
            }));
        }
    }

    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyCollection<TaskResponse>), StatusCodes.Status200OK)]
    public ActionResult<IReadOnlyCollection<TaskResponse>> GetAll()
    {
        return Ok(_service.GetAll());
    }
}
