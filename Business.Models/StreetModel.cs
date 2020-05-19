using System.Collections.Generic;
using Business.Models;

namespace Data.Entities
{
    public class StreetModel
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        public ICollection<HouseModel> Houses { get; set; }

        public int CityId { get; set; }

        public CityModel City { get; set; }
    }
}