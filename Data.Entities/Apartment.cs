using System.Collections.Generic;

namespace Data.Entities
{
    public class Apartment : BaseEntity
    {
        public string Type { get; set; }
        public ICollection<ApartmentResidents> Residents { get; set; }
    }
}