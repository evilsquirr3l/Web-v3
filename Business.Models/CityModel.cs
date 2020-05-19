using System.Collections.Generic;
using Data.Entities;

namespace Business.Models
{
    public class CityModel
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        public int Population { get; set; }

        public ICollection<StreetModel> Streets { get; set; }

        public int CountryId { get; set; }

        public CountryModel CountryModel { get; set; }
    }
}