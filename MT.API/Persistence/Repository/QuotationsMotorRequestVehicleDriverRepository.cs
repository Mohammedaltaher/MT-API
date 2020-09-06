using System.Threading.Tasks;
using AggriPortal.API.Domain.Models;


namespace  AggriPortal.API.Persistence.Repository
{
    public interface IQuotationsMotorRequestVehicleDriverRepository : IBaseRepository<QuotationsMotorRequestVehicleDriver>
    {
        Task<QuotationsMotorRequestVehicleDriver> GetByIdentityNumber(long identityNumber);
    }

    #region Implementation
    public class QuotationsMotorRequestVehicleDriverRepository: BaseRepository<QuotationsMotorRequestVehicleDriver>, IQuotationsMotorRequestVehicleDriverRepository
    {
        public QuotationsMotorRequestVehicleDriverRepository(AppDbContext context): base(context)
        {

        }

        public async Task<QuotationsMotorRequestVehicleDriver> GetByIdentityNumber(long identityNumber)
        {
            return await this.GetAsync(d => d.IdentityNumber == identityNumber);
        }
    }
    #endregion
}
