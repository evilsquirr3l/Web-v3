using System.Collections.Generic;

namespace Data.Entities
{
    public class Apartment : BaseEntity
    {
        public ICollection<ApartmentResidents> Residents { get; set; }
    }
}