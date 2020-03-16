using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrowDo.Core.Data;
using CrowDo.Models;
using CrowDo.Options;
using CrowDo.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CrowDo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CrowDoController : ControllerBase
    {
        //private readonly IExcelIO _excelIO;
        private readonly ILogger<CrowDoController> _logger;
        private readonly IProjectService _projectService;
        private readonly IFundingPackageService _fundingPackageService;
        private readonly IUserService _userService;

        public CrowDoController(ILogger<CrowDoController> logger,
            //IExcelIO excelIO,
            IFundingPackageService fundingPackageService,
            IProjectService projectService,
            IUserService userService)
        {
            _logger = logger;
           //_excelIO = excelIO;
            _projectService = projectService;
            _fundingPackageService = fundingPackageService;
            _userService = userService;
        }



        [HttpGet]
        public String Hello()
        {
            return "Code girls welcome you!";
        }


        //[HttpGet("users / excel /{filename}")]
        //public List<User> GetCustomersFromExcel([FromRoute] string fileName)
        //{
        //    var excelIO = new ExcelIO(new CrowDoDbContext());
        //    return excelIO.ReadExcel(fileName);
        //}

        [HttpGet("users")]
        public List<User> GetUsers()
        {
            return _userService.GetUsers();
        }

        [HttpGet("user/{id}")]
        public User GetUserById(int id)
        {
            return _userService.GetUserById(id);
        }

        [HttpGet("userdetails")]
        public List<User> GetUserBy(
            [FromQuery] string firstName,
            [FromQuery] string lastName,
            [FromQuery] string email)
        {
            var options = new SearchUserOptions
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email
            };
            return _userService.SearchUser(options);
        }

        [HttpPost("user")]
        public User CreateUser(
            [FromBody] CreateUserOptions options)
        {
           return _userService.CreateUser(options);
        }

        [HttpPut("user/{id}")]
        public User CreateUser([FromRoute] int id,
            [FromBody] UpdateUserOptions options)
        {
            return _userService.UpdateUser(id, options);
        }

        //////Project

        [HttpGet("projects")]
        public List<Project> GetProjects()
        {
            return _projectService.GetProjects();
        }

        [HttpGet("project/{id}")]
        public Project GetProjectById(int id)
        {
            return _projectService.GetProjectById(id);
        }

        [HttpPost("project")]
        public int? CreateProject(
            [FromBody] CreateProjectOptions options)
        {
            return _projectService.CreateProject(options);
        }

        [HttpPut("project/{id}")]
        public Project UpdateProject([FromRoute] int id,
            [FromBody] UpdateProjectOptions options)
        {
            return _projectService.UpdateProject(id, options);
        }

        ////FundingPackage

        [HttpPost("fundingpackage")]
        public FundingPackage CreateFundingPackage(
            [FromBody] CreateFundingPackageOptions options)
        {
            return _fundingPackageService.CreateFundingPackage(options);
        }

        [HttpGet("fundingpackage/{id}")]
        public FundingPackage GetFundingPackageById(int id)
        {
            return _fundingPackageService.GetFundingPackageById(id);
        }
    }
}
    
