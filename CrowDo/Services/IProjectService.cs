using CrowDo.Models;
using CrowDo.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace CrowDo.Services
{
    public interface IProjectService
    {
        public int? CreateProject(
            CreateProjectOptions options/*, CreateFundingPackageOptions fundOptions*/);
        public List<Project> SearchProject(
         SearchProjectOptions options);
        public Project UpdateProject(
            int projectId, UpdateProjectOptions options);
        public Project GetProjectById(int id);
        public List<Project> GetProjects();
    }
}