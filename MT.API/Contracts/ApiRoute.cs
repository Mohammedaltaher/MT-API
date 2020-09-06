namespace  AggriPortal.API.Contracts
{
    public static class ApiRoute
    {

        public static class Account
        {
            public const string Create = "api/account/create"; 
            public const string Login = "api/account/login"; 
            public const string ChangePassword = "api/account/changepassword";

            public const string Activation = "api/account/activation";
            public const string ChangeEmail = "api/account/changeemail";

            public const string Client = "api/account/clients";  //Employees (List of employees Registered By Admin) 
            public const string Employees = "api/account/employees"; //Employees (List of employees Registered By Admin) 

            public const string EmployeeDetails = "api/account/employee/details/{Id}"; //Get employee account info 
            public const string ClientDetails = "api/account/client/details/{Id}"; //Get client account info 

            public const string update = "api/account/update"; //Update employee account (admin permission) 
            public const string ResetrRquest = "api/account/resetrequest"; //Reset employee account (admin permission) 
            public const string Reset = "api/account/reset";

        }
        public static class Setting
        {
            public const string Roles = "api/setting/roles";
            public const string Permissions = "api/setting/permissions";
            public const string UserClaims = "api/setting/userclaims";
            public const string AddRole = "api/setting/role/add";
            public const string AddUserClaims = "api/setting/userclaims/add";
            public const string SignUserRoles = "api/setting/user/signroles";
            public const string RemoveUserRoles = "api/setting/user/removeroles";
            public const string RemoveUserClaims = "api/setting/userclaims/Remove";
            public const string UpdateRole = "api/setting/role/update";
        }
        public static class Client
        {
            public const string Search = "api/clients/search";
            public const string Vehicles = "api/client/vehicles";
            public const string Policies = "api/client/policies";
            public const string Quotations = "api/client/quotation";
            public const string Invoices = "api/client/invoices";
            public const string VehicleDetails = "api/vehicles";
            public const string Details = "api/client/details/{Id}";
            public const string Update = "api/client/update";
            public const string Reminder = "api/client/reminder";
        }
        public static class Home
        {
            public const string Dashboard = "api/home/dashboard";
            public const string LatestQuotation = "api/home/Latestquotation";
            public const string QuotationPreview = "api/home/Latestquotition/details/{Id}";
        
        }
        public static class Policy
        {
            public const string Policies = "api/policy";
            public const string PrintInvoice = "api/policy/printinvoice/{Id}";
            public const string Search = "api/policy/search";
            public const string Details = "api/policy/details/{Id}";

        }
        public static class Quotation
        {
            public const string ClinetQuotations = "api/client/quotation";
            public const string Search = "api/quotation/search";
            public const string Details = "api/quotation/details/{Id}";
        }
        public static class Logger
        {
            public const string HistoryLog = "api/Logger/historylog";
            public const string SMSLog = "api/logger/smslog";
            public const string loginHistory = "api/logger/client/loginhistory";

        }
        public static class Ticket
        {
            public const string Tickets = "api/tickets";
            public const string FollowUp = "api/tickets/followup";
            public const string TicketFollowUp = "api/tickets/followup/add";
            public const string UpdateStatus = "api/tickets/Status/update";

        }
        public static class MasterTable
        {
            public const string VehicleDetails = "api/master/VehicleDetails";
            public const string ProductType = "api/master/products";
            public const string Benefit = "api/master/benefits";
            public const string PremiumBreakdown = "api/master/PremiumBreakdowns";
            public const string PromoCode = "api/master/PromoCodes";
            public const string NCDFreeYear = "api/master/NCDFreeYears";
            public const string IdentityType = "api/master/IdentityTypes";
            public const string Gender = "api/master/Genders";
            public const string EducationLevel = "api/master/EducationLevels";
            public const string SocialStatus = "api/master/SocialStatus";
            public const string OccupationMale = "api/master/OccupationMales";
            public const string OccupationFemale = "api/master/OccupationFemales";
            public const string Countries = "api/master/Countries";
            public const string Region = "api/master/Regions";
            public const string Cities = "api/master/Cities";
            public const string LicenseType = "api/master/LicenseTypes";
            public const string DriverType = "api/master/DriverTypes";
            public const string DrivingPercentage = "api/master/DrivingPercentages";
            public const string MedicalCondition = "api/master/MedicalConditions";
            public const string Mileage = "api/master/Mileages";
            public const string VehicleIdType = "api/master/VehicleIdTypes";
            public const string VehicleMaker = "api/master/VehicleMakers";
            public const string VehicleModel = "api/master/VehicleModels";
            public const string VehiclePlateType = "api/master/VehiclePlateTypes";
            public const string VehiclePlateLetter = "api/master/VehiclePlateLetters";
            public const string TransmissionType = "api/master/TransmissionTypes";
            public const string VehicleBodyType = "api/master/VehicleBodyTypes";
            public const string VehicleAxlesWeight = "api/master/VehicleAxlesWeights";
            public const string VehicleColor = "api/master/VehicleColors";
            public const string VehicleEngineSize = "api/master/VehicleEngineSizes";
            public const string VehicleSpecification = "api/master/VehicleSpecifications";
            public const string VehicleUse = "api/master/VehicleUses";
            public const string VehicleRepairMethod = "api/master/VehicleRepairMethods";
            public const string ParkingLocation = "api/master/ParkingLocations";
            public const string PaymentMethod = "api/master/PaymentMethods";
            public const string Bank = "api/master/Banks";
            public const string Relation = "api/master/relations";
            public const string Attachment = "api/master/Attachments";
        }
    }
}
