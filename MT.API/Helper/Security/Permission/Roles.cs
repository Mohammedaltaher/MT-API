using System.Collections.Generic;

namespace  AggriPortal.API.Security.Permission
{
    public static  class Roles
    {
        public const string
            ViewEmployeesAccounts = "View.Employees.Accounts",
            ViewClientsAccounts = "View.Clients.Accounts",
            UpdateAccount = "Update.Account",
            ViewClientsDetails = "View.Clients.Details",
            UpdateClientsDetails = "Update.Clients.Details",
            ViewAPILogger = "View.API.Logger",
            ManagePolicies = "Manage.Policies",
            ViewPolicies = "View.Policies",
            ViewQuotations = "View.Quotations",
            ManageIdentity = "Manage.Identity",
            CreateAccount = "Create.Account",
            ManageClientPayments = "Manage.Client.Payments" ,
            ManageTickets = "Manage.Tickets",
            SuperAdmin = "Super.Admin",
            Administrator = "Administrator";
    }
}
