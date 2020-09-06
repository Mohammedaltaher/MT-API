using System.Collections.Generic;

namespace  AggriPortal.API.Domain.Models
{
    public class Region
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameAr { get; set; }
        public ICollection<City> Cities { get; set; }
    }
}
