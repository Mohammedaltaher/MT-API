namespace  AggriPortal.API.Resources
{
    public class SaudiPostDto
    {
        public int InsuredId { get; set; }
        public string InsuredMobileNumber { get; set; }
        public string InsuredEmail { get; set; }
        public int? InsuredBuildingNumber { get; set; }
        public string InsuredStreet { get; set; }
        public string InsuredDistrict { get; set; }
        public string InsuredCity { get; set; }
        public int? InsuredPostalCode { get; set; }
        public int? InsuredAdditionalNumber { get; set; }
    }
}
