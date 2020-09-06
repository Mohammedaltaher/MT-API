using AggriPortal.API.Domain.Models;

namespace  AggriPortal.API.Persistence.Repository
{
    public interface IProductTypeRepository : IBaseRepository<ProductType>
    {
        /// Add other interface here
    }

    #region Implementation
    public class ProductTypeRepository : BaseRepository<ProductType>, IProductTypeRepository
    {
        public ProductTypeRepository(AppDbContext context)
            : base(context)
        {

        }
    }
    #endregion
}
