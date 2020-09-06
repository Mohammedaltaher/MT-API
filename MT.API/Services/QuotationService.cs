using AutoMapper;
using AggriPortal.API.Contracts.Request;
using AggriPortal.API.Contracts.Response;
using AggriPortal.API.Domain.Models;
using AggriPortal.API.Domain.ServiceModels;
using AggriPortal.API.Persistence;
using AggriPortal.API.Resources;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace  AggriPortal.API.Services
{
    public interface IQuotationService
    {
        Task<YakkenClientMapping> GetClientData(long identityNumber, string birthDate, string currentUser, string phoneNumber, string email);
        Task<YakkenClientVehicleMapping> GetClientVehicleData(Guid clientId, UserQuotationRequestDto req);
        Task<YakkenVehicleDriverMapping> GetVehicleDriverData(long identityNumber, string birthDate);
        Task UpdateClientInfo(UserQuotationRequestDto req, Client client);
    }

    public class QuotationService : IQuotationService
    {
        private readonly YakeenService yakeenService;
        private readonly SaudiPostService saudiPostService;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IStringLocalizer<SharedResources> localizer;
        public QuotationService(IUnitOfWork unitOfWork, IMapper mapper, YakeenService yakeenService, SaudiPostService saudiPostService, IStringLocalizer<SharedResources> localizer)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.yakeenService = yakeenService;
            this.saudiPostService = saudiPostService;
            this.localizer = localizer;
        }
        public Task<YakkenClientMapping> GetClientData(long identityNumber, string birthDate, string currentUser, string phoneNumber, string email)
        {
            YakkenClientMapping result = new YakkenClientMapping();
            // Fetch the client's data from Yaqeen
            var insuredInfoResponse = yakeenService.GetInsuredData(identityNumber, birthDate);

            // On request failure
            if (!insuredInfoResponse.IsSuccess)
            {
                result = new YakkenClientMapping()
                {
                    IsSuccess = false,
                    StatusCode = 721,
                    ResponseMessage = localizer["YakkenInsuredResponseGlobalErrMsg"], //An error occurred during the process of querying insured data from the National Information Center.
                    ValidationErrors = new List<Contracts.Response.ValidationError>() { new Contracts.Response.ValidationError { Name = "IdentityNumber", Description = localizer["YakkenInsuredResponseValidationErrMsg"] } }
                };
                return Task.FromResult(result);
            }

            var saudiPostResponse = saudiPostService.GetInsuredSaudiAddress(identityNumber);
            if (!saudiPostResponse.IsSuccess)
            {
                result = new YakkenClientMapping()
                {
                    IsSuccess = false,
                    StatusCode = 724,
                    ResponseMessage = localizer["YakkenInsuredResponseGlobalErrMsg"],
                    ValidationErrors = new List<Contracts.Response.ValidationError>() { new Contracts.Response.ValidationError { Name = "IdentityNumber", Description = localizer["YakkenSaudiPostResponseValidationErrMsg"] } }
                };
                return Task.FromResult(result);
            }

            // Construct a 'Client' object for the user with their fetched data
            Client client = mapper.Map<YakeenInsuredInfo, Client>(insuredInfoResponse.Data);
            client.IdentityTypeId = Convert.ToInt32(identityNumber.ToString().Substring(0, 1));
            client.ApplicationUserId = currentUser;
            client.PhoneNumber = phoneNumber;
            client.Email = email;
            client.CreatedBy = currentUser;
            client.UpdatedDate = DateTime.Now;
            // Mapping Saudi address to client.
            mapper.Map<SaudiPostInfo, Client>(saudiPostResponse.Data, client);
            result = new YakkenClientMapping()
            {
              //  Client = client,
                IsSuccess = true,
                StatusCode = 200,
                ResponseMessage = "Successfully"
            };
            return Task.FromResult(result);
        }

        public Task<YakkenClientVehicleMapping> GetClientVehicleData(Guid clientId, UserQuotationRequestDto req)
        {
            YakkenClientVehicleMapping result = new YakkenClientVehicleMapping();
            // Fetch the client's vehicle data from yaqeen using their vehicle sequence number
            var vehicleInfoResponse = yakeenService.GetVehicleBySquNo(req.VehicleId);

            // On request failure
            if (!vehicleInfoResponse.IsSuccess)
            {
                result = new YakkenClientVehicleMapping()
                {
                    IsSuccess = false,
                    StatusCode = 723,
                    ResponseMessage = localizer["YakkenInsuredResponseGlobalErrMsg"],
                    ValidationErrors = new List<ValidationError>() { new ValidationError { Name = "VehicleId", Description = "الرجاء التحقق من الرقم المتسلسل للمركبة , تعزر الاتصال بمزود المعلومات الوطني" } }
                };
                return Task.FromResult(result);
            }

            // Construct a 'ClientVehicle' object for the client with their fetched vehicle data
            ClientVehicle clientVehicle = mapper.Map<YakeenVehicleInfo, ClientVehicle>(vehicleInfoResponse.Data);
            clientVehicle.ClientId = clientId;
            clientVehicle.IsVehicleModified = req.IsVehicleOwnerTransfer;
            clientVehicle.VehicleRepairMethodId = req.VehicleRepairMethodId;
            clientVehicle.VehicleUseId = req.VehicleUseId;
            clientVehicle.VehicleTransmissionTypeId = req.VehicleTransmissionTypeId;
            clientVehicle.VehicleModificationDetails = req.VehicleModificationDetails;
            clientVehicle.VehicleSpecifications = req.VehicleSpecifications != null ? string.Join(",", req.VehicleSpecifications.Select(p => p.VehicleSpecificationId).ToList()) : null;
            clientVehicle.VehicleIdTypeId = req.VehicleIdTypeId;
            result = new YakkenClientVehicleMapping()
            {
                ClientVehicle = clientVehicle,
                IsSuccess = true,
                StatusCode = 200,
                ResponseMessage = "Successfully"
            };
            return Task.FromResult(result);
        }

        public Task<YakkenVehicleDriverMapping> GetVehicleDriverData(long identityNumber, string birthDate)
        {
            YakkenVehicleDriverMapping result = new YakkenVehicleDriverMapping();
            // Fetch the driver's data from Yaqeen
            var insuredInfoResponse = yakeenService.GetInsuredData(identityNumber, birthDate);

            // On request failure
            if (!insuredInfoResponse.IsSuccess)
            {
                result = new YakkenVehicleDriverMapping()
                {
                    IsSuccess = false,
                    StatusCode = 722, // Failure to query additional driver data from the Yakken service 
                    ResponseMessage = localizer["YakkenDriverResponseGlobalErrMsg"],
                    ValidationErrors = new List<ValidationError>() { new ValidationError { Name = "VehicleId", Description = localizer["YakkenDriverResponseValidationErrMsg"] } }
                };
                return Task.FromResult(result);
            }

            // Construct a 'VehicleDriver' object for the Driver with their fetched data
            QuotationsMotorRequestVehicleDriver driver = mapper.Map<YakeenInsuredInfo, QuotationsMotorRequestVehicleDriver>(insuredInfoResponse.Data);
            // Store the driver info
            //await unitOfWork.VehicleDriver.AddAsync(driver);
            //await unitOfWork.Commit();
            result = new YakkenVehicleDriverMapping()
            {
                VehicleDriver = driver,
                IsSuccess = true,
                ResponseMessage = "Successfully",
                StatusCode = 200
            };
            return Task.FromResult(result);
        }

        public async Task UpdateClientInfo(UserQuotationRequestDto req, Client client)
        {
            client.BirthDate = req.InsuredBirthDate;
            client.EducationLevelId = req.InsuredEducationLevelId;
            client.SocialStatusId = req.InsuredSocialStatusId;
            client.WorkCityId = req.InsuredWorkCityId;
            client.GenderId = req.InsuredGenderId;
            client.ChildrenUnder16Years = req.ChildrenUnder16Years ?? 0;
            unitOfWork.Client.UpdateAsync(client);
            await unitOfWork.Commit();
        }


    }
}
