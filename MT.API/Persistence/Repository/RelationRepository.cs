using AggriPortal.API.Domain.Models;

namespace  AggriPortal.API.Persistence.Repository
{
    public interface IRelationRepository : IBaseRepository<Relation>
    {
        /// Add other interface here
    }

    #region Implementation
    public class RelationRepository: BaseRepository<Relation>, IRelationRepository
    {
        public RelationRepository(AppDbContext context)
            : base(context)
        {

        }
    }
    #endregion
}
