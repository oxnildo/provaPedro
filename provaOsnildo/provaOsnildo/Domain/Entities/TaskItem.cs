using provaOsnildo.Domain.Enums;
using provaOsnildo.Domain.Exceptions;
using TaskItemStatus = provaOsnildo.Domain.Enums.TaskStatus;

namespace provaOsnildo.Domain.Entities;

public sealed class TaskItem
{
    private TaskItem(
        Guid id,
        string title,
        string? description,
        DateTimeOffset? dueDate,
        DateTimeOffset createdAt)
    {
        Id = id;
        Title = title;
        Description = description;
        DueDate = dueDate;
        CreatedAt = createdAt;
        Status = TaskItemStatus.Pending;
    }

    public Guid Id { get; }
    public string Title { get; private set; }
    public string? Description { get; private set; }
    public TaskItemStatus Status { get; private set; }
    public DateTimeOffset? DueDate { get; private set; }
    public DateTimeOffset CreatedAt { get; }

    public static TaskItem Create(
        string? title,
        string? description,
        DateTimeOffset? dueDate,
        DateTimeOffset now)
    {
        var normalizedTitle = title?.Trim();
        if (string.IsNullOrWhiteSpace(normalizedTitle))
        {
            throw new DomainValidationException("title", "O título é obrigatório.");
        }

        if (normalizedTitle.Length > 100)
        {
            throw new DomainValidationException("title", "O título deve ter no máximo 100 caracteres.");
        }

        var normalizedDescription = description?.Trim();
        if (normalizedDescription?.Length > 500)
        {
            throw new DomainValidationException("description", "A descrição deve ter no máximo 500 caracteres.");
        }

        var utcNow = now.ToUniversalTime();
        var normalizedDueDate = dueDate?.ToUniversalTime();
        if (normalizedDueDate.HasValue && normalizedDueDate.Value < utcNow)
        {
            throw new DomainValidationException("dueDate", "O prazo não pode estar no passado.");
        }

        return new TaskItem(
            Guid.NewGuid(),
            normalizedTitle,
            string.IsNullOrEmpty(normalizedDescription) ? null : normalizedDescription,
            normalizedDueDate,
            utcNow);
    }

    public void Complete()
    {
        EnsureNotDeleted();

        if (Status == TaskItemStatus.Completed)
        {
            throw new DomainValidationException("status", "A tarefa já está concluída.");
        }

        Status = TaskItemStatus.Completed;
    }

    public void Delete()
    {
        EnsureNotDeleted();
        Status = TaskItemStatus.Deleted;
    }

    private void EnsureNotDeleted()
    {
        if (Status == TaskItemStatus.Deleted)
        {
            throw new DomainValidationException("status", "Uma tarefa excluída não pode ser alterada.");
        }
    }
}
