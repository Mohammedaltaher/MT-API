﻿namespace  AggriPortal.API.Services
{
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.1")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName = "IInsuranceInquiry")]
    public interface IInsuranceInquiry
    {

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IInsuranceInquiry/GetDriverCaseDetail", ReplyAction = "http://tempuri.org/IInsuranceInquiry/GetDriverCaseDetailResponse")]
        System.Threading.Tasks.Task<string> GetDriverCaseDetailAsync(string driverId, int insuranceID);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IInsuranceInquiry/GetDriverCaseDetailWithInquiryType", ReplyAction = "http://tempuri.org/IInsuranceInquiry/GetDriverCaseDetailWithInquiryTypeResponse")]
        System.Threading.Tasks.Task<string> GetDriverCaseDetailWithInquiryTypeAsync(string driverId, int insuranceID, int inquiryType);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IInsuranceInquiry/GetDriverCaseDetailV2", ReplyAction = "http://tempuri.org/IInsuranceInquiry/GetDriverCaseDetailV2Response")]
        System.Threading.Tasks.Task<string> GetDriverCaseDetailV2Async(string driverId, int insuranceID);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IInsuranceInquiry/GetDriverCaseDetailV2WithInquiryType", ReplyAction = "http://tempuri.org/IInsuranceInquiry/GetDriverCaseDetailV2WithInquiryTypeResponse" +
            "")]
        System.Threading.Tasks.Task<string> GetDriverCaseDetailV2WithInquiryTypeAsync(string driverId, int insuranceID, int inquiryType);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IInsuranceInquiry/GetVehicleCaseDetail", ReplyAction = "http://tempuri.org/IInsuranceInquiry/GetVehicleCaseDetailResponse")]
        System.Threading.Tasks.Task<string> GetVehicleCaseDetailAsync(string vehiclePlateNo, System.Nullable<int> registrationType, int insuranceID);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IInsuranceInquiry/GetVehicleCaseDetailWithInquiryType", ReplyAction = "http://tempuri.org/IInsuranceInquiry/GetVehicleCaseDetailWithInquiryTypeResponse")]
        System.Threading.Tasks.Task<string> GetVehicleCaseDetailWithInquiryTypeAsync(string vehiclePlateNo, System.Nullable<int> registrationType, int insuranceID, int inquiryType);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IInsuranceInquiry/GetVehicleCaseDetailV2", ReplyAction = "http://tempuri.org/IInsuranceInquiry/GetVehicleCaseDetailV2Response")]
        System.Threading.Tasks.Task<string> GetVehicleCaseDetailV2Async(string vehiclePlateNo, System.Nullable<int> registrationType, int insuranceID);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IInsuranceInquiry/GetVehicleCaseDetailV2WithInquiryType", ReplyAction = "http://tempuri.org/IInsuranceInquiry/GetVehicleCaseDetailV2WithInquiryTypeRespons" +
            "e")]
        System.Threading.Tasks.Task<string> GetVehicleCaseDetailV2WithInquiryTypeAsync(string vehiclePlateNo, System.Nullable<int> registrationType, int insuranceID, int inquiryType);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IInsuranceInquiry/GetVehicleMultiInsuranceByPlateNo", ReplyAction = "http://tempuri.org/IInsuranceInquiry/GetVehicleMultiInsuranceByPlateNoResponse")]
        System.Threading.Tasks.Task<string> GetVehicleMultiInsuranceByPlateNoAsync(string vehiclePlateNo, int registrationType, int insuranceID);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IInsuranceInquiry/GetVehicleMultiInsuranceByPlateNoWithInquiry" +
            "Type", ReplyAction = "http://tempuri.org/IInsuranceInquiry/GetVehicleMultiInsuranceByPlateNoWithInquiry" +
            "TypeResponse")]
        System.Threading.Tasks.Task<string> GetVehicleMultiInsuranceByPlateNoWithInquiryTypeAsync(string vehiclePlateNo, int registrationType, int insuranceID, int inquiryType);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IInsuranceInquiry/GetVehicleMultiInsuranceBySequenceNo", ReplyAction = "http://tempuri.org/IInsuranceInquiry/GetVehicleMultiInsuranceBySequenceNoResponse" +
            "")]
        System.Threading.Tasks.Task<string> GetVehicleMultiInsuranceBySequenceNoAsync(string vehicleSequenceno, int insuranceID);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IInsuranceInquiry/GetVehicleMultiInsuranceBySequenceNoWithInqu" +
            "iryType", ReplyAction = "http://tempuri.org/IInsuranceInquiry/GetVehicleMultiInsuranceBySequenceNoWithInqu" +
            "iryTypeResponse")]
        System.Threading.Tasks.Task<string> GetVehicleMultiInsuranceBySequenceNoWithInquiryTypeAsync(string vehicleSequenceno, int insuranceID, int inquiryType);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IInsuranceInquiry/GetVehicleCaseDetailBySequenceNo", ReplyAction = "http://tempuri.org/IInsuranceInquiry/GetVehicleCaseDetailBySequenceNoResponse")]
        System.Threading.Tasks.Task<string> GetVehicleCaseDetailBySequenceNoAsync(string vehicleSequenceno, int insuranceID);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IInsuranceInquiry/GetVehicleCaseDetailBySequenceNoWithInquiryT" +
            "ype", ReplyAction = "http://tempuri.org/IInsuranceInquiry/GetVehicleCaseDetailBySequenceNoWithInquiryT" +
            "ypeResponse")]
        System.Threading.Tasks.Task<string> GetVehicleCaseDetailBySequenceNoWithInquiryTypeAsync(string vehicleSequenceno, int insuranceID, int inquiryType);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IInsuranceInquiry/GetVehicleCaseDetailBySequenceNoV2", ReplyAction = "http://tempuri.org/IInsuranceInquiry/GetVehicleCaseDetailBySequenceNoV2Response")]
        System.Threading.Tasks.Task<string> GetVehicleCaseDetailBySequenceNoV2Async(string vehicleSequenceno, int insuranceID);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IInsuranceInquiry/GetVehicleCaseDetailBySequenceNoV2WithInquir" +
            "yType", ReplyAction = "http://tempuri.org/IInsuranceInquiry/GetVehicleCaseDetailBySequenceNoV2WithInquir" +
            "yTypeResponse")]
        System.Threading.Tasks.Task<string> GetVehicleCaseDetailBySequenceNoV2WithInquiryTypeAsync(string vehicleSequenceno, int insuranceID, int inquiryType);
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.1")]
    public interface IInsuranceInquiryChannel : IInsuranceInquiry, System.ServiceModel.IClientChannel
    {
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.1")]
    public partial class InsuranceInquiryClient : System.ServiceModel.ClientBase<IInsuranceInquiry>, IInsuranceInquiry
    {

        /// <summary>
        /// Implement this partial method to configure the service endpoint.
        /// </summary>
        /// <param name="serviceEndpoint">The endpoint to configure</param>
        /// <param name="clientCredentials">The client credentials</param>
        static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);

        public InsuranceInquiryClient() :
                base(InsuranceInquiryClient.GetDefaultBinding(), InsuranceInquiryClient.GetDefaultEndpointAddress())
        {
            this.Endpoint.Name = EndpointConfiguration.WSHttpBinding_IInsuranceInquiry.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }

        public InsuranceInquiryClient(EndpointConfiguration endpointConfiguration) :
                base(InsuranceInquiryClient.GetBindingForEndpoint(endpointConfiguration), InsuranceInquiryClient.GetEndpointAddress(endpointConfiguration))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }

        public InsuranceInquiryClient(EndpointConfiguration endpointConfiguration, string remoteAddress) :
                base(InsuranceInquiryClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }

        public InsuranceInquiryClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) :
                base(InsuranceInquiryClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress)
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }

        public InsuranceInquiryClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) :
                base(binding, remoteAddress)
        {
        }

        public System.Threading.Tasks.Task<string> GetDriverCaseDetailAsync(string driverId, int insuranceID)
        {
            return base.Channel.GetDriverCaseDetailAsync(driverId, insuranceID);
        }

        public System.Threading.Tasks.Task<string> GetDriverCaseDetailWithInquiryTypeAsync(string driverId, int insuranceID, int inquiryType)
        {
            return base.Channel.GetDriverCaseDetailWithInquiryTypeAsync(driverId, insuranceID, inquiryType);
        }

        public System.Threading.Tasks.Task<string> GetDriverCaseDetailV2Async(string driverId, int insuranceID)
        {
            return base.Channel.GetDriverCaseDetailV2Async(driverId, insuranceID);
        }

        public System.Threading.Tasks.Task<string> GetDriverCaseDetailV2WithInquiryTypeAsync(string driverId, int insuranceID, int inquiryType)
        {
            return base.Channel.GetDriverCaseDetailV2WithInquiryTypeAsync(driverId, insuranceID, inquiryType);
        }

        public System.Threading.Tasks.Task<string> GetVehicleCaseDetailAsync(string vehiclePlateNo, System.Nullable<int> registrationType, int insuranceID)
        {
            return base.Channel.GetVehicleCaseDetailAsync(vehiclePlateNo, registrationType, insuranceID);
        }

        public System.Threading.Tasks.Task<string> GetVehicleCaseDetailWithInquiryTypeAsync(string vehiclePlateNo, System.Nullable<int> registrationType, int insuranceID, int inquiryType)
        {
            return base.Channel.GetVehicleCaseDetailWithInquiryTypeAsync(vehiclePlateNo, registrationType, insuranceID, inquiryType);
        }

        public System.Threading.Tasks.Task<string> GetVehicleCaseDetailV2Async(string vehiclePlateNo, System.Nullable<int> registrationType, int insuranceID)
        {
            return base.Channel.GetVehicleCaseDetailV2Async(vehiclePlateNo, registrationType, insuranceID);
        }

        public System.Threading.Tasks.Task<string> GetVehicleCaseDetailV2WithInquiryTypeAsync(string vehiclePlateNo, System.Nullable<int> registrationType, int insuranceID, int inquiryType)
        {
            return base.Channel.GetVehicleCaseDetailV2WithInquiryTypeAsync(vehiclePlateNo, registrationType, insuranceID, inquiryType);
        }

        public System.Threading.Tasks.Task<string> GetVehicleMultiInsuranceByPlateNoAsync(string vehiclePlateNo, int registrationType, int insuranceID)
        {
            return base.Channel.GetVehicleMultiInsuranceByPlateNoAsync(vehiclePlateNo, registrationType, insuranceID);
        }

        public System.Threading.Tasks.Task<string> GetVehicleMultiInsuranceByPlateNoWithInquiryTypeAsync(string vehiclePlateNo, int registrationType, int insuranceID, int inquiryType)
        {
            return base.Channel.GetVehicleMultiInsuranceByPlateNoWithInquiryTypeAsync(vehiclePlateNo, registrationType, insuranceID, inquiryType);
        }

        public System.Threading.Tasks.Task<string> GetVehicleMultiInsuranceBySequenceNoAsync(string vehicleSequenceno, int insuranceID)
        {
            return base.Channel.GetVehicleMultiInsuranceBySequenceNoAsync(vehicleSequenceno, insuranceID);
        }

        public System.Threading.Tasks.Task<string> GetVehicleMultiInsuranceBySequenceNoWithInquiryTypeAsync(string vehicleSequenceno, int insuranceID, int inquiryType)
        {
            return base.Channel.GetVehicleMultiInsuranceBySequenceNoWithInquiryTypeAsync(vehicleSequenceno, insuranceID, inquiryType);
        }

        public System.Threading.Tasks.Task<string> GetVehicleCaseDetailBySequenceNoAsync(string vehicleSequenceno, int insuranceID)
        {
            return base.Channel.GetVehicleCaseDetailBySequenceNoAsync(vehicleSequenceno, insuranceID);
        }

        public System.Threading.Tasks.Task<string> GetVehicleCaseDetailBySequenceNoWithInquiryTypeAsync(string vehicleSequenceno, int insuranceID, int inquiryType)
        {
            return base.Channel.GetVehicleCaseDetailBySequenceNoWithInquiryTypeAsync(vehicleSequenceno, insuranceID, inquiryType);
        }

        public System.Threading.Tasks.Task<string> GetVehicleCaseDetailBySequenceNoV2Async(string vehicleSequenceno, int insuranceID)
        {
            return base.Channel.GetVehicleCaseDetailBySequenceNoV2Async(vehicleSequenceno, insuranceID);
        }

        public System.Threading.Tasks.Task<string> GetVehicleCaseDetailBySequenceNoV2WithInquiryTypeAsync(string vehicleSequenceno, int insuranceID, int inquiryType)
        {
            return base.Channel.GetVehicleCaseDetailBySequenceNoV2WithInquiryTypeAsync(vehicleSequenceno, insuranceID, inquiryType);
        }

        public virtual System.Threading.Tasks.Task OpenAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndOpen));
        }

        public virtual System.Threading.Tasks.Task CloseAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginClose(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndClose));
        }

        private static System.ServiceModel.Channels.Binding GetBindingForEndpoint(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.WSHttpBinding_IInsuranceInquiry))
            {
                System.ServiceModel.Channels.CustomBinding result = new System.ServiceModel.Channels.CustomBinding();
                System.ServiceModel.Channels.TransportSecurityBindingElement userNameOverTransportSecurityBindingElement = System.ServiceModel.Channels.SecurityBindingElement.CreateUserNameOverTransportBindingElement();
                userNameOverTransportSecurityBindingElement.MessageSecurityVersion = System.ServiceModel.MessageSecurityVersion.WSSecurity11WSTrustFebruary2005WSSecureConversationFebruary2005WSSecurityPolicy11BasicSecurityProfile10;
                result.Elements.Add(userNameOverTransportSecurityBindingElement);
                System.ServiceModel.Channels.TextMessageEncodingBindingElement textBindingElement = new System.ServiceModel.Channels.TextMessageEncodingBindingElement();
                result.Elements.Add(textBindingElement);
                System.ServiceModel.Channels.HttpsTransportBindingElement httpsBindingElement = new System.ServiceModel.Channels.HttpsTransportBindingElement();
                httpsBindingElement.AllowCookies = true;
                httpsBindingElement.MaxBufferSize = int.MaxValue;
                httpsBindingElement.MaxReceivedMessageSize = int.MaxValue;
                result.Elements.Add(httpsBindingElement);
                return result;
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }

        private static System.ServiceModel.EndpointAddress GetEndpointAddress(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.WSHttpBinding_IInsuranceInquiry))
            {
                return new System.ServiceModel.EndpointAddress("https://ic.najm.sa:8089/InsuranceInquiry.svc");
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }

        private static System.ServiceModel.Channels.Binding GetDefaultBinding()
        {
            return InsuranceInquiryClient.GetBindingForEndpoint(EndpointConfiguration.WSHttpBinding_IInsuranceInquiry);
        }

        private static System.ServiceModel.EndpointAddress GetDefaultEndpointAddress()
        {
            return InsuranceInquiryClient.GetEndpointAddress(EndpointConfiguration.WSHttpBinding_IInsuranceInquiry);
        }

        public enum EndpointConfiguration
        {

            WSHttpBinding_IInsuranceInquiry,
        }
    }
}
