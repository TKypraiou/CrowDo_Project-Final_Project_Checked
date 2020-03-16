using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrowDo.Models
{
    public class FundingPackage
    {
        public int Id { get; set; }
       
        public decimal Deposit { get; set; }
        public string DescriptionGift { get; set; }
        public decimal FixedPackageAmount { get; set; }
        public List<ProjectFundingPackage> ProjectFundingPackage { get; set; }

    }
}
