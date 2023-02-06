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

        public Task AddNewProjectAsync(Project project)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> AddProjectManagerAsync(string userId, int projectId)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> AddUserToProjectAsync(string userId, int projectId)
        {
            throw new System.NotImplementedException();
        }

        public Task ArchiveProjectAsync(Project project)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<TDUser>> GetAllProjectMembersExceptPMAsync(int projectId)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<Project>> GetAllProjectsByCompany(int companyId)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<Project>> GetAllProjectsByPriority(int companyId, string priorityName)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<Project>> GetArchivedProjectsByCompany(int companyId)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<TDUser>> GetDevelopersOnProjectAsync(int projectId)
        {
            throw new System.NotImplementedException();
        }

        public Task<Project> GetProjectByIdAsync(int projectId, int companyId)
        {
            throw new System.NotImplementedException();
        }

        public Task<TDUser> GetProjectManagerAsync(int projectId)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<TDUser>> GetProjectMembersByRoleAsync(int projectId, string role)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<TDUser>> GetSubmittersOnProjectAsync(int projectId)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<Project>> GetUserProjectsAsync(string userId)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<TDUser>> GetUsersNotOnProjectAsync(int projectId, int companyId)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> IsUserOnProject(string userId, int projectId)
        {
            throw new System.NotImplementedException();
        }

        public Task<int> LookupProjectPriorityId(string priorityName)
        {
            throw new System.NotImplementedException();
        }

        public Task RemoveProjectManagerAsync(int projectId)
        {
            throw new System.NotImplementedException();
        }

        public Task RemoveUserFromProjectAsync(string userId, int projectId)
        {
            throw new System.NotImplementedException();
        }

        public Task RemoveUsersFromProjectByRoleAsync(string role, int projectId)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateProjectAsync(Project project)
        {
            throw new System.NotImplementedException();
        }
    }

}
