using System;
using System.Collections.Generic;

namespace Business.Models
{
    public class ResidentModel
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        public DateTime BirthDate { get; set; }

        public ICollection<ApartmentModel> Apartments { get; set; }
    }
}