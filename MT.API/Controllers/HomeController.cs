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
using AggriPortal.API.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace  AggriPortal.API.Controllers
{
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class HomeController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IConfiguration configuration;
        public HomeController( IConfiguration configuration, IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.configuration = configuration;
        }

        [HttpPost(ApiRoute.Home.Dashboard)]
        public async Task<IActionResult> DashboardRequest([FromBody] DashboardRequestDto req)
        {
            var clients = await unitOfWork.Client.GetMany(p=>p.CreatedDate.Date.Year == req.Year).ToListAsync();
            var policies = await unitOfWork.PoliciesMotor.GetMany(p => p.CreatedDate.Date.Year == req.Year).ToListAsync();
            var ActiveQuotation = unitOfWork.ClientQuotation.GetMany(p => p.StatusId != (int)ClientQuotationStatusEnum.Purchased && p.CreatedDate.Date.Year == req.Year).Count();
            var LatestActiveQuotations = await unitOfWork.ClientQuotation.GetlatestQuotation(req.Year);
            var expiringPolicies = await unitOfWork.PoliciesMotor.GetExpiredPoliciesInclude(req.Year); 
            var PoliciesChart = await unitOfWork.PoliciesMotor.GetPoliciesChart(req.Year);
            var QuotitionRequestChart = await unitOfWork.PoliciesMotor.GetQuotitionRequestChart(req.Year);

            int pageSize = req.PageSize ?? configuration.GetValue<int>("PagingOptions:PageSize");
            int pageNumber = req.PageNumber ?? configuration.GetValue<int>("PagingOptions:PageNumber");

            DashboardDto data = new DashboardDto()
            {
                LatestActiveQuotations = mapper.Map<IEnumerable<ClientQuotationMotor>, IEnumerable<LatestActiveQuotationsDto>>(PagingList.Create(LatestActiveQuotations, pageSize, pageNumber)),

                PoliciesChart = PoliciesChart.ToList(),
                QuotitionRequestChart = QuotitionRequestChart.ToList(),
                TotalClients = clients.Count(),
                TotalPolicies = policies.Count(),
                ActiveQuotation = ActiveQuotation,
                ExpiringPolicies = expiringPolicies.Count()
            };
            if (data == null)
            {
                return NotFound(new BaseResponse(false, 404, "Previous request data was not found"));
            }
            DashboardResponseDto response = new DashboardResponseDto()
            {
                Data =data,
                IsSuccess = true,
                StatusCode = (int)HttpStatusCode.OK,
                ResponseMessage = "Request has been complited successfully"
            };
           
            return Ok(response);
        }

        //[HttpGet(ApiRoute.Home.QuotationPreview)]
        //public IActionResult GetQuotationPreviewRequest(Guid Id)
        //{
        //    ClientQuotationMotor qoutationDetails = unitOfWork.ClientQuotation.GetQoutationDetails(Id);

        //    QuotationPreviewResponseDto data = new QuotationPreviewResponseDto()
        //    {
        //        QoutationDetails = mapper.Map<ClientQuotationMotor, QoutationDetailsDto>(qoutationDetails),
        //        QoutationClinetDetails = mapper.Map<Client, QoutationClinetDetailsDto>(qoutationDetails.Client),

        //        VechicleDrivers = mapper.Map<IEnumerable<QuotationsMotorRequestVehicleDriver>, IEnumerable<VechicleDriversDto>>(qoutationDetails.QuotationsMotorRequest.QuotationsMotorRequestVehicleDrivers),

        //        qoutationBenefit = mapper.Map<IEnumerable<QuotationsMotorResponseProductBenefit>, IEnumerable<QoutationBenefitDto>>(qoutationDetails.QuotationsMotorResponseProduct.QuotationsMotorResponseProductBenefits),
        //        IsSuccess = true,
        //        StatusCode = (int)HttpStatusCode.OK,
        //        ResponseMessage = "Request has been complited successfully"
        //    };
        //    if (data == null)
        //    {
        //        return NotFound(new BaseResponse(false, 404, "Previous request data was not found"));
        //    }
        //    return Ok(data);
        //}
    }
}
