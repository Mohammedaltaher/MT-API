
using AggriPortal.API.Contracts.Response;
using AggriPortal.API.Domain.Dtos;
using System;
using System.Collections.Generic;

namespace  AggriPortal.API.Resources
{
    public class DashboardRequestDto
    {
        public DashboardRequestDto()
        {
            Year = DateTime.Now.Year;
        }
        public int Year { get; set; }
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }
    }
    public class DashboardResponseDto : BaseResponse
    {
        public DashboardDto Data { get; set; }
    }
    public class DashboardDto 
    {
        public int TotalClients { get; set; }
        public int TotalPolicies { get; set; }
        public int ActiveQuotation { get; set; }
        public int ExpiringPolicies { get; set; }

        public IEnumerable<LatestActiveQuotationsDto> LatestActiveQuotations { get; set; }
        public IEnumerable<ChartDto> PoliciesChart { get; set; }
        public IEnumerable<ChartDto> QuotitionRequestChart { get; set; }
     
    }
   
    public class LatestActiveQuotationsDto
    {
        public string Id { get; set; }
        public string ClientName { get; set; }
        public string ClientNameAr { get; set; }
        public long VechicleId { get; set; }
        public string InsuranceCompanyName { get; set; }
        public string InsuranceCompanyNameAr { get; set; }
        public decimal DeductibleValue { get; set; }
        public decimal TotalPremium { get; set; }
        public int StatusId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
    }
    
    public class QuotationRequestChartDto
    {
        public string Name { get; set; }
        public string Value { get; set; }

    }
}

