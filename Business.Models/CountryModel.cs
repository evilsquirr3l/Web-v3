using System.Collections.Generic;

namespace Business.Models
{
    public class CountryModel
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public ICollection<CityModel> Cities { get; set; }
    }
}