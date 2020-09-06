using System.Threading.Tasks;
using AutoMapper;
using AggriPortal.API.Contracts;
using AggriPortal.API.Persistence;
using AggriPortal.API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AggriPortal.API.Resources;
using AggriPortal.API.Domain.Models;
using AggriPortal.API.Contracts.Response;
using System.Collections.Generic;
using System.Net;
using System.Linq;
using AggriPortal.API.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using AggriPortal.API.Security.Permission;
using System.Reflection;
using Microsoft.Extensions.Localization;

namespace  AggriPortal.API.Controllers
{ 
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = Roles.SuperAdmin + "," + Roles.Administrator + "," + Roles.ManageIdentity)]
    public class SettingController : ControllerBase
    {

        private readonly IMapper mapper;
        private readonly IIdentityService identityService;
        private readonly IUnitOfWork unitOfWork;
        private readonly ILogger _logger;
        private readonly IStringLocalizer localizer;
        public SettingController(ILogger<AccountController> logger, IUnitOfWork unitOfWork, IMapper mapper, IIdentityService identityService , IStringLocalizer<SharedResources> localizer)
        {
            _logger = logger;
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
            this.identityService = identityService;
            this.localizer = localizer;
        }
        [HttpGet(ApiRoute.Setting.Roles)]
        public async Task<IActionResult> GetRoles()
        {
            var data = await identityService.GetRoles() ;
            if (data == null)
            {
                return NotFound(new BaseResponse(false, 404, "Previous request data was not found"));
            }
            RoleResponseDto response = new RoleResponseDto()
            {
                Data = mapper.Map<IEnumerable<ApplicationRole>, IEnumerable<RoleDto>>(data),
                TotalRecord = data.Count(),
                IsSuccess = true,
                StatusCode = (int)HttpStatusCode.OK,
                ResponseMessage = "Request has been complited successfully"
            };
            return Ok(response);
        }
        [HttpPost(ApiRoute.Setting.AddRole)]
        public async Task<IActionResult> addRoleRequest([FromBody] AddRoleRequestDto request)
        {
            var currentUserId = HttpContext.GetUserId();
            var response = await identityService.AddRoleAsync(request , currentUserId);
            if (!response.IsSuccess)
            {   
                return BadRequest(response);
            }
            return Ok(response);
        }
        [HttpPut(ApiRoute.Setting.UpdateRole)]
        public async Task<IActionResult> UpdateRoleRequest(string Id , [FromBody] AddRoleRequestDto request)
        {
            var currentUserId = HttpContext.GetUserId();
            var response = await identityService.UpdateRoleAsync(Id , request, currentUserId);
            if (!response.IsSuccess)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
        [HttpPost(ApiRoute.Setting.SignUserRoles)]
        public async Task<IActionResult> SignUserRolesRequest([FromBody] SignUserRoleRequestDto request)
        {
            var response = await identityService.SignUserRoles(request);
            if (!response.IsSuccess)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
        [HttpDelete(ApiRoute.Setting.RemoveUserRoles)]
        public async Task<IActionResult> RemoveUserRolesRequest([FromBody] SignUserRoleRequestDto request)
        {
            var response = await identityService.RemoveUserRoles(request);
            if (!response.IsSuccess)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
        #region claims
        //[HttpGet(ApiRoute.Setting.UserClaims)]
        //public async Task<IActionResult> GetUserClaims()
        //{
        //    var data = await identityService.GetUserClaims();
        //    if (data == null)
        //    {
        //        return NotFound(new BaseResponse(false, 404, "Previous request data was not found"));
        //    }
        //    return Ok(data);
        //}

        //[HttpPost(ApiRoute.Setting.AddUserClaims)]
        //public async Task<IActionResult> AddUserClaimsRequest([FromBody] AddUserClaimRequestDto request)
        //{
        //    var response = await identityService.AddUserClaimsAsync(request);
        //    if (!response.IsSuccess)
        //    {
        //        return BadRequest(response);
        //    }
        //    return Ok(response);
        //}
        //[HttpDelete(ApiRoute.Setting.RemoveUserClaims)]
        //public async Task<IActionResult> RemoveUserClaimsRequest(string Id , string ClaimType , string ClaimValue)
        //{
        //    var response = await identityService.RemoveUserClaimsAsync(Id , ClaimType , ClaimValue);
        //    if (!response.IsSuccess)
        //    {
        //        return BadRequest(response);
        //    }
        //    return Ok(response);
        //}
        //[HttpGet(ApiRoute.Setting.Permissions)]
        //public  IActionResult GetPermissionRequest()
        //{
        //    var permissionsList = new List<PermissionsDto> { };
        //    foreach (var prop in typeof(ClaimPermission).GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy))
        //    {
        //        var permission = new PermissionsDto(){
        //            ClaimType = "Permission",
        //            CalimValue = prop.GetValue(null).ToString() , 
        //            Name = localizer["Permission." + prop.GetValue(null).ToString()]
        //        };
        //        permissionsList.Add(permission);
        //    }
        //    PermissionsResponseDto response = new PermissionsResponseDto()
        //    {
        //        Data = permissionsList,
        //        IsSuccess = true,
        //        StatusCode = (int)HttpStatusCode.OK,
        //        TotalRecord = permissionsList.Count,
        //        ResponseMessage = "Request has been complited successfully"
        //    };
        //    return Ok(response);
        //}
        #endregion
    }
}
