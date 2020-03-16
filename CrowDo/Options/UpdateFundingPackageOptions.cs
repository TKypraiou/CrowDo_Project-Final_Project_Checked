using CrowDo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace CrowDo.Options
{
    public class UpdateFundingPackageOptions
    {
        public int Id { get; set; }
        public Project User { get; set; }
        public Project Project { get; set; }
        public decimal Deposit { get; set; }
        public string DescriptionGift { get; set; }
    }
}
