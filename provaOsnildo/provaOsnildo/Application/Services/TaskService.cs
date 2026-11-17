using provaOsnildo.Application.DTOs;
using provaOsnildo.Application.Interfaces;
using provaOsnildo.Domain.Entities;

namespace provaOsnildo.Application.Services;

public sealed class TaskService : ITaskService
{
    private readonly ITaskRepository _repository;

    public TaskService(ITaskRepository repository)
    {
        _repository = repository;
    }

    public TaskResponse Create(CreateTaskRequest request)
    {
        var task = TaskItem.Create(
            request.Title,
            request.Description,
            request.DueDate,
            DateTimeOffset.UtcNow);

        _repository.Add(task);
        return TaskResponse.FromEntity(task);
    }

    public IReadOnlyCollection<TaskResponse> GetAll()
    {
        return _repository
            .GetAllActive()
            .OrderByDescending(task => task.CreatedAt)
            .Select(TaskResponse.FromEntity)
            .ToArray();
    }
}
