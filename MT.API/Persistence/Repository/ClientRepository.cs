using AggriPortal.API.Domain.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq.Expressions;
using LinqKit;
using System.Linq;
using ReflectionIT.Mvc.Paging;
using AggriPortal.API.Resources;
using AggriPortal.API.Contracts.Response;

namespace  AggriPortal.API.Persistence.Repository
{
    public interface IClientRepository : IBaseRepository<Client>
    {
        Task<Client> GetByIdentityNumberIncludingVehicle(long identityNumber, string birthDate, string createdBy);
        Task<Client> GetByApplicationUserId(string applicationUserId);
        IEnumerable<Client> GetClients(ClientRequestDto req);
        Client GetClientDetails(Guid id);

    }

    #region Implementation
    public class ClientRepository: BaseRepository<Client>, IClientRepository
    {
        public ClientRepository(AppDbContext context)
            : base(context)
        {

        }

        public async Task<Client> GetByApplicationUserId(string applicationUserId)
        {
            return await this.GetAsync(c => c.ApplicationUserId == applicationUserId);
        }

        public async Task<Client> GetByIdentityNumberIncludingVehicle(long identityNumber, string birthDate, string createdBy)
        {
            //return await this.Include(p => p.IdentityNumber == identityNumber, d => d.ClientVehicles).FirstOrDefaultAsync();
            return await this.GetMany(p => p.IdentityNumber == identityNumber && p.BirthDate == birthDate && p.CreatedBy == createdBy).Include(p=>p.ClientVehicles).FirstOrDefaultAsync();
        }
        public IEnumerable<Client> GetClients(ClientRequestDto req)
        {

            Expression<Func<Client, bool>> predicate = c => true;

            if (!string.IsNullOrEmpty(req.Name))
            {
                predicate = predicate.And(p => p.FirstName.Contains(req.Name) || p.MiddleName.Contains(req.Name) || p.LastName.Contains(req.Name) || p.FirstNameAr.Contains(req.Name) || p.MiddleNameAr.Contains(req.Name) || p.LastNameAr.Contains(req.Name));
            }
            if (!string.IsNullOrEmpty(req.Email))
            {
                predicate = predicate.And(p => p.Email == req.Email);
            }
            if (!string.IsNullOrEmpty(req.PhoneNumber))
            {
                predicate = predicate.And(p => p.PhoneNumber == req.PhoneNumber);
            }
            if (!string.IsNullOrEmpty(req.BirthDate))
            {
                predicate = predicate.And(p => p.BirthDate == req.BirthDate);
            }
            if (req.NationalityId != null)
            {
                predicate = predicate.And(p => p.NationalityId == req.NationalityId);
            }
            if (req.IdentityNumber != null)
            {
                predicate = predicate.And(p => p.IdentityNumber == req.IdentityNumber);
            }
            if (req.EducationLevelId != null)
            {
                predicate = predicate.And(p => p.EducationLevelId == req.EducationLevelId);
            }
            if (req.IdentityTypeId != null)
            {
                predicate = predicate.And(p => p.IdentityTypeId == req.IdentityTypeId);
            }
            if (req.DateFrom != null && req.DateTo != null)
            {
                predicate = predicate.And(p => p.CreatedDate.Date >= req.DateFrom.Value.Date && p.CreatedDate.Date <= req.DateTo.Value.Date);
            }
            var data = this.GetMany(predicate)
                .Include("IdentityType").Include("Gender").Include("IdentityIssuePlace")
                .Include("WorkCity").Include("Nationality").Include("SocialStatus")
                .Include("SocialStatus").Include("EducationLevel").Include("QuotationsMotorRequests").Include("PolicyRequests").Include("ApplicationUser").OrderBy(o => o.CreatedDate).OrderBy(o => o.CreatedBy);
            return data;
        }
        public Client GetClientDetails(Guid id)
        {

            var data = this.GetMany(p => p.Id == id)
                .Include("ApplicationUser")
                .Include("IdentityType")
                .Include("Gender")
                .Include("IdentityIssuePlace")
                .Include("WorkCity")
                .Include("Nationality")
                .Include("SocialStatus")
                .Include("SocialStatus")
                .Include("EducationLevel")
                .FirstOrDefault();
            return data;
        }
    
    }

    #endregion
}
