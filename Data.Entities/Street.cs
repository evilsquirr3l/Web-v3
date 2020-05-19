using System.Collections.Generic;

namespace Data.Entities
{
    public class Street : BaseEntity
    {
        public string Name { get; set; }

        public ICollection<House> Houses { get; set; }

        public int CityId { get; set; }

        public City City { get; set; }
    }
}