using AggriPortal.API.Contracts.Request;
using AggriPortal.API.Contracts.Response;
using AggriPortal.API.Domain.Models;
using AggriPortal.API.Persistence;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace  AggriPortal.API.Services
{
    public interface IGatewayService
    {
        Task<InsureQuotationResponse> GetQuote(InsuranceCompany insuranceCompany, InsureQuotationRequest quotationRequest);
        Task<IssuePolicyResponse> IssuePolicy(IssuePolicyRequest policyRequest);
    }

    public class GatewayService: IGatewayService
    {
        private readonly IHttpClientFactory clientFactory;
        private IUnitOfWork unitOfWork;
        public GatewayService(IHttpClientFactory clientFactory, IUnitOfWork unitOfWork)
        {
            this.clientFactory = clientFactory;
            this.unitOfWork = unitOfWork;
        }

        public async Task<InsureQuotationResponse> GetQuote(InsuranceCompany insuranceCompany, InsureQuotationRequest quotationRequest)
        {

            var client = clientFactory.CreateClient(insuranceCompany.HttpClientName);
            quotationRequest.InsuranceCompanyId = insuranceCompany.Id;
            var reqData = JsonConvert.SerializeObject(quotationRequest);
            var stringContent = new StringContent(reqData, UnicodeEncoding.UTF8, "application/json");
            var response = await client.PostAsync(insuranceCompany.QuotationEndPoint, stringContent);
            if (response.IsSuccessStatusCode)
            {
                var stringData = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<InsureQuotationResponse>(stringData);
                //result.IsSuccess = true;
                //result.StatusCode = 200;
                //result.ResponseMessage = "Quotation Response Successfully.";
                return result;
            }
            else
            {
                return new InsureQuotationResponse
                {
                    StatusCode = (int)response.StatusCode,
                    IsSuccess = false,
                    InsuranceCompanyId = insuranceCompany.Id,
                    QuotationRequestId = quotationRequest.QuotationRequestId,
                    ResponseMessage = response.ReasonPhrase
                };
            }
        }

        public async Task<IssuePolicyResponse> IssuePolicy(IssuePolicyRequest policyRequest)
        {
            // Get insurance company details.
            
            var insuranceCompany = await unitOfWork.InsuranceCompany.GetAsync(p => p.Id == policyRequest.InsuranceCompanyId);
            var client = clientFactory.CreateClient(insuranceCompany.HttpClientName);
            var reqData = JsonConvert.SerializeObject(policyRequest);
            var stringContent = new StringContent(reqData, UnicodeEncoding.UTF8, "application/json");
            var response = await client.PostAsync(insuranceCompany.QuotationEndPoint, stringContent);
            if (response.IsSuccessStatusCode)
            {
                var stringData = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<IssuePolicyResponse>(stringData);
                //result.IsSuccess = true;
                //result.StatusCode = 200;
                //result.ResponseMessage = "Quotation Response Successfully.";
                return result;
            }
            else
            {
                return new IssuePolicyResponse
                {
                    
                    StatusCode = (int)response.StatusCode,
                    IsSuccess = false,
                    ResponseMessage = response.ReasonPhrase
                };
            }
        }
    }
}
