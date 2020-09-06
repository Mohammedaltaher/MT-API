using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace  AggriPortal.API.Domain.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            DefaultLang = "ar";
            CreatedDate = DateTime.Now;
            IsActive = true;

            QuotationsMotorRequests = new HashSet<QuotationsMotorRequest>();
            Claims = new HashSet<ApplicationUserClaim>();
            Logins = new HashSet<ApplicationUserLogin>();
            Tokens = new HashSet<ApplicationUserToken>();
            UserRoles = new HashSet<ApplicationUserRole>();
         
            ApplicationUserLoginsHistory = new HashSet<ApplicationUserLoginHistory>();
        }
        public string FullName { get; set; }
        public string FullNameAr { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public bool IsActive { get; set; }
        public string DefaultLang { get; set; }
        public string CreatedBy { get; set; }
        public ICollection<QuotationsMotorRequest> QuotationsMotorRequests { get; set; }
        public virtual ICollection<ApplicationUserClaim> Claims { get; set; }
        public virtual ICollection<ApplicationUserLogin> Logins { get; set; }
        public virtual ICollection<ApplicationUserToken> Tokens { get; set; }
        public virtual ICollection<ApplicationUserRole> UserRoles { get; set; }
        public ICollection<ApplicationUserLoginHistory> ApplicationUserLoginsHistory { get; set; }
        public ICollection<Client> Clients { get; set; }
        public ICollection<Ticket> Tickets { get; set; }
    }

    public class ApplicationRole : IdentityRole
    {
        public string CreatedBy { get; set; }
        public virtual ICollection<ApplicationUserRole> UserRoles { get; set; }
        public virtual ICollection<ApplicationRoleClaim> RoleClaims { get; set; }
    }

    public class ApplicationUserRole : IdentityUserRole<string>
    {
        public string CreatedBy { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual ApplicationRole Role { get; set; }
    }

    public class ApplicationUserClaim : IdentityUserClaim<string>
    {
        public ApplicationUser User { get; set; }
    }

    public class ApplicationRoleClaim : IdentityRoleClaim<string>
    {
        public ApplicationRole Role { get; set; }
    }

    public class ApplicationUserLogin : IdentityUserLogin<string>
    {
        public ApplicationUser User { get; set; }
    }

    public class ApplicationUserToken : IdentityUserToken<string>
    {
        public ApplicationUser User { get; set; }
    }
    /// Custom table to save user login history
    public class ApplicationUserLoginHistory
    {
        public ApplicationUserLoginHistory()
        {
            Id = Guid.NewGuid().ToString();
            CreatedDate = DateTime.Now;
        }
        public string Id { get; set; }
        public string ApplicationUserId { get; set; }
        public string IPAddress { get; set; }
        public string Browser { get; set; }
        public string OS { get; set; }
        public string CountryCode { get; set; }
        public string CountryName { get; set; }
        public string RegionCode { get; set; }
        public string RegionName { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string TimeZone { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }


}
