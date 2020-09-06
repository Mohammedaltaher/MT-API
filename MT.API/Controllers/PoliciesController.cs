using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using AggriPortal.API.Contracts;
using AggriPortal.API.Contracts.Response;
using AggriPortal.API.Domain.Models;
using AggriPortal.API.Persistence;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Net;
using System;
using System.Linq;
using ReflectionIT.Mvc.Paging;
using AggriPortal.API.Resources;
using Microsoft.Extensions.Configuration;
using AggriPortal.API.Security.Permission;

namespace  AggriPortal.API.Controllers
{
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = Roles.SuperAdmin + "," + Roles.Administrator + "," + Roles.ViewPolicies)]
    public class PoliciesController : ControllerBase 
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IConfiguration configuration;


        public PoliciesController( IConfiguration configuration, IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.configuration = configuration;

        }
        [HttpPost(ApiRoute.Policy.Search)]
        public IActionResult GetPoliciesRequest([FromBody] PolicyRequestDto req)
        {
            var data = unitOfWork.PoliciesMotor.GetPolicies(req);
            if (data == null)
            {
                return NotFound(new BaseResponse(false, 404, "Previous request data was not found"));
            }
            int pageSize = req.PageSize ?? configuration.GetValue<int>("PagingOptions:PageSize");
            int pageNumber = req.PageNumber ?? configuration.GetValue<int>("PagingOptions:PageNumber");

            PoliciesMotorResponseDto response = new PoliciesMotorResponseDto()
            {
                Data = mapper.Map<IEnumerable<PoliciesMotor>, IEnumerable<PoliciesMotorDto>>(PagingList.Create(data, pageSize, pageNumber)),
                TotalRecord = data.Count(),
                IsSuccess = true,
                StatusCode = (int)HttpStatusCode.OK,
                ResponseMessage = "Request has been complited successfully"
            };


            return Ok(response);
        }
        [HttpGet(ApiRoute.Policy.Details)]
        public IActionResult GetPoliciesDetailsRequest(Guid Id)
        {
            var data = unitOfWork.PoliciesMotor.GetPoliciesDetails(Id);
            if (data == null)
            {
                return NotFound(new BaseResponse(false, 404, "Previous request data was not found"));
            }
            PoliciesMotorDetailsResponseDto response = new PoliciesMotorDetailsResponseDto()
            {
                PolicyReferenceId = data.PolicyRequestRefId,
                QuoteReferenceId = data.QuotationRequestRefId,
                PolicyNumber = data.PolicyNumber,
                InsuredInfo = mapper.Map<Client, PolicyInsuredInfoDto>(data.Client),
                VehicleInfo = mapper.Map<QuotationsMotorRequest, PolicyVehicleInfoDto>(data.ClientQuotation.QuotationsMotorRequest),
                InsuranceCompany = mapper.Map<InsuranceCompany, InsuranceCompanyDto>(data.InsuranceCompany),
                Product = new PolicyProductDto
                {
                    Name = data.ProductType.Name,
                    NameAr = data.ProductType.NameAr,
                    PolicyIssueDate = data.PolicyIssueDate,
                    PolicyEffectiveDate = data.PolicyEffectiveDate,
                    PolicyExpiryDate = data.PolicyExpiryDate,
                    Deductibles = new ProductDeductibleDto
                    {
                        DeductibleValue = data.ClientQuotation.DeductibleValue,
                        TotalPremium = data.TotalPremium,
                        PremiumBreakdowns = mapper.Map<List<ClientQuotationMotorPremiumBreakdown>, List<ProductPremiumBreakdownDto>>(data.ClientQuotation.ClientQuotationMotorPremiumBreakdowns.ToList()),
                        Discounts = mapper.Map<List<ClientQuotationMotorDiscount>, List<ProductDiscountDto>>(data.ClientQuotation.ClientQuotationMotorDiscounts.ToList())
                    },
                    Benefits = mapper.Map<List<ClientQuotationMotorBenefit>, List<ProductBenefitDto>>(data.ClientQuotation.ClientQuotationMotorBenefits.ToList()),
                },
                IsSuccess = true,
                StatusCode = 200,
                ResponseMessage = "The insurance policy was issued successfully"
            };
            return Ok(response);
        }
        [HttpGet(ApiRoute.Policy.PrintInvoice)]
        public async Task<IActionResult> PrintInvoiceRequest(Guid Id)
        {
            var data = await unitOfWork.PoliciesMotor.PrintInvoice(Id);
            PolicieInvoiceResponseDto response = new PolicieInvoiceResponseDto()
            {
                PolicyReferenceId = data.PolicyRequestRefId,
                QuoteReferenceId = data.QuotationRequestRefId,
                PolicyNumber = data.PolicyNumber,
                InvoiceDate = data.CreatedDate,
                InsuredInfo = mapper.Map<Client, PolicyInsuredInfoDto>(data.Client),
                VehicleInfo = mapper.Map<QuotationsMotorRequest, PolicyVehicleInfoDto>(data.ClientQuotation.QuotationsMotorRequest),
                InsuranceCompany = mapper.Map<InsuranceCompany, InsuranceCompanyDto>(data.InsuranceCompany),
                Product = new PolicyProductDto
                {
                    Name = data.ProductType.Name,
                    NameAr = data.ProductType.NameAr,
                    PolicyIssueDate = data.PolicyIssueDate,
                    PolicyEffectiveDate = data.PolicyEffectiveDate,
                    PolicyExpiryDate = data.PolicyExpiryDate,
                    Deductibles = new ProductDeductibleDto
                    {
                        DeductibleValue = data.ClientQuotation.DeductibleValue,
                        TotalPremium = data.TotalPremium,
                        PremiumBreakdowns = mapper.Map<List<ClientQuotationMotorPremiumBreakdown>, List<ProductPremiumBreakdownDto>>(data.ClientQuotation.ClientQuotationMotorPremiumBreakdowns.ToList()),
                        Discounts = mapper.Map<List<ClientQuotationMotorDiscount>, List<ProductDiscountDto>>(data.ClientQuotation.ClientQuotationMotorDiscounts.ToList())
                    },
                    Benefits = mapper.Map<List<ClientQuotationMotorBenefit>, List<ProductBenefitDto>>(data.ClientQuotation.ClientQuotationMotorBenefits.ToList()),
                },
                IsSuccess = true, 
                StatusCode = 200,
                ResponseMessage = "The insurance policy was issued successfully"
            };
            return Ok(response);
        }
    }
}
