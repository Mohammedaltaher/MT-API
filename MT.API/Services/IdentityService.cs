using AutoMapper;
using AggriPortal.API.Contracts.Request;
using AggriPortal.API.Contracts.Response;
using AggriPortal.API.Domain.Models;
using AggriPortal.API.Helper.Security.Hashing;
using AggriPortal.API.Helper.Security.Tokens;
using AggriPortal.API.Persistence;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Extensions.Logging;
using System.Security.Claims;
using AggriPortal.API.Resources;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using LinqKit;
using Microsoft.IdentityModel.JsonWebTokens;
using AggriPortal.API.Security.Permission;
using System.Reflection;

namespace  AggriPortal.API.Services
{
    public interface IIdentityService
    {
        Task<RegistrationResponse> CreateUserAsync(UserCreateRequestDto request , string currentUser);
        Task<ApplicationUser> GetByUserNameAsync(string userName);
        Task<TokenResponse> AuthenticateAsync(LoginRequestDto request);
        Task<TokenResponse> VerifyPhoneNumberAsync(VerifyPhoneNumberRequest verifyRequest);
        Task<BaseResponse> ResendVerificationCode(VerifyPhoneNumberRequest request);
        Task<ChangePasswordResponse> RequestPasswordChange(ChangePasswordRequest request);
        Task<ChangePasswordResponse> ChangePassword(ChangePasswordVerificationRequest request);
        Task<ChangeUserNameResponse> RequestUserNameChange(ChangeUserNameRequest request);
        Task<ChangeUserNameResponse> ChangeUserName(ChangeUserNameVerificationRequest request);
        Task<ChangeDefaultLanguageResponse> ChangeDefaultLanguage(ChangeDefaultLanguageRequest request);
        Task<PasswordResetIssueResponse> RequestPasswordReset(PasswordResetRequest request);
        Task<PasswordResetResponse> ResetPassword(PasswordResetVerificationRequest request);
        Task<ChangePhoneNumberResponse> RequestPhoneNumberChange(ChangePhoneNumberRequest request);
        Task<ChangePhoneNumberResponse> ChangePhoneNumber(ChangePhoneNumberVerificationRequest request);
        Task<UserAccountInfoResponse> GetUserProfile(string userId);
        Task<PasswordChangedByAdminResponseDto> ChangePasswordByAdmin(ChangePasswordRequestDto request);
        Task<ChangeEmailResponseDto> ChangeEmail(ChangeEmailRequestDto request);
        Task<UserActivationResponseDto> UserActivation(UserActivationRequestDto request);
        Task<IEnumerable<ApplicationUser>> GetEmployeeAsync(UserRequestDto req);
        Task<IEnumerable<ApplicationUser>> GetClientAsync(UserRequestDto req);
        ApplicationUser GetAccountDetails(string Id);
        Task<BaseResponse> UpdateAccount(string Id, UpdateAccountRequestDto req);
        Task<BaseResponse> ResetPasswordRequest(ResetPasswordRequestDto request);
        Task<BaseResponse> VerifyResetPasswordRequest(VerifyResetPasswordRequestDto request);
        Task<IEnumerable<ApplicationRole>> GetRoles();
        Task<UserClaimsResponseDto> GetUserClaims();
        Task<IEnumerable<UserClaimsDto>> GetUserClaims(string userId);
        Task<BaseResponse> AddRoleAsync(AddRoleRequestDto request, string currentUserId);
        Task<BaseResponse> UpdateRoleAsync(string Id, AddRoleRequestDto request, string currentUserId);
        Task<BaseResponse> AddUserClaimsAsync(AddUserClaimRequestDto request);
        Task<BaseResponse> RemoveUserClaimsAsync(string UserId, string ClaimType, string ClaimValue);
        Task<BaseResponse> SignUserRoles(SignUserRoleRequestDto req);
        Task<BaseResponse> RemoveUserRoles(SignUserRoleRequestDto req);
        Task CreateAdminRoleAndUser();
        bool IsAuthorizeTo(string UserId, string claimValue);
    }
    public class IdentityService : IIdentityService
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<ApplicationRole> roleManger;
        private readonly IHasher hasher;
        private readonly ITokenHandler tokenHandler;
        private readonly IMessagerService messager;
        private readonly IStringLocalizer<SharedResources> localizer;
        private IUnitOfWork unitOfWork;
        private IUserDetectionService userDetectionService;
        private IMapper mapper;
        private IHostEnvironment environment;
        private Microsoft.Extensions.Logging.ILogger logger;
        public IdentityService(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManger, IHasher hasher, ITokenHandler tokenHandler, IMessagerService messager, IStringLocalizer<SharedResources> localizer, IUnitOfWork unitOfWork, IUserDetectionService userDetectionService, IMapper mapper, IHostEnvironment _environment, ILogger<IdentityService> logger)
        {
            this.userManager = userManager;
            this.roleManger = roleManger;
            this.hasher = hasher;
            this.tokenHandler = tokenHandler;
            this.messager = messager;
            this.localizer = localizer;
            this.unitOfWork = unitOfWork;
            this.userDetectionService = userDetectionService;
            this.mapper = mapper;
            this.environment = _environment;
            this.logger = logger;
        }
        public async Task<RegistrationResponse> CreateUserAsync(UserCreateRequestDto request ,string currentUser)
        {
            // Check existing user.
            var existingUser = await userManager.FindByNameAsync(request.Email);
            if (existingUser != null)
            {
                return new RegistrationResponse { IsSuccess = false, ResponseMessage = localizer["UserWithEmailExists"], StatusCode = (int)HttpStatusCode.BadRequest };
            }
            // Construct user object
            var user = new ApplicationUser
            {
                UserName = request.Email,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                FullName = request.FullName,
                FullNameAr = request.FullNameAr,
                CreatedBy = currentUser
            };
            // Create user
            var result = await userManager.CreateAsync(user, request.Password);
            // Construct and return user creation error response
            if (!result.Succeeded)
            {
                return new RegistrationResponse { IsSuccess = false, ResponseMessage = localizer["RegisterUserResponseErrMsg"], ValidationErrors = result.Errors.Select(err => new ValidationError { Name = err.Code, Description = err.Description }).ToList() };
            }
          
            await userManager.AddClaimAsync(user, new Claim("UserType", "Employee"));
            // add roles to users 
            IEnumerable<string> roles = request.Roles.Split(',');
            await userManager.AddToRolesAsync(user, roles);

            // Generate verification code and send it to client.
            var code = await userManager.GenerateChangePhoneNumberTokenAsync(user, request.PhoneNumber);
            var acceptLang = userDetectionService.GetAcceptLanguage();
            var lang = !string.IsNullOrWhiteSpace(acceptLang.Substring(0, 2)) ? acceptLang.Substring(0, 2) : user.DefaultLang;
            // Send account verification email
            var sendMailResult = await messager.SendAccountVerificationEmail(request.Email, code, lang);
            if (!sendMailResult.Success)
            {
                return new RegistrationResponse { IsSuccess = false, ResponseMessage = sendMailResult.Message, StatusCode = 700, UserId = hasher.Encrypt(user.Id), PhoneNumber = hasher.Encrypt(user.PhoneNumber) };
            }

            //[TODO] SMS verification token.
            //if (await messager.SendSmsAsync(request.PhoneNumber, string.Format("your code is {0}", code)))
            //{
            //    return new RegistrationResponse { IsSuccess = true, ResponseMessage = "User registeration successfully.", StatusCode = 201, UserId = hasher.Encrypt(user.Id), PhoneNumber = hasher.Encrypt(user.PhoneNumber) };
            //}

            // add user roles here.
            return new RegistrationResponse { IsSuccess = true, ResponseMessage = localizer["RegisterAccountSentVerificationSuccessMsg"], StatusCode = (int)HttpStatusCode.OK, UserId = hasher.Encrypt(user.Id), PhoneNumber = hasher.Encrypt(user.PhoneNumber) };
        }
        public async Task<ApplicationUser> GetByUserNameAsync(string userName)
        {
            return await userManager.FindByNameAsync(userName);
        }
        public async Task<TokenResponse> AuthenticateAsync(LoginRequestDto request)
        {
            var user = await this.GetByUserNameAsync(request.UserName);
           // user.UserRoles = roles.Select(a => new ApplicationUserRole{ UserId= user.Id, Role = new ApplicationRole{)


            ////      user.UserRoles  = (ICollection<ApplicationUserRole>)roles;

            if (user != null)
            {
                // validate the password.
                if (!await userManager.CheckPasswordAsync(user, request.Password))
                {
                    return new TokenResponse(null, "", "", false, 401, localizer["LoginResponseInvalidEmailPasswordErrMsg"]);
                }

                // Check user activation.
                if (!user.IsActive)
                {
                    return new TokenResponse(null, "", "", false, 401, localizer["LoginResponseDisabledAccountErrMsg"]);
                }
              //  logger.LogInformation("User in role admin");
                // Add Login History
                if (!environment.IsDevelopment())
                {
                    var ip = userDetectionService.GetUserIpAddress();
                    var userGeoLocation = await userDetectionService.GetUserGeoLocation(ip);
                    if (userGeoLocation.IsSuccess)
                    {
                        ApplicationUserLoginHistory loginHistory = mapper.Map<UserGeoLocationResponse, ApplicationUserLoginHistory>(userGeoLocation);
                        loginHistory.ApplicationUserId = user.Id;
                        loginHistory.CreatedBy = user.Id;
                        loginHistory.Browser = userDetectionService.GetUserBrowser();
                        await unitOfWork.ApplicationUserLoginHistory.AddAsync(loginHistory);
                        await unitOfWork.Commit();
                    }
                }
                #region add claims to user
                var userClaims = await userManager.GetClaimsAsync(user);
                var UserRoles = await userManager.GetRolesAsync(user);

                var claims = new List<Claim>{
                new Claim(JwtRegisteredClaimNames.Jti, user.Id),
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim("tel", user.PhoneNumber),
                new Claim("lng", string.IsNullOrEmpty(user.DefaultLang)? "ar" : user.DefaultLang)
                };
                // Add role claim
                //foreach (Claim userClaim in userClaims)
                //{
                //    claims.Add(userClaim);
                //}
                foreach (string item in UserRoles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, item));
                }
                var token = tokenHandler.CreateAccessToken(user, claims);
                #endregion
                return new TokenResponse(token, hasher.Encrypt(user.Id), hasher.Encrypt(user.PhoneNumber), true, 200, localizer["LoginResponseSuccessMsg"]);
            }
            else
            {
                return new TokenResponse(null, "", "", false, 401, localizer["LoginResponseInvalidEmailPasswordErrMsg"]);
            }
        }
        public async Task<TokenResponse> VerifyPhoneNumberAsync(VerifyPhoneNumberRequest verifyRequest)
        {
            var user = await userManager.FindByIdAsync(hasher.Decrypt(verifyRequest.UserId));
            var roles = await userManager.GetRolesAsync(user);

            var result = await userManager.ChangePhoneNumberAsync(user, hasher.Decrypt(verifyRequest.PhoneNumber), verifyRequest.Code);
            if (!result.Succeeded)
            {
                return new TokenResponse(null, hasher.Encrypt(user.Id), hasher.Encrypt(user.PhoneNumber), false, 400, localizer["RegisterAccountVerifyTokenErrMsg"], result.Errors.Select(p => new ValidationError { Name = p.Description, Description = p.Description }).ToList());
            }
            // phone activate successfully.
            // generate token
            var token = tokenHandler.CreateAccessToken(user, null);
            return new TokenResponse(token, hasher.Encrypt(user.Id), hasher.Encrypt(user.PhoneNumber), true, 200, localizer["LoginResponseSuccessMsg"]);
        }

        public async Task<BaseResponse> ResendVerificationCode(VerifyPhoneNumberRequest request)
        {
            // Get the user
            var user = await userManager.FindByIdAsync(hasher.Decrypt(request.UserId));

            // Generate verification code
            var verificationCode = await userManager.GenerateChangePhoneNumberTokenAsync(user, hasher.Decrypt(request.PhoneNumber));

            // Send the verification code email
            var result = await messager.SendAccountVerificationEmail(user.Email, verificationCode, user.DefaultLang);
            if (!result.Success)
            {
                return new BaseResponse(true, 700, result.Message);
            }

            return new BaseResponse(true, (int)HttpStatusCode.OK, localizer["VerificationCodeSuccessfully"]);
        }
        public async Task<ChangePhoneNumberResponse> RequestPhoneNumberChange(ChangePhoneNumberRequest request)
        {
            // Get the user
            var user = await userManager.FindByIdAsync(request.UserId);

            // Validate the sent password
            if (!await userManager.CheckPasswordAsync(user, request.Password))
            {
                return new ChangePhoneNumberResponse(false, 400, localizer["IncorrectPassword"]);
            }

            // Generate verification code
            var verificationCode = await userManager.GenerateChangePhoneNumberTokenAsync(user, user.PhoneNumber);

            // Send the verification code email
            await messager.SendEmailAsync(user.Email, "Phone Number Change", string.Format("You have requested to change your phone number, to complete, please input the following code: {0}", verificationCode));

            return new ChangePhoneNumberResponse(true, 200, "A verification code has been sent to your email");
        }

        public async Task<ChangePhoneNumberResponse> ChangePhoneNumber(ChangePhoneNumberVerificationRequest request)
        {
            // Get the user
            var user = await userManager.FindByIdAsync(request.UserId);

            // Validate the confirmation code
            if (!await userManager.VerifyChangePhoneNumberTokenAsync(user, request.VerificationCode, user.PhoneNumber))
            {
                return new ChangePhoneNumberResponse(false, 400, "Incorrect verification code");
            }

            // Change the user's username
            user.PhoneNumber = request.NewPhoneNumber;
            var result = await userManager.UpdateAsync(user);

            if (!result.Succeeded)
            {
                return new ChangePhoneNumberResponse(false, 400, string.Join(",", result.Errors.Select(p => p.Description)));
            }

            return new ChangePhoneNumberResponse(true, 200, "Your phone number has been changed successfully");
        }

        public async Task<ChangePasswordResponse> RequestPasswordChange(ChangePasswordRequest request)
        {
            // Get the user
            var user = await userManager.FindByIdAsync(request.UserId);

            // Validate the sent password
            if (!await userManager.CheckPasswordAsync(user, request.OldPassword))
            {
                return new ChangePasswordResponse(false, 400, "Incorrect old password");
            }

            // Generate verification code
            var verificationCode = await userManager.GenerateChangePhoneNumberTokenAsync(user, user.PhoneNumber);

            // Send the verification code email
            //await messager.SendEmailAsync(user.Email, "Username Change", string.Format("You have requested to change your account password, to complete, please input the following code: {0}", verificationCode));
            await messager.SendResetPasswordEmail(user.Email, verificationCode, user.PhoneNumber.Substring(user.PhoneNumber.Length - 4), user.DefaultLang);

            return new ChangePasswordResponse(true, 200, "A verification code has been sent to your email");
        }

        public async Task<ChangePasswordResponse> ChangePassword(ChangePasswordVerificationRequest request)
        {
            // Get the user
            var user = await userManager.FindByIdAsync(request.UserId);

            // Validate the confirmation code
            if (!await userManager.VerifyChangePhoneNumberTokenAsync(user, request.VerificationCode, user.PhoneNumber))
            {
                return new ChangePasswordResponse(false, 400, "Incorrect verification code");
            }

            // Change the user's password
            var newPassword = userManager.PasswordHasher.HashPassword(user, request.NewPassword);
            user.PasswordHash = newPassword;
            var result = await userManager.UpdateAsync(user);

            if (!result.Succeeded)
            {
                return new ChangePasswordResponse(false, 400, string.Join(",", result.Errors.Select(p => p.Description)));
            }

            return new ChangePasswordResponse(true, 200, "Your password has been changed successfully");
        }

        public async Task<PasswordResetIssueResponse> RequestPasswordReset(PasswordResetRequest request)
        {
            // Find user by email
            var user = await userManager.FindByEmailAsync(HttpUtility.UrlDecode(request.Email));

            // Validate email
            if (user == null)
            {
                return new PasswordResetIssueResponse(false, (int)HttpStatusCode.BadRequest, localizer["InvalidEmail"]);
            }

            // Verify phone last 4 digits
            if (request.LastPhoneDigits != user.PhoneNumber.Substring(user.PhoneNumber.Length - 4))
            {
                return new PasswordResetIssueResponse(false, (int)HttpStatusCode.BadRequest, localizer["InvalidPhoneNumber"]);
            }

            // Generate password reset code (phone number token is shorter, so its used for password change)
            var code = await userManager.GenerateChangePhoneNumberTokenAsync(user, user.PhoneNumber);

            // [TEMPORARY] Send the code via email
            //await messager.SendEmailAsync(request.Email, "Password reset code", string.Format("Your password reset code is: {0}", code));
            var sendEmailResult = await messager.SendResetPasswordEmail(request.Email, code, user.PhoneNumber.Substring(user.PhoneNumber.Length - 4), user.DefaultLang);
            if (!sendEmailResult.Success)
            {
                return new PasswordResetIssueResponse(false, 700, sendEmailResult.Message);
            }
            //await messager.SendResetPasswordEmail(request.Email,code, user.PhoneNumber.Substring(user.PhoneNumber.Length - 4), user.DefaultLang);

            // [TODO] Send account verification SMS
            // if(await messager.SendSmsAsync(request.PhoneNumber, string.Format("your verification code is {0}", code)))
            // {
            //    return new RegistrationResponse { IsSuccess = true, ResponseMessage = "User registeration successfully.", StatusCode = 201, UserId = hasher.Encrypt(user.Id), PhoneNumber = hasher.Encrypt(user.PhoneNumber) };
            // }

            return new PasswordResetIssueResponse(true, (int)HttpStatusCode.OK, localizer["PasswordResetTokenSentSuccessfully"]);
        }

        public async Task<PasswordResetResponse> ResetPassword(PasswordResetVerificationRequest request)
        {
            // Find user by email
            var user = await userManager.FindByEmailAsync(request.Email);

            // Verify code
            if (!await userManager.VerifyChangePhoneNumberTokenAsync(user, request.Code, user.PhoneNumber))
            {
                return new PasswordResetResponse(false, 400, localizer["PasswordResetResponseErrMsg"], new List<ValidationError> { new ValidationError { Name = "Token", Description = localizer["PasswordRestTokenInvalid"] } });
            }

            // Validate the new password
            var passwordValidator = new PasswordValidator<ApplicationUser>();
            var passValidatorResult = await passwordValidator.ValidateAsync(userManager, user, request.NewPassword);
            if (!passValidatorResult.Succeeded)
            {
                return new PasswordResetResponse(false, 400, localizer["PasswordResetResponseErrMsg"], passValidatorResult.Errors.Select(p => new ValidationError { Name = p.Code, Description = p.Description }).ToList());
            }


            // Change user password
            var newPassword = userManager.PasswordHasher.HashPassword(user, request.NewPassword);
            user.PasswordHash = newPassword;
            user.UpdateDate = DateTime.Now;
            // Update user
            var result = await userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                // Get user location
                var ip = userDetectionService.GetUserIpAddress();
                var userGeoLocation = await userDetectionService.GetUserGeoLocation(ip);
                string location = "KSA";
                var acceptLang = userDetectionService.GetAcceptLanguage();
                var lang = !string.IsNullOrWhiteSpace(acceptLang.Substring(0, 2)) ? acceptLang.Substring(0, 2) : user.DefaultLang;

                if (userGeoLocation.IsSuccess)
                {
                    location = string.Format("{0} - {1}, {2}", userGeoLocation.Region_name, userGeoLocation.City, userGeoLocation.Country_name);
                    await messager.SendPasswordChangedConfirmationEmail(user.Email, ((DateTime)user.UpdateDate), location, ip, lang);
                }
                return new PasswordResetResponse(true, 200, localizer["PasswordRestResponseSuccessMsg"]);
            }
            else
            {
                return new PasswordResetResponse(false, 400, localizer["PasswordResetResponseErrMsg"], result.Errors.Select(p => new ValidationError { Name = p.Code, Description = p.Description }).ToList());
            }
        }

        public async Task<ChangeUserNameResponse> RequestUserNameChange(ChangeUserNameRequest request)
        {
            // Get the user
            var user = await userManager.FindByIdAsync(request.UserId);

            // Validate the sent password
            if (!await userManager.CheckPasswordAsync(user, request.Password))
            {
                return new ChangeUserNameResponse(false, 400, "Incorrect password");
            }

            // Generate verification code
            var verificationCode = await userManager.GenerateChangePhoneNumberTokenAsync(user, user.PhoneNumber);

            // Send the verification code email
            await messager.SendEmailAsync(user.Email, "Username Change", string.Format("You have requested to change your account email, to complete, please input the following code: {0}", verificationCode));

            return new ChangeUserNameResponse(true, 200, "A verification code has been sent to your email");
        }

        public async Task<ChangeUserNameResponse> ChangeUserName(ChangeUserNameVerificationRequest request)
        {
            // Get the user
            var user = await userManager.FindByIdAsync(request.UserId);

            // Validate the confirmation code
            if (!await userManager.VerifyChangePhoneNumberTokenAsync(user, request.VerificationCode, user.PhoneNumber))
            {
                return new ChangeUserNameResponse(false, 400, "Incorrect verification code");
            }

            // Change the user's username
            user.UserName = request.UserName;
            user.Email = request.UserName;
            var result = await userManager.UpdateAsync(user);

            if (!result.Succeeded)
            {
                return new ChangeUserNameResponse(false, 400, string.Join(",", result.Errors.Select(p => p.Description)));
            }

            return new ChangeUserNameResponse(true, 200, "Your email has been changed successfully");
        }

        public async Task<ChangeDefaultLanguageResponse> ChangeDefaultLanguage(ChangeDefaultLanguageRequest request)
        {
            // Get the user by their Id
            var user = await userManager.FindByIdAsync(request.UserId);

            // Set the user default language
            user.DefaultLang = request.Language;

            // Update user
            var result = await userManager.UpdateAsync(user);

            if (!result.Succeeded)
            {
                return new ChangeDefaultLanguageResponse(false, 400, string.Join(",", result.Errors.Select(p => p.Description)));
            }

            return new ChangeDefaultLanguageResponse(true, 200, "Your default language has been changed successfully");
        }

        public async Task<UserAccountInfoResponse> GetUserProfile(string userId)
        {
            // Get the user by their Id
            var user = await userManager.FindByIdAsync(userId);

            // Construct and return the user profile response
            return new UserAccountInfoResponse
            {
                data = new UserAccountInfoDto
                {
                    Email = user.Email,
                    Phone = user.PhoneNumber,
                    DefaultLang = user.DefaultLang
                },
                IsSuccess = true,
                StatusCode = 200,
                ResponseMessage = ""
            };
        }

        #region admin
        public async Task<PasswordChangedByAdminResponseDto> ChangePasswordByAdmin(ChangePasswordRequestDto request)
        {
            // Find user by email
            var user = await userManager.FindByIdAsync(request.Id);
            // Validate the new password
            var passwordValidator = new PasswordValidator<ApplicationUser>();
            var passValidatorResult = await passwordValidator.ValidateAsync(userManager, user, request.NewPassword);
            if (!passValidatorResult.Succeeded)
            {
                return new PasswordChangedByAdminResponseDto(false, 400, localizer["PasswordResetResponseErrMsg"]);
            }
            // Change user password
            var newPassword = userManager.PasswordHasher.HashPassword(user, request.NewPassword);
            user.PasswordHash = newPassword;
            user.UpdateDate = DateTime.Now;
            // Update user
            var result = await userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                await messager.SendPasswordChangedByAdminEmail(user.Email, ((DateTime)user.UpdateDate), user.DefaultLang, request.NewPassword);
                return new PasswordChangedByAdminResponseDto(true, 200, localizer["PasswordRestResponseSuccessMsg"]);
            }
            else
            {
                return new PasswordChangedByAdminResponseDto(false, 400, localizer["PasswordResetResponseErrMsg"]);
            }
        }
        public async Task<ChangeEmailResponseDto> ChangeEmail(ChangeEmailRequestDto request)
        {
            // Get the user
            var user = await userManager.FindByIdAsync(request.Id);
            // Change the user's username
            user.UserName = request.Email;
            user.Email = request.Email;
            var result = await userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                await messager.SendEmailChangedByAdminEmail(user.Email, ((DateTime)user.UpdateDate), user.DefaultLang);
                return new ChangeEmailResponseDto(true, 200, "The email has been changed successfully");
            }
            return new ChangeEmailResponseDto(false, 400, string.Join(",", result.Errors.Select(p => p.Description)));
        }

        public async Task<UserActivationResponseDto> UserActivation(UserActivationRequestDto request)
        {
            // Find user by email
            var user = await userManager.FindByIdAsync(request.Id);

            user.IsActive = request.IsActive;
            user.UpdateDate = DateTime.Now;
            // Update user
            var result = await userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                if (request.IsActive == true)
                {
                    return new UserActivationResponseDto(true, 200, "user has been activate ");
                }
                else
                {
                    return new UserActivationResponseDto(true, 200, "user has been deactivate ");
                }
            }
            else
            {
                return new UserActivationResponseDto(false, 400, "user has not been activate/deactivate ");
            }
        }

        public async Task<IEnumerable<ApplicationUser>> GetEmployeeAsync(UserRequestDto req)
        {

            Expression<Func<ApplicationUser, bool>> predicate = c => true;
            if (!string.IsNullOrEmpty(req.FullName))
            {
                predicate = predicate.And(p => p.FullName.Contains(req.FullName));
            }
            if (!string.IsNullOrEmpty(req.FullNameAr))
            {
                predicate = predicate.And(p => p.FullNameAr.Contains(req.FullNameAr));
            }

            if (!string.IsNullOrEmpty(req.Email))
            {
                predicate = predicate.And(p => p.Email == req.Email);
            }
            if (req.DateFrom != null && req.DateTo != null)
            {
                predicate = predicate.And(p => p.CreatedDate >= req.DateFrom && p.CreatedDate <= req.DateTo);
            }
            if (req.IsActive != null)
            {
                predicate = predicate.And(p => p.IsActive == req.IsActive);
            }
            predicate = predicate.And(p => p.Claims.Any(c => c.ClaimType == "UserType" && c.ClaimValue == "Employee"));
            return await userManager.Users.Where(predicate).ToListAsync();
        }
        public async Task<IEnumerable<ApplicationUser>> GetClientAsync(UserRequestDto req)
        {

            Expression<Func<ApplicationUser, bool>> predicate = c => true;
            if (!string.IsNullOrEmpty(req.FullName))
            {
                predicate = predicate.And(p => p.FullName.Contains(req.FullName));
            }
            if (!string.IsNullOrEmpty(req.FullNameAr))
            {
                predicate = predicate.And(p => p.FullNameAr.Contains(req.FullNameAr));
            }
            if (req.IsActive != null)
            {
                predicate = predicate.And(p => p.IsActive == req.IsActive);
            }
            if (!string.IsNullOrEmpty(req.Email))
            {
                predicate = predicate.And(p => p.Email == req.Email);
            }
            if (req.DateFrom != null && req.DateTo != null)
            {
                predicate = predicate.And(p => p.CreatedDate >= req.DateFrom && p.CreatedDate <= req.DateTo);
            }
            predicate = predicate.And(p => p.Claims.Any(c => c.ClaimType == "UserType" && c.ClaimValue == "Client"));
            return await userManager.Users.Where(predicate).ToListAsync();
        }
        public ApplicationUser GetAccountDetails(string Id)
        {
            return userManager.Users.FirstOrDefault(p => p.Id == Id); ;
        }

        public async Task<BaseResponse> UpdateAccount(string Id, UpdateAccountRequestDto req)
        {
            // Get the user
            var user = await userManager.FindByIdAsync(Id);
            mapper.Map<UpdateAccountRequestDto, ApplicationUser>(req, user);
            var result = await userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                //  await messager.SendEmailChangedByAdminEmail(user.Email, ((DateTime)user.UpdateDate), user.DefaultLang);
                return new BaseResponse(true, 200, "The data has been updated successfully");
            }
            return new BaseResponse(false, 400, string.Join(",", result.Errors.Select(p => p.Description)));
        }
        public async Task<BaseResponse> ResetPasswordRequest(ResetPasswordRequestDto request)
        {
            var user = await userManager.FindByEmailAsync(HttpUtility.UrlDecode(request.Email));
            if (user == null)
            {
                return new BaseResponse(false, (int)HttpStatusCode.BadRequest, localizer["InvalidEmail"]);
            }
            var code = await userManager.GenerateChangePhoneNumberTokenAsync(user, user.PhoneNumber);
            // [TEMPORARY] Send the code via email
            //await messager.SendEmailAsync(request.Email, "Password reset code", string.Format("Your password reset code is: {0}", code));
            var sendEmailResult = await messager.SendResetPasswordEmail(request.Email, code, user.PhoneNumber.Substring(user.PhoneNumber.Length - 4), user.DefaultLang);
            if (!sendEmailResult.Success)
            {
                return new BaseResponse(false, 700, sendEmailResult.Message);
            }
            return new BaseResponse(true, (int)HttpStatusCode.OK, localizer["PasswordResetTokenSentSuccessfully"]);
        }

        public async Task<BaseResponse> VerifyResetPasswordRequest(VerifyResetPasswordRequestDto request)
        {
            var user = await userManager.FindByEmailAsync(request.Email);

            if (!await userManager.VerifyChangePhoneNumberTokenAsync(user, request.Code, user.PhoneNumber))
            {
                return new PasswordResetResponse(false, 400, localizer["PasswordResetResponseErrMsg"], new List<ValidationError> { new ValidationError { Name = "Token", Description = localizer["PasswordRestTokenInvalid"] } });
            }

            var passwordValidator = new PasswordValidator<ApplicationUser>();
            var passValidatorResult = await passwordValidator.ValidateAsync(userManager, user, request.NewPassword);
            if (!passValidatorResult.Succeeded)
            {
                return new PasswordResetResponse(false, 400, localizer["PasswordResetResponseErrMsg"], passValidatorResult.Errors.Select(p => new ValidationError { Name = p.Code, Description = p.Description }).ToList());
            }

            var newPassword = userManager.PasswordHasher.HashPassword(user, request.NewPassword);
            user.PasswordHash = newPassword;
            user.UpdateDate = DateTime.Now;

            var result = await userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return new PasswordResetResponse(true, 200, localizer["PasswordRestResponseSuccessMsg"]);
            }
            else
            {
                return new PasswordResetResponse(false, 400, localizer["PasswordResetResponseErrMsg"], result.Errors.Select(p => new ValidationError { Name = p.Code, Description = p.Description }).ToList());
            }
        }
        #region roles
        public async Task<IEnumerable<ApplicationRole>> GetRoles()
        {
            return await roleManger.Roles.ToListAsync();
        }

        public async Task<BaseResponse> AddRoleAsync(AddRoleRequestDto request, string currentUserId)
        {
            var existingRole = await roleManger.FindByNameAsync(request.Name);

            if (existingRole != null)
            {
                return new BaseResponse(false, (int)HttpStatusCode.BadRequest, "role already Existed ");
            }
            var role = new ApplicationRole
            {
                Name = request.Name,
                NormalizedName = request.Name.ToUpper(),
                CreatedBy = currentUserId
            };

            var result = await roleManger.CreateAsync(role);
            if (!result.Succeeded)
            {
                return new BaseResponse(false, 400, "", result.Errors.Select(p => new ValidationError { Name = "", Description = p.Description }).ToList());
            }
            return new BaseResponse(true, 200, "The data has been added successfully");
        }
        public async Task<BaseResponse> UpdateRoleAsync(string Id, AddRoleRequestDto request, string currentUserId)
        {
            var role = await roleManger.FindByIdAsync(Id);
            role.Name = request.Name;
            role.NormalizedName = request.Name.ToUpper();
            role.CreatedBy = currentUserId;

            var result = await roleManger.UpdateAsync(role);
            if (result.Succeeded)
            {
                return new BaseResponse(true, 200, "The data has been updated successfully");
            }
            return new BaseResponse(false, 400, "", result.Errors.Select(p => new ValidationError { Name = "", Description = p.Description }).ToList());

        }
        #endregion

        #region role claims 
        public async Task<UserClaimsResponseDto> GetUserClaims()
        {
            var AllUsers = await userManager.Users.ToListAsync();
            //  var roleClaims = new rol;
            UserClaimsResponseDto data = new UserClaimsResponseDto()
            {
                users = mapper.Map<IEnumerable<ApplicationUser>, IEnumerable<UsersDtos>>(AllUsers),
                TotalRecord = AllUsers.Count(),
                IsSuccess = true,
                StatusCode = (int)HttpStatusCode.OK,
                ResponseMessage = "Request has been complited successfully"
            };
            foreach (var item in data.users)
            {
                var claims = await userManager.GetClaimsAsync(await userManager.FindByIdAsync(item.Id));
                if (claims != null)
                    item.Permissions = mapper.Map<IEnumerable<Claim>, IEnumerable<UserClaimsDto>>(claims);
            }
            return data;
        }
        public async Task<IEnumerable<UserClaimsDto>> GetUserClaims(string userId)
        {
            var claims = await userManager.GetClaimsAsync(await userManager.FindByIdAsync(userId));
            var data = mapper.Map<IEnumerable<Claim>, IEnumerable<UserClaimsDto>>(claims);
            return data;
        }
        public async Task<BaseResponse> AddUserClaimsAsync(AddUserClaimRequestDto request)
        {
            var user = await userManager.FindByIdAsync(request.UserId);
            if (user == null)
            {
                return new BaseResponse(false, (int)HttpStatusCode.BadRequest, "user not Existed ");
            }
            var ClaimsList = request.ClaimsValue.Split(',').ToArray();
            List<Claim> claims = new List<Claim> { };
            foreach (var item in ClaimsList)
            {
                claims.Add(new Claim("Permission", item));
            }
            var result = await userManager.AddClaimsAsync(user, claims);

            if (!result.Succeeded)
            {
                return new BaseResponse(false, 400, "", result.Errors.Select(p => new ValidationError { Name = "", Description = p.Description }).ToList());
            }

            return new BaseResponse(true, 200, "The data has been added successfully");
        }
        public async Task<BaseResponse> RemoveUserClaimsAsync(string UserId, string ClaimType, string ClaimValue)
        {
            var user = await userManager.FindByIdAsync(UserId);
            if (user == null)
            {
                return new BaseResponse(false, (int)HttpStatusCode.BadRequest, "role not Existed ");
            }
            var result = await userManager.RemoveClaimAsync(user, new Claim(ClaimType, ClaimValue));
            if (result.Succeeded)
            {
                return new BaseResponse(true, 200, "The data has been updated successfully");
            }
            return new BaseResponse(false, 400, "", result.Errors.Select(p => new ValidationError { Name = "", Description = p.Description }).ToList());
        }
        public async Task<BaseResponse> SignUserRoles(SignUserRoleRequestDto req)
        {
            var user = await userManager.FindByIdAsync(req.UserId);
            if (user == null)
            {
                return new RegistrationResponse { IsSuccess = false, ResponseMessage = localizer["UserWithEmailExists"], StatusCode = (int)HttpStatusCode.BadRequest };
            }
            // add roles to users 
            var roles = req.Roles.Split(',').ToArray();

            var result = await userManager.AddToRolesAsync(user, roles);

            if (result.Succeeded)
            {
                return new BaseResponse(true, 200, "The data has been updated successfully");
            }
            return new BaseResponse(false, 400, "", result.Errors.Select(p => new ValidationError { Name = "", Description = p.Description }).ToList());

        }
        public async Task<BaseResponse> RemoveUserRoles(SignUserRoleRequestDto req)
        {
            var user = await userManager.FindByIdAsync(req.UserId);
            if (user == null)
            {
                return new RegistrationResponse { IsSuccess = false, ResponseMessage = localizer["UserWithEmailExists"], StatusCode = (int)HttpStatusCode.BadRequest };
            }
            var roles = req.Roles.Split(',');

            var result = await userManager.RemoveFromRolesAsync(user, roles);

            if (result.Succeeded)
            {
                return new BaseResponse(true, 200, "The data has been updated successfully");
            }
            return new BaseResponse(false, 400, "", result.Errors.Select(p => new ValidationError { Name = "", Description = p.Description }).ToList());


        }
        public bool IsAuthorizeTo(string UserId, string claimValue)
        {
            return userManager.Users.Any(p => p.Claims.Any(c => c.ClaimType == "Permission" && c.ClaimValue == claimValue)&& p.Id == UserId);
        }

        #endregion
        public async Task CreateAdminRoleAndUser()
        {
            if (!await roleManger.RoleExistsAsync("Administrator"))
            {
                var role = new ApplicationRole() { Name = "Administrator" };
                await roleManger.CreateAsync(role);


                var user = new ApplicationUser()
                {
                    UserName = "admin@oasis.com",
                    Email = "admin@oasis.com",
                };

                var result = await userManager.CreateAsync(user, "Oasis@123");

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "Admin");
                    List<Claim> claims = new List<Claim> { };
                    foreach (var prop in typeof(Roles).GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy))
                    {
                        claims.Add(new Claim("Permission", prop.GetValue(null).ToString()));
                    }
                    claims.Add(new Claim("UserType", "Employee"));
                    await userManager.AddClaimsAsync(user, claims);
                }
            }
        }
        #endregion
    }
}
