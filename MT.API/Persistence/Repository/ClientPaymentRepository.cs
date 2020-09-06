using AggriPortal.API.Domain.Models;
using System.Collections.Generic;
using System;
using Microsoft.EntityFrameworkCore;
using AggriPortal.API.Resources;
using System.Linq;

namespace  AggriPortal.API.Persistence.Repository
{
    public interface IClientPaymentRepository : IBaseRepository<ClientPayment>
    {
        IEnumerable<ClientPayment> GetClientInvoices(ClientInvoicesRequestDto req);
        /// Add other interface here
    }

    #region Implementation
    public class ClientPaymentRepository : BaseRepository<ClientPayment>, IClientPaymentRepository
    {
        public ClientPaymentRepository(AppDbContext context)
            : base(context)
        {

        }
        public IEnumerable<ClientPayment> GetClientInvoices(ClientInvoicesRequestDto req)
        {
            if(req.Status == null)
                return this.GetMany(p => p.ClientId == req.ClientId)
            .Include("Client")
            .Include("Client.ApplicationUser")
            .Include("PaymentMethod")
            .Include("ClientQuotation.QuotationsMotorResponseProduct.ProductType")
            .Include("ClientQuotation.InsuranceCompany")
            .Include("Bank");

            return this.GetMany(p => p.ClientId == req.ClientId && req.Status.Contains(p.PaymentStatusId))
            .Include("Client")
            .Include("Client.ApplicationUser")
            .Include("PaymentMethod")
            .Include("ClientQuotation.QuotationsMotorResponseProduct.ProductType")
            .Include("ClientQuotation.InsuranceCompany")
            .Include("Bank"); 
        }

    }
    #endregion
}
