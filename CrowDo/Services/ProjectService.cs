using CrowDo.Core.Data;
using CrowDo.Models;
using CrowDo.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace CrowDo.Services
{
    public class ProjectService : IProjectService
    {
        private readonly CrowDoDbContext context_;
        private readonly IUserService user_;
        //private readonly IFundingPackageService fundingPackage_;

        public ProjectService(
            CrowDoDbContext context,
            IUserService users//,
            //IFundingPackageService fundingPackages
            )
        {
            context_ = context;
            user_ = users;
            //fundingPackage_ = fundingPackages;
        }

        public int? CreateProject(CreateProjectOptions projectOptions/*, CreateFundingPackageOptions fundOptions*/)
        {
            if (projectOptions == null)
            {
                return null;
            }
            if (string.IsNullOrWhiteSpace(projectOptions.Title) ||
               projectOptions.Budget <= 0 ||
               string.IsNullOrWhiteSpace(projectOptions.Description)||
                   projectOptions.UserId==0)

            {
                return null;
            }



            var project = new Project()
            {
                Title = projectOptions.Title,
                Budget = projectOptions.Budget,
                Description = projectOptions.Description,
                Category = ProjectCategory.Comics,//Category=projectOptions.category .tostring
                CreationDate = DateTime.Now,
                User = context_.Set<User>().Find(projectOptions.UserId)
                     
            };


            //foreach (var package in projectOptions.FundingPackageIds)
            //{
            //    var fundingPackageResult = fundingPackage_
            //        .CreateFundingPackage(fundOptions);

            //    project.ProjectFundingPackages.Add(
            //        new ProjectFundingPackage()
            //        {
            //            FundingPackage = fundingPackageResult
            //        });
            //    context_.SaveChanges();
            //}




            context_.Set<Project>(). Add(project);
            
            context_.SaveChanges();
            return project.Id;
        }

        public List<Project> SearchProject(
         SearchProjectOptions projectOptions)
        {
            if (projectOptions == null)
            {
                return null;
            }

            if (projectOptions.ProjectId == null
                && projectOptions.UserId == null)
            {
                return null;
            }

            var query = context_
                 .Set<Project>()
                 .AsQueryable();

            if (projectOptions.UserId != 0)
            {
                query = query.Where(
                    c => c.User.Id == projectOptions.UserId);
            }

            if (projectOptions.ProjectId != 0)
            {
                query = query.Where(
                    c => c.Id == projectOptions.ProjectId);
            }

            if (!string.IsNullOrWhiteSpace(projectOptions.Description))
            {
                query = query
                      .Where(c => c.Description.Contains(projectOptions.Description));
            }

            if (!string.IsNullOrWhiteSpace(projectOptions.Title))
            {
                query = query
                      .Where(c => c.Title.Contains(projectOptions.Title));
            }
            //to be checked
            if (projectOptions.StatusProject == StatusProject.Available)
            {
                query = query
                      .Where(c => c.StatusProject.Equals(projectOptions.StatusProject));
            }

            if (!projectOptions.Category.Equals(ProjectCategory.Invalid))
            {
                query = query
                     .Where(c => c.StatusProject.Equals(projectOptions.StatusProject));
            }

            return query.ToList();
        }

        public Project UpdateProject(
            int projectId, UpdateProjectOptions projectOptions)
        {
            if (projectOptions == null)
            {
                return null;
            }
            var project = GetProjectById(projectId);

            if (project == null)
            {
                return null;
            }

            if (!string.IsNullOrWhiteSpace(projectOptions.Description))
            {
                project.Description = projectOptions.Description;
            }

            if (!string.IsNullOrWhiteSpace(projectOptions.Title))
            {
                project.Title = projectOptions.Title;
            }

            //if (options.StatusProject.HasValue)
            //{
            //    project.StatusProject.Equals(options.StatusProject);
            //} must be a function in case a project budget is accomplished
                        
            context_.SaveChanges();
            return project;
        }

        public Project GetProjectById(int id)
        {
            var project = context_
                .Set<Project>()
                .SingleOrDefault(p => p.Id == id);
            if (project == null)
            {
                return null;
            }
            return project;
        }

        public List<Project> GetProjects()
        {
            return context_.Set<Project>()
                    .ToList();
        }
    }
}