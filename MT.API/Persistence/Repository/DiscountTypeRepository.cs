using AggriPortal.API.Domain.Models;

namespace  AggriPortal.API.Persistence.Repository
{
    public interface IDiscountTypeRepository : IBaseRepository<DiscountType>
    {
        /// Add other interface here
    }

    public class DiscountTypeRepository: BaseRepository<DiscountType>, IDiscountTypeRepository
    {
        public DiscountTypeRepository(AppDbContext context)
            : base(context)
        {

        }

        /// Interface implemenation
    }
}
