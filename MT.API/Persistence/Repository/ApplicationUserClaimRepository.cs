using AggriPortal.API.Domain.Models;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;


namespace  AggriPortal.API.Persistence.Repository
{
    public interface IApplicationUserClaimRepository : IBaseRepository<ApplicationUserClaim>
    {
        /// Add other interface here
        Task<IEnumerable<ApplicationUserClaim>> GetUsersClaimByUserType(string ClaimValue);
    }

    #region Implementation
    public class ApplicationUserClaimRepository : BaseRepository<ApplicationUserClaim>, IApplicationUserClaimRepository
    {
        public ApplicationUserClaimRepository(AppDbContext context)
            : base(context)
        {

        }
        public async Task<IEnumerable<ApplicationUserClaim>> GetUsersClaimByUserType(string ClaimValue)
        {
            try
            {
              //  return await this.GetMany(p => p.ClaimValue == ClaimValue).ToListAsync();
               return await this.GetAllAsync();
            }
            catch (Exception e)
            {

                throw e;
            }
            
        }

    }
    #endregion
}
