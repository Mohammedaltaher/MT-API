using AggriPortal.API.Domain.Models;

namespace  AggriPortal.API.Persistence.Repository
{
    public interface IPaymentMethodRepository : IBaseRepository<PaymentMethod>
    {
        /// Add other interface here
    }

    #region Implementation
    public class PaymentMethodRepository: BaseRepository<PaymentMethod>, IPaymentMethodRepository
    {
        public PaymentMethodRepository(AppDbContext context)
            : base(context)
        {

        }
    }
    #endregion
}
