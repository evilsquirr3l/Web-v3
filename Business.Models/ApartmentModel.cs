using System.Collections.Generic;

namespace Business.Models
{
    public class ApartmentModel
    {
        public int Id { get; set; }
        
        public string Type { get; set; }

        public int HouseId { get; set; }

        public HouseModel House { get; set; }
        
        public ICollection<ResidentModel> Residents { get; set; }
    }
}