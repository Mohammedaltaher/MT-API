namespace  AggriPortal.API.Contracts.Response
{
    public class UserGeoLocationResponse:BaseResponse
    {
        public string IP { get; set; }
        public string Type { get; set; }
        public string Continent_code { get; set; }
        public string Continent_name { get; set; }
        public string Country_code { get; set; }
        public string Country_name { get; set; }
        public string Region_code { get; set; }
        public string Region_name { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
    }
}
