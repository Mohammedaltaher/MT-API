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
using ReflectionIT.Mvc.Paging;
using System.Linq;
using AggriPortal.API.Resources;
using Microsoft.Extensions.Configuration;
using AggriPortal.API.Security.Permission;

namespace  AggriPortal.API.Controllers
{
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = Roles.SuperAdmin + "," + Roles.Administrator + "," + Roles.ViewAPILogger)]
    public class LoggerController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IConfiguration configuration;
        public LoggerController( IConfiguration configuration, IUnitOfWork unitOfWork, IMapper mapper  )
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.configuration = configuration;
        }
        [HttpPost(ApiRoute.Logger.HistoryLog)]
        public IActionResult GetHistoryLogRequest([FromBody] APILogHistoryRequestDto req)
        {
            var data = unitOfWork.APILogHistory.GetLogHistory(req);

            int pageSize = req.PageSize ?? configuration.GetValue<int>("PagingOptions:PageSize");
            int pageNumber = req.PageNumber ?? configuration.GetValue<int>("PagingOptions:PageNumber");

            APILogHistoryResponseDto response = new APILogHistoryResponseDto()
            {
                Data = mapper.Map<IEnumerable<APILogHistory>, IEnumerable<APILogHistoryDto>>(PagingList.Create(data, pageSize, pageNumber)),
                TotalRecord = data.Count(),
                IsSuccess = true,
                StatusCode = (int)HttpStatusCode.OK,
                ResponseMessage = "Request has been complited successfully"
            };
            if (data == null)
            {
                return NotFound(new BaseResponse(false, 404, "Previous request data was not found"));
            }
            return Ok(response);
        }

        [HttpPost(ApiRoute.Logger.SMSLog)]
        public IActionResult GetSMSLogRequest([FromBody] SMSLogRequestDto req)
        {
            var data = unitOfWork.SMSLog.GetSMSLog(req);

            int pageSize = req.PageSize ?? configuration.GetValue<int>("PagingOptions:PageSize");
            int pageNumber = req.PageNumber ?? configuration.GetValue<int>("PagingOptions:PageNumber");
            SMSLogResponseDto response = new SMSLogResponseDto()
            {
                Data = mapper.Map<IEnumerable<SMSLog>, IEnumerable<SMSLogDto>>(PagingList.Create(data, pageSize, pageNumber)),
                TotalRecord = data.Count(),
                IsSuccess = true,
                StatusCode = (int)HttpStatusCode.OK,
                ResponseMessage = "Request has been complited successfully"
            };
            if (data == null)
            {
                return NotFound(new BaseResponse(false, 404, "Previous request data was not found"));
            }
            return Ok(response);
        }
        [HttpPost(ApiRoute.Logger.loginHistory)]
        public async Task<IActionResult> GetloginHistoryRequest([FromBody] LoginHistoryRequestDto req)
        {
            string userId = unitOfWork.Client.GetMany(p => p.Id == req.ClientId).FirstOrDefault().ApplicationUserId;
            var data = unitOfWork.ApplicationUserLoginHistory.GetMany(p => p.ApplicationUserId == userId).OrderByDescending(p => p.CreatedDate);

            if (data == null)
            {
                return NotFound(new BaseResponse(false, 404, "Previous request data was not found"));
            }
            int pageSize = req.PageSize ?? configuration.GetValue<int>("PagingOptions:PageSize");
            int pageNumber = req.PageNumber ?? configuration.GetValue<int>("PagingOptions:PageNumber");

            LoginHistoryResponseDto response = new LoginHistoryResponseDto()
            {
                Data = mapper.Map<IEnumerable<ApplicationUserLoginHistory>, IEnumerable<ClientLoginHistoryDto>>(await PagingList.CreateAsync(data, pageSize,pageNumber)),
                TotalRecord = data.Count(),
                IsSuccess = true,
                StatusCode = (int)HttpStatusCode.OK,
                ResponseMessage = "Request has been complited successfully"
            };
            return Ok(response);
        }


    }
}
