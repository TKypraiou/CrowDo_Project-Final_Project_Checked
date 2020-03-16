using CrowDo.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace CrowDo.Models
{
    public class CreateProjectOptions
    {
       

        public string Title { get; set; }
        public decimal Budget { get; set; }
        public string Description { get; set; }
       
        public int UserId { get; set; }
        public int Category { get; set; }
        //public List<int> FundingPackageIds { get; set; }
        //public DateTime CreationDate { get; set; }

        // public int Id { get; set; }





        //public List<FundingPackage> FundingPackages { get; set; }
        //public decimal FixedPackageAmount { get; set; }
    }
}
