using AggriPortal.API.Domain.ServiceModels;
using AggriPortal.API.Options;
using AggriPortal.API.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;

namespace  AggriPortal.API.Services
{
    public interface IMessagerService
    {
        Task<GeneralOperationResult> SendEmailAsync(string email, string subject, string htmlMessage, ICollection<IFormFile> files = null,
                                     MailPriority priority = MailPriority.Normal);
        Task<GeneralOperationResult> SendAccountVerificationEmail(string email, string verificationCode, string defLang);
        Task<GeneralOperationResult> SendResetPasswordEmail(string email, string verificationCode, string lastPhoneDigits, string defLang);
        Task<GeneralOperationResult> SendReminderEmail(string email, string message);
        Task<GeneralOperationResult> SendPasswordChangedConfirmationEmail(string email, DateTime changedDate, string location, string ip, string defLang);
        Task<GeneralOperationResult> SendPasswordChangedByAdminEmail(string email, DateTime changedDate, string defLang , string password);
        Task<GeneralOperationResult> SendEmailChangedByAdminEmail(string email, DateTime changedDate, string defLang);
        Task<GeneralOperationResult> SendSmsAsync(string numbers, string message);
    }

    public class MessagerService : IMessagerService
    {
        private readonly SmtpOptions smtpOptions;
        private readonly SmsOptions smsOptions;
        private readonly IHttpClientFactory clientFactory;
        private readonly IUnitOfWork unitOfWork;
        public MessagerService(IOptions<SmtpOptions> smtpOptions, IOptions<SmsOptions> smsOptions, IHttpClientFactory clientFactory, IUnitOfWork unitOfWork)
        {
            this.smtpOptions = smtpOptions.Value;
            this.smsOptions = smsOptions.Value;
            this.clientFactory = clientFactory;
            this.unitOfWork = unitOfWork;
        }

        public Task<GeneralOperationResult> SendAccountVerificationEmail(string email, string verificationCode, string defLang)
        {
            var template = Directory.GetCurrentDirectory() + "\\wwwroot\\Templates\\Emails\\"+ defLang + "\\ConfirmationEmail.html";
            string htmlMessage = File.ReadAllText(template);
            htmlMessage = htmlMessage.Replace("{{ConfirmationNumber}}", verificationCode);
            return this.SendEmailAsync(email, "Verify your account - Concord online aggrigator", htmlMessage);
        }

        public Task<GeneralOperationResult> SendEmailAsync(string email, string subject, string htmlMessage, ICollection<IFormFile> files = null,
                                     MailPriority priority = MailPriority.Normal)
        {
            try
            {
                // Credentials
                var credentials = new NetworkCredential(smtpOptions.Sender, smtpOptions.Password);

                // Mail message
                var mail = new MailMessage()
                {
                    From = new MailAddress(smtpOptions.Sender, smtpOptions.SenderName),
                    Subject = subject,
                    Body = htmlMessage,
                    IsBodyHtml = true
                };

                mail.To.Add(new MailAddress(email));

                // Smtp client
                var client = new SmtpClient()
                {
                    Port = smtpOptions.Port,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Host = smtpOptions.Host,
                    EnableSsl = smtpOptions.EnableSsl,
                    Credentials = credentials
                };

                //Attachments
                if (files != null)
                {
                    foreach (var file in files)
                    {
                        using (var memoryStream = new MemoryStream())
                        {
                            file.CopyTo(memoryStream);
                            var fileBytes = memoryStream.ToArray();
                            var att = new Attachment(new MemoryStream(fileBytes), file.FileName);
                            mail.Attachments.Add(att);
                        }
                    }
                }

                // Send it...         
                client.Send(mail);
                return Task.FromResult(new GeneralOperationResult(true,"Email Sent Successfully"));
            }
            catch (Exception ex)
            {
                return Task.FromResult(new GeneralOperationResult(false,ex.Message));
            }
        }

