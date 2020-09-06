using AggriPortal.API.Domain.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using LinqKit;
using System.Linq.Expressions;
using AggriPortal.API.Resources;

namespace  AggriPortal.API.Persistence.Repository
{
    public interface IAPILogHistoryRepository : IBaseRepository<APILogHistory>
    {
        /// Add other interface here
        IEnumerable<APILogHistory> GetLogHistory(APILogHistoryRequestDto req);
    }

    #region Implementation
    public class APILogHistoryRepository : BaseRepository<APILogHistory>, IAPILogHistoryRepository
    {
        public APILogHistoryRepository(AppDbContext context)
            : base(context)
        {

        }
        public IEnumerable<APILogHistory> GetLogHistory(APILogHistoryRequestDto req)
        {

            Expression<Func<APILogHistory, bool>> predicate = c => true;

            if (!string.IsNullOrEmpty(req.Method))
            {
                predicate = predicate.And(p => p.Method == req.Method);
            }
            if (req.StatusCode != null)
            {
                predicate = predicate.And(p => p.StatusCode == req.StatusCode);
            }
            if (req.DateFrom != null && req.DateTo != null)
            {
                predicate = predicate.And(p => p.CreatedDate.Date >= req.DateFrom.Value.Date && p.CreatedDate.Date <= req.DateTo.Value.Date);
            }
            var data = this.GetMany(predicate).OrderByDescending(p => p.CreatedDate);

            return data;
        }

    }
    #endregion
}
