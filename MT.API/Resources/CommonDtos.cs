using System;

namespace  AggriPortal.API.Resources
{
    public class VechicleDriversDto
    {
        public string Id { get; set; }
        public long IdentityNumber { get; set; }
        public string FullName { get; set; }
        public string FullNameAr { get; set; }
        public string BirthDate { get; set; }
        public string DrivingPercentageName { get; set; }
        public string DrivingPercentageNameAr { get; set; }
    }
    public class AttachmentsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameAr { get; set; }
    }

    public class BenefitDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string NameAr { get; set; }
        public decimal? BenefitAmount { get; set; }

    }
}
