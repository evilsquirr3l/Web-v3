using System.Collections.Generic;

namespace Data.Entities
{
    public class City : BaseEntity
    {
        public string Name { get; set; }

        public double Population { get; set; }

        public ICollection<Street> Streets { get; set; }
    }
}