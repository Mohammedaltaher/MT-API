﻿using AggriPortal.API.Domain.Models;

namespace  AggriPortal.API.Persistence.Repository
{
    public interface IInsuranceCompanyRepository : IBaseRepository<InsuranceCompany>
    {
        /// Add other interface here
    }

    #region Implementation
    public class InsuranceCompanyRepository: BaseRepository<InsuranceCompany>, IInsuranceCompanyRepository
    {
        public InsuranceCompanyRepository(AppDbContext context)
            : base(context)
        {

        }
    }
    #endregion
}
