using provaOsnildo.Domain.Entities;
using provaOsnildo.Domain.Enums;
using TaskItemStatus = provaOsnildo.Domain.Enums.TaskStatus;

namespace provaOsnildo.Application.DTOs;

public sealed record TaskResponse(
    Guid Id,
    string Title,
    string? Description,
    TaskItemStatus Status,
    DateTimeOffset? DueDate,
    DateTimeOffset CreatedAt)
{
    public static TaskResponse FromEntity(TaskItem task) => new(
        task.Id,
        task.Title,
        task.Description,
        task.Status,
        task.DueDate,
        task.CreatedAt);
}
