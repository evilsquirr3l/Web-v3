using System.Collections.Generic;

namespace Data.Entities
{
    public class Apartment : BaseEntity
    {
        public string Type { get; set; }

        public int HouseId { get; set; }

        public House House { get; set; }
        
        public ICollection<ApartmentResidents> Residents { get; set; }
    }
}