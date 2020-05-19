using System.Collections.Generic;
using Data.Entities;

namespace Business.Models
{
    public class HouseModel
    {
        public int Id { get; set; }
        
        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public ICollection<ApartmentModel> Apartments { get; set; }

        public int StreetId { get; set; }
        
        public StreetModel Street { get; set; }
    }
}