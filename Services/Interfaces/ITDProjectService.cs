﻿using Microsoft.CodeAnalysis;
using System.Collections.Generic;
using System.Threading.Tasks;
using Twoishday.Models;
using Project = Twoishday.Models.Project;

namespace Twoishday.Services.Interfaces
{
    public interface ITDProjectService
    {
        public Task AddNewProjectAsync(Project project);

        public Task<bool> AddProjectManagerAsync(string userId, int projectId);

        public Task<bool> AddUserToProjectAsync(string userId, int projectId);

        public Task ArchiveProjectAsync(Project project);

        public Task<List<Project>> GetAllProjectsByCompany(int companyId);

        public Task<List<Project>> GetAllProjectsByPriority(int companyId, string priorityName);

        public Task<List<TDUser>> GetAllProjectMembersExceptPMAsync(int projectId);

        public Task<List<Project>> GetArchivedProjectsByCompany(int companyId);

        public Task<List<TDUser>> GetDevelopersOnProjectAsync(int projectId);

        public Task<TDUser> GetProjectManagerAsync(int projectId);

        public Task<List<TDUser>> GetProjectMembersByRoleAsync(int projectId, string role);

        public Task<Project> GetProjectByIdAsync(int projectId, int companyId);

        public Task<List<TDUser>> GetSubmittersOnProjectAsync(int projectId);

        public Task<List<TDUser>> GetUsersNotOnProjectAsync(int projectId, int companyId);

        public Task<List<Project>> GetUserProjectsAsync(string userId);

        public Task<bool> IsUserOnProject(string userId, int projectId);

        public Task<int> LookupProjectPriorityId(string priorityName);

        public Task RemoveProjectManagerAsync(int projectId);

        public Task RemoveUsersFromProjectByRoleAsync(string role, int projectId);

        public Task RemoveUserFromProjectAsync(string userId, int projectId);

        public Task UpdateProjectAsync(Project project);



    }
}