namespace provaOsnildo.Application.DTOs;

public sealed class CreateTaskRequest
{
    public string? Title { get; init; }
    public string? Description { get; init; }
    public DateTimeOffset? DueDate { get; init; }
}