        public Task<GeneralOperationResult> SendResetPasswordEmail(string email, string verificationCode, string phoneLast4Digit, string defLang)
        {
            var template = Directory.GetCurrentDirectory() + "\\wwwroot\\Templates\\Emails\\" + defLang + "\\PasswordResetEmail.html";
            string htmlMessage = File.ReadAllText(template);
            htmlMessage = htmlMessage.Replace("{{ConfirmationNumber}}", verificationCode);
            htmlMessage = htmlMessage.Replace("{{Email}}", HttpUtility.HtmlEncode(email));
            htmlMessage = htmlMessage.Replace("{{PhoneLast4Digit}}", phoneLast4Digit);

            //?email={{Email}}&bin={{PhoneLast4Digit}}
            return this.SendEmailAsync(email, "Reset your account - Concord online aggrigator", htmlMessage);
        }
        public Task<GeneralOperationResult> SendReminderEmail(string email,string message)
        {
            return this.SendEmailAsync(email, "Reminder - Concord online aggrigator", message);
        }
        public Task<GeneralOperationResult> SendPasswordChangedConfirmationEmail(string email, DateTime changedDate, string location, string ip, string defLang)
        {
            var template = Directory.GetCurrentDirectory() + "\\wwwroot\\Templates\\Emails\\" + defLang + "\\PasswordConfirmationEmail.html";
            string htmlMessage = File.ReadAllText(template);
            htmlMessage = htmlMessage.Replace("{{date}}", changedDate.ToString("dd-MMM-yyyy"));
            htmlMessage = htmlMessage.Replace("{{time}}", changedDate.ToShortTimeString());
            htmlMessage = htmlMessage.Replace("{{ip}}", ip);
            htmlMessage = htmlMessage.Replace("{{location}}", location);

            return this.SendEmailAsync(email, "Password Changed Confirmation - Concord online aggrigator", htmlMessage);
        }
       
        public async Task<GeneralOperationResult> SendSmsAsync(string numbers, string message)
        {
            string userId = "mohmmedali@hotmail.com";
            string password = "flatron";
            string sender = "Oasis CS-AD";
            var url = string.Format("http://api.unifonic.com/wrapper/sendSMS.php?userid={0}&password={1}&msg={2}&sender={3}&to={4}", userId, password, HttpUtility.UrlEncode(message), HttpUtility.UrlEncode(sender), numbers);

            //Send the GET request
            //HttpClient client = clientFactory.CreateClient();
            //HttpRequestMessage httpRequest = new HttpRequestMessage(HttpMethod.Get, url);
            //var response = await client.SendAsync(httpRequest);

            //if (response.IsSuccessStatusCode)
            //{
            //    var responseResult = await response.Content.ReadAsStringAsync();
            //    var resultObj = JObject.Parse(responseResult);
            //    status = resultObj["success"].ToString();
            //    Console.WriteLine(responseResult);
            //}

            var baseAddress = new Uri("https://api.unifonic.com/rest/");
            var status = "false";
            GeneralOperationResult sendSmsResult;
            using (var httpClient = new HttpClient { BaseAddress = baseAddress })
            {
                using (var content = new StringContent("AppSid=VxcprXsqv7PCrpSJGMXL9cON4Wg3p&Recipient=" + numbers + "&Body=" + message + "&SenderID=" + sender, System.Text.Encoding.UTF8,"application/x-www-form-urlencoded"))
                {
                    using (var response = await httpClient.PostAsync("Messages/Send", content))
                    {
                        var responseData = await response.Content.ReadAsStringAsync();
                        var resultObj = JObject.Parse(responseData);
                        status = resultObj["success"].ToString();
                        sendSmsResult = new GeneralOperationResult(status == "true", resultObj["success"].ToString());
                        Console.WriteLine(responseData);
                        Console.WriteLine(status);
                    }
                }
            }

            return sendSmsResult;
        }

        public Task<GeneralOperationResult> SendPasswordChangedByAdminEmail(string email, DateTime changedDate, string defLang , string password)
        {
            var template = Directory.GetCurrentDirectory() + "\\wwwroot\\Templates\\Emails\\" + defLang + "\\PasswordChangedByAdminEmail.html";
            string htmlMessage = File.ReadAllText(template);
            htmlMessage = htmlMessage.Replace("{{date}}", changedDate.ToString("dd-MMM-yyyy"));
            htmlMessage = htmlMessage.Replace("{{time}}", changedDate.ToShortTimeString());
            htmlMessage = htmlMessage.Replace("{{password}}", password);

            return this.SendEmailAsync(email, "Password Changed Confirmation - Concord online aggrigator", htmlMessage);
        }
        public Task<GeneralOperationResult> SendEmailChangedByAdminEmail(string email, DateTime changedDate, string defLang)
        {
            var template = Directory.GetCurrentDirectory() + "\\wwwroot\\Templates\\Emails\\" + defLang + "\\EmailChangedByAdminEmail.html";
            string htmlMessage = File.ReadAllText(template);
            htmlMessage = htmlMessage.Replace("{{date}}", changedDate.ToString("dd-MMM-yyyy"));
            htmlMessage = htmlMessage.Replace("{{time}}", changedDate.ToShortTimeString());
            htmlMessage = htmlMessage.Replace("{{email}}", email);

            return this.SendEmailAsync(email, "Email Changed Confirmation - Concord online aggrigator", htmlMessage);
        }

    }
}
