using System.Threading.Tasks;
using AutoMapper;
using AggriPortal.API.Contracts;
using AggriPortal.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using AggriPortal.API.Helper.Security.Tokens;
using AggriPortal.API.Resources;
using AggriPortal.API.Domain.Models;
using AggriPortal.API.Contracts.Response;
using System.Collections.Generic;
using System.Net;
using System.Linq;
using AggriPortal.API.Extensions;
using AggriPortal.API.Security.Permission;

namespace  AggriPortal.API.Controllers
{
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class AccountController : ControllerBase
    {

        private readonly IMapper mapper;
        private readonly IIdentityService identityService;

        public AccountController(IMapper mapper, IIdentityService identityService)
        {
            this.mapper = mapper;
            this.identityService = identityService;
        }
        [Authorize(Roles = Roles.SuperAdmin + "," + Roles.Administrator + "," + Roles.CreateAccount)]
        [HttpPost(ApiRoute.Account.Create)]
        public async Task<IActionResult> CreateAccountRequest([FromBody] UserCreateRequestDto request)
        {
            var currentUser = HttpContext.GetUserId();
            var result = await identityService.CreateUserAsync(request , currentUser);
            return StatusCode(result.StatusCode, result);
        }
        [AllowAnonymous]
        [HttpPost(ApiRoute.Account.Login)]
        public async Task<IActionResult> LoginRequest([FromBody] LoginRequestDto userCredentials)
        {
            var response = await identityService.AuthenticateAsync(userCredentials);
            if (!response.IsSuccess)
            {
                return StatusCode(response.StatusCode, response);
            }
            var accessToken = mapper.Map<AccessToken, AccessTokenDto>(response.Token);
            return Ok(accessToken);
        }
        [Authorize(Roles = Roles.SuperAdmin + "," + Roles.Administrator + "," + Roles.ViewEmployeesAccounts)]
        [HttpPost(ApiRoute.Account.Employees)]
        public async Task<IActionResult> GetEmployeeRequest([FromBody] UserRequestDto req)
        {
            var currentUser = HttpContext.GetUserId();
            var CanViewDetails = identityService.IsAuthorizeTo(currentUser, Roles.ViewEmployeesAccounts);
            var data = await identityService.GetEmployeeAsync(req);

            if (data == null)
            {
                return NotFound(new BaseResponse(false, 404, "Previous request data was not found"));
            }
            UserResponseDto response = new UserResponseDto()
            {
                Data = mapper.Map<IEnumerable<ApplicationUser>, IEnumerable<ApplicationUserDto>>(data),
                IsSuccess = true,
                StatusCode = (int)HttpStatusCode.OK,
                TotalRecord = data.Count() ,
                CanViewDetails = CanViewDetails,
                ResponseMessage = "Request has been complited successfully"
            };
            return Ok(response);
        }
        [Authorize(Roles = Roles.SuperAdmin + "," + Roles.Administrator + "," + Roles.ViewClientsAccounts)]
        [HttpPost(ApiRoute.Account.Client)]
        public async Task<IActionResult> GetClientRequest([FromBody] UserRequestDto req)
        {
            var currentUser = HttpContext.GetUserId();
            var CanViewDetails = identityService.IsAuthorizeTo(currentUser, Roles.ViewClientsAccounts);
            var data = await identityService.GetClientAsync(req);

            if (data == null)
            {
                return NotFound(new BaseResponse(false, 404, "Previous request data was not found"));
            }
            UserResponseDto response = new UserResponseDto()
            {
                Data = mapper.Map<IEnumerable<ApplicationUser>, IEnumerable<ApplicationUserDto>>(data),
                IsSuccess = true,
                StatusCode = (int)HttpStatusCode.OK,
                TotalRecord = data.Count() ,
                CanViewDetails = CanViewDetails ,
                ResponseMessage = "Request has been complited successfully"
            };
            return Ok(response);
        }
       
        [Authorize(Roles = Roles.SuperAdmin + "," + Roles.Administrator + "," + Roles.ViewEmployeesAccounts)]
        [HttpGet(ApiRoute.Account.EmployeeDetails)]
        public async Task<IActionResult> EmployeeAccountDetailsRequest(string Id)
        {
            var currentUser = HttpContext.GetUserId();
            var CanUpdateAccount = identityService.IsAuthorizeTo(currentUser, Roles.UpdateAccount);

            var data = identityService.GetAccountDetails(Id);
            if (data == null)
            {
                return NotFound(new BaseResponse(false, 404, "Previous request data was not found"));
            }
            EmployeeDetailsResponseDto response = new EmployeeDetailsResponseDto()
            {
                Data = mapper.Map<ApplicationUser, ApplicationUserDto>(data),
                Permissions = await  identityService.GetUserClaims(Id) ,
                IsSuccess = true,
                StatusCode = (int)HttpStatusCode.OK,
                CanUpdateAccount = CanUpdateAccount,
                ResponseMessage = "Request has been complited successfully"
            };
            return Ok(response);
        }
        [Authorize(Roles = Roles.SuperAdmin + "," + Roles.Administrator + "," + Roles.ViewClientsAccounts)]
        [HttpGet(ApiRoute.Account.ClientDetails)]
        public IActionResult ClientAccountDetailsRequest(string Id)
        {
            var currentUser = HttpContext.GetUserId();
            var CanUpdateAccount = identityService.IsAuthorizeTo(currentUser, Roles.UpdateAccount);

            var data = identityService.GetAccountDetails(Id);
            if (data == null)
            {
                return NotFound(new BaseResponse(false, 404, "Previous request data was not found"));
            }
            ClientsDetailsResponseDto response = new ClientsDetailsResponseDto()
            {
                Data = mapper.Map<ApplicationUser, ApplicationUserDto>(data),
                IsSuccess = true,
                StatusCode = (int)HttpStatusCode.OK,
                CanUpdateAccount = CanUpdateAccount,
                ResponseMessage = "Request has been complited successfully"
            };
             
            return Ok(response);
        }
        [Authorize(Roles = Roles.SuperAdmin + "," + Roles.Administrator + "," + Roles.UpdateAccount)]
        [HttpPut(ApiRoute.Account.update)]
        public async Task<IActionResult> UpdateAccountRequest(string Id, [FromBody] UpdateAccountRequestDto req)
        {
            return  Ok(await identityService.UpdateAccount(Id, req));
        }

        [Authorize(Roles = Roles.UpdateAccount)]
        [HttpPost(ApiRoute.Account.ChangePassword)]
        public async Task<IActionResult> ChangePasswordRequest([FromBody] ChangePasswordRequestDto request)
        {
            var response = await identityService.ChangePasswordByAdmin(request);
            if (!response.IsSuccess)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
        [AllowAnonymous]
        [HttpPost(ApiRoute.Account.ResetrRquest)]
        public async Task<IActionResult> ResetPasswordRequest([FromBody] ResetPasswordRequestDto request)
        {
            var response = await identityService.ResetPasswordRequest(request);
            return StatusCode(response.StatusCode, response);
        }
        [AllowAnonymous]
        [HttpPost(ApiRoute.Account.Reset)]
        public async Task<IActionResult> VerifyResetPasswordRequest([FromBody] VerifyResetPasswordRequestDto request)
        {
            var response = await identityService.VerifyResetPasswordRequest(request);
            if (!response.IsSuccess)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
    }
}
