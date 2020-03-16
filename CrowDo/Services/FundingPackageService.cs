using CrowDo.Core.Data;
using CrowDo.Models;
using CrowDo.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace CrowDo.Services
{
    public class FundingPackageService : IFundingPackageService
    {
        private readonly CrowDoDbContext context_;
        private readonly IUserService user_;
        private readonly IProjectService project_;
        public FundingPackageService(
            CrowDoDbContext context,
            IUserService users,
            IProjectService projects)
        {
            context_ = context;
            user_ = users;
            project_ = projects;
        }

        //Project Creator creates a FundingPackage
        public FundingPackage CreateFundingPackage(
            CreateFundingPackageOptions fundOptions)
        {
            //Elegxos gia null options
            if (fundOptions == null)
            {
                return null;
            }
            //var projectId = project_.GetProjectById(fundOptions.ProjectId);

            if (fundOptions.FixedPackageAmount == 0m ||
                string.IsNullOrEmpty(fundOptions.DescriptionGift))
            {
                return null;
            }

            var fundingPackage = new FundingPackage()
            {
                FixedPackageAmount = fundOptions.FixedPackageAmount,
                DescriptionGift = fundOptions.DescriptionGift
            };

            context_.Add(fundingPackage);
            context_.SaveChanges();
            return fundingPackage;
        }

        //Connects Backer's Id with FundingPackageId
        //Each FundingPackage is unique and assiassigned only at ONE Backer
        //public FundingPackage Fund(int userId, int fundId)
        //{
        //    var user = user_.GetUserById(userId);
        //    var funding = context_
        //        .Set<FundingPackage>()
        //        .Find(fundId);
        //    //the funding is assigned only if it is not already assigned
        //    if (funding.User != null)
        //        return null;
        //    funding.User = user;
        //    context_.SaveChanges();
        //    return funding;
        //}


        //Backer can find funding packages based on ProjectId
        public List<FundingPackage> SearchFundingPackage(
            SearchFundingPackageOptions fundOptions)
        {
            if (fundOptions == null)
            {
                return null;
            }
            var query = context_
                .Set<FundingPackage>()
                .AsQueryable();
            var projectResult = project_.GetProjectById(fundOptions.ProjectId);
            if (projectResult.Id != 0)
            {
                query = query.Where(
                    c => c.Id == projectResult.Id);
            }
            return query.ToList();
        }

        public FundingPackage GetFundingPackageById(int id)
        {
            var fundingPackage = context_
                .Set<FundingPackage>().
                SingleOrDefault(s => s.Id == id);
            if (fundingPackage == null)
            {
                return null;
            }
            return fundingPackage;
        }
        //Project Creator can update a funding package's Deposit & GiftDescription by fundingPackage Id
        //public bool UpdateFundingPackage(
        //    UpdateFundingPackageOptions options, int id)
        //{
        //    if (options == null)
        //    {
        //        return false;
        //    }
        //    var fundingPackage = context_
        //        .Set<FundingPackage>()
        //        .SingleOrDefault(s => s.Id == id);
        //    if (fundingPackage == null)
        //    {
        //        return false;
        //    }
        //    if (options.Deposit != 0)
        //    {
        //        fundingPackage.Deposit = options.Deposit;
        //    }
        //    if (!string.IsNullOrWhiteSpace(options.GiftDescription))
        //    {
        //        fundingPackage.GiftDescription = options.GiftDescription;
        //    }
        //    return true;
        //}
    }
}