using provaOsnildo.Application.DTOs;

namespace provaOsnildo.Application.Interfaces;

public interface ITaskService
{
    TaskResponse Create(CreateTaskRequest request);
    IReadOnlyCollection<TaskResponse> GetAll();
}
