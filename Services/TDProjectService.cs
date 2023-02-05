using System.Collections.Generic;
using System.Threading.Tasks;
using Twoishday.Data;
using Twoishday.Models;
using Twoishday.Services.Interfaces;

namespace Twoishday.Services
{
    public class TDProjectService : ITDProjectService
    {

        private readonly ApplicationDbContext _context;

        public TDProjectService(ApplicationDbContext context)
        {
            _context = context;
        }

        Task ITDProjectService.AddNewProjectAsync(Project project)
        {
            throw new System.NotImplementedException();
        }

        Task<bool> ITDProjectService.AddProjectManagerAsync(string userId, int projectId)
        {
            throw new System.NotImplementedException();
        }

        Task<bool> ITDProjectService.AddUserToProjectAsync(string userId, int projectId)
        {
            throw new System.NotImplementedException();
        }

        Task ITDProjectService.ArchiveProjectAsync(Project project)
        {
            throw new System.NotImplementedException();
        }

        Task<List<TDUser>> ITDProjectService.GetAllProjectMembersExceptPMAsync(int projectId)
        {
            throw new System.NotImplementedException();
        }

        Task<List<Project>> ITDProjectService.GetAllProjectsByCompany(int companyId)
        {
            throw new System.NotImplementedException();
        }

        Task<List<Project>> ITDProjectService.GetAllProjectsByPriority(int companyId, string priorityName)
        {
            throw new System.NotImplementedException();
        }

        Task<List<Project>> ITDProjectService.GetArchivedProjectsByCompany(int companyId)
        {
            throw new System.NotImplementedException();
        }

        Task<List<TDUser>> ITDProjectService.GetDevelopersOnProjectAsync(int projectId)
        {
            throw new System.NotImplementedException();
        }

        Task<Project> ITDProjectService.GetProjectByIdAsync(int projectId, int companyId)
        {
            throw new System.NotImplementedException();
        }

        Task<TDUser> ITDProjectService.GetProjectManagerAsync(int projectId)
        {
            throw new System.NotImplementedException();
        }

        Task<List<TDUser>> ITDProjectService.GetProjectMembersByRoleAsync(int projectId, string role)
        {
            throw new System.NotImplementedException();
        }

        Task<List<TDUser>> ITDProjectService.GetSubmittersOnProjectAsync(int projectId)
        {
            throw new System.NotImplementedException();
        }

        Task<List<Project>> ITDProjectService.GetUserProjectsAsync(string userId)
        {
            throw new System.NotImplementedException();
        }

        Task<List<TDUser>> ITDProjectService.GetUsersNotOnProjectAsync(int projectId, int companyId)
        {
            throw new System.NotImplementedException();
        }

        Task<bool> ITDProjectService.IsUserOnProject(string userId, int projectId)
        {
            throw new System.NotImplementedException();
        }

        Task<int> ITDProjectService.LookupProjectPriorityId(string priorityName)
        {
            throw new System.NotImplementedException();
        }

        Task ITDProjectService.RemoveProjectManagerAsync(int projectId)
        {
            throw new System.NotImplementedException();
        }

        Task ITDProjectService.RemoveUserFromProjectAsync(string userId, int projectId)
        {
            throw new System.NotImplementedException();
        }

        Task ITDProjectService.RemoveUsersFromProjectByRoleAsync(string role, int projectId)
        {
            throw new System.NotImplementedException();
        }

        Task ITDProjectService.UpdateProjectAsync(Project project)
        {
            throw new System.NotImplementedException();
        }
    }
}
