using System.Collections.Generic;
using AutoMapper;
using AggriPortal.API.Contracts;
using AggriPortal.API.Contracts.Response;
using AggriPortal.API.Domain.Models;
using AggriPortal.API.Persistence;
using AggriPortal.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Logging;
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
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = Roles.SuperAdmin + "," + Roles.Administrator + "," + Roles.ViewQuotations)]
    public class QuotationController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IIdentityService identityService;
        private readonly ILogger _logger;
        private readonly IConfiguration configuration;

        public QuotationController(ILogger<LoggerController> logger, IGatewayService gatewayService, IConfiguration configuration, IUnitOfWork unitOfWork, IMapper mapper, IIdentityService identityService)
        {
            _logger = logger;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.identityService = identityService;
            this.configuration = configuration;

        }

        [HttpPost(ApiRoute.Quotation.Search)]
        public IActionResult GetQuotationsRequest([FromBody] QuotationRequestDto req)
        {
            var data = unitOfWork.ClientQuotation.GetQuotations(req);
            if (data == null)
            {
                return NotFound(new BaseResponse(false, 404, "Previous request data was not found"));
            }
            int pageSize = req.PageSize ?? configuration.GetValue<int>("PagingOptions:PageSize");
            int pageNumber = req.PageNumber ?? configuration.GetValue<int>("PagingOptions:PageNumber");

            QuotationsMotorResponseDto response = new QuotationsMotorResponseDto()
            {
                Data = mapper.Map<IEnumerable<ClientQuotationMotor>, IEnumerable<ClientQuotationsMotorDto>>(PagingList.Create(data, pageSize, pageNumber)),
                TotalRecord = data.Count(),
                IsSuccess = true,
                StatusCode = (int)HttpStatusCode.OK,
                ResponseMessage = "Request has been complited successfully"
            };
            return Ok(response);
        }
        [HttpGet(ApiRoute.Quotation.Details)]
        public IActionResult GetQuotationtDetailsRequest(Guid Id)
        {
            var data =  unitOfWork.ClientQuotation.GetClientQuotation(Id);
            if (data == null)
            {
                return NotFound(new BaseResponse(false, 404, " "));
            }
            QuotationsMotorDetailsResponseDto response = new QuotationsMotorDetailsResponseDto
            {
                ReferenceId = data.Id,
                InsuredInfo = mapper.Map<Client, InsuredInfoDto>(data.Client),
                VehicleInfo = mapper.Map<QuotationsMotorRequest, VehicleInfoDto>(data.QuotationsMotorRequest),
                VehicleDrivers = mapper.Map<IEnumerable<QuotationsMotorRequestVehicleDriver>, IEnumerable<VechicleDriversDto>>(data.QuotationsMotorRequest.QuotationsMotorRequestVehicleDrivers),
                QuoteInfo = new PreviewQuoteDto()
                {
                    InsuranceCompany = mapper.Map<InsuranceCompany, InsuranceCompanyDto>(data.InsuranceCompany),
                    QuotationReqtId = data.QuotationRequestId,
                    QuoteReferenceId = data.QuoteReferenceId,
                    InsuranceCompanyId = data.InsuranceCompanyId,
                    QuotationStartDate = data.QuotationStartDate,
                    QuotationEndDate = data.QuotationEndDate,
                    Product = new PreviewQuoteProductDto
                    {
                        Name = data.QuotationsMotorResponseProduct.ProductType.Name,
                        NameAr = data.QuotationsMotorResponseProduct.ProductType.NameAr,
                        ProductTypeId = data.QuotationsMotorResponseProduct.ProductTypeId,
                        QuotationProductId = data.QuotationProductId,
                        PolicyEffectiveDate = data.QuotationsMotorResponseProduct.PolicyEffectiveDate,
                        PolicyExpiryDate = data.QuotationsMotorResponseProduct.PolicyExpiryDate,
                        Deductibles = new ProductDeductibleDto
                        {
                            DeductibleValue = data.DeductibleValue,
                            MaxLiability = data.MaxLiability,
                            TotalPremium = data.TotalPremium,
                            PremiumBreakdowns = mapper.Map<List<ClientQuotationMotorPremiumBreakdown>, List<ProductPremiumBreakdownDto>>(data.ClientQuotationMotorPremiumBreakdowns.ToList()),
                            Discounts = mapper.Map<List<ClientQuotationMotorDiscount>, List<ProductDiscountDto>>(data.ClientQuotationMotorDiscounts.ToList())
                        },
                        Benefits = mapper.Map<List<ClientQuotationMotorBenefit>, List<ProductBenefitDto>>(data.ClientQuotationMotorBenefits.ToList()),
                    }
                },
                IsSuccess = true,
                StatusCode = 200,
                ResponseMessage = "Quotation request completed successfully"
            };
            return Ok(response);
        }
    }
}
