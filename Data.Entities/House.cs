using System.Collections.Generic;

namespace Data.Entities
{
    public class House : BaseEntity
    {
        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public ICollection<Apartment> Apartments { get; set; }

        public Street Street { get; set; }
    }
}