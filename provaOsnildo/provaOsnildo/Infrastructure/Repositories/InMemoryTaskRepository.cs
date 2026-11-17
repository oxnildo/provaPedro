using System.Collections.Concurrent;
using provaOsnildo.Application.Interfaces;
using provaOsnildo.Domain.Entities;
using provaOsnildo.Domain.Enums;
using TaskItemStatus = provaOsnildo.Domain.Enums.TaskStatus;

namespace provaOsnildo.Infrastructure.Repositories;

public sealed class InMemoryTaskRepository : ITaskRepository
{
    private readonly ConcurrentDictionary<Guid, TaskItem> _tasks = new();

    public TaskItem Add(TaskItem task)
    {
        _tasks[task.Id] = task;
        return task;
    }

    public IReadOnlyCollection<TaskItem> GetAllActive()
    {
        return _tasks.Values
            .Where(task => task.Status != TaskItemStatus.Deleted)
            .ToArray();
    }
}
