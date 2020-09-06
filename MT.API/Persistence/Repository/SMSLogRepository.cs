using AggriPortal.API.Domain.Models;
using System.Collections.Generic;
using System.Linq.Expressions;
using System;
using System.Linq;
using LinqKit;
using AggriPortal.API.Resources;

namespace  AggriPortal.API.Persistence.Repository
{
    public interface ISMSLogRepository : IBaseRepository<SMSLog>
    {
        /// Add other interface here
        IEnumerable<SMSLog> GetSMSLog(SMSLogRequestDto req);
    }

    #region Implementation
    public class SMSLogRepository: BaseRepository<SMSLog>, ISMSLogRepository
    {
        public SMSLogRepository(AppDbContext context)
            : base(context)
        {

        }
        public IEnumerable<SMSLog> GetSMSLog(SMSLogRequestDto req)
        {

            Expression<Func<SMSLog, bool>> predicate = c => true;
            if (!string.IsNullOrEmpty(req.SmsTo))
            {
                predicate = predicate.And(p => p.SmsTo == req.SmsTo);
            }
            if (!string.IsNullOrEmpty(req.Status))
            {
                predicate = predicate.And(p => p.Status == req.Status);
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
