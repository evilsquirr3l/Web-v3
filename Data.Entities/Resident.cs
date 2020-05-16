using System;
using System.Collections.Generic;

namespace Data.Entities
{
    public class Resident : BaseEntity
    {
        public string Name { get; set; }

        public DateTime BirthDate { get; set; }

        public ICollection<ApartmentResidents> Apartments { get; set; }
    }
}