using Domain.Entities;
using Domain.Models;

namespace Domain.Repositories;

public interface IProjectRepository
{
    Task<Project> GetProject(Guid id);
    Task<Project> CreateProject(Project project);
    Task<Project> UpdateProject(Project project);
    Task<Project> DeleteProject(Guid id);
    Task<List<Project>> GetProjects();
    Task<List<User>> GetProjectCollaborators(Guid projectId);
    Task<User> AddCollaboratorToProject(Guid projectId, User collaborator);
    Task<User> RemoveCollaboratorFromProject(Guid projectId, Guid collaboratorId);
}