using provaOsnildo.Domain.Entities;

namespace provaOsnildo.Application.Interfaces;

public interface ITaskRepository
{
    TaskItem Add(TaskItem task);
    IReadOnlyCollection<TaskItem> GetAllActive();
}
