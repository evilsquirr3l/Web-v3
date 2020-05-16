namespace Data.Entities
{
    public class ApartmentResidents
    {
        public int ApartmentId { get; set; }

        public int ResidentId { get; set; }

        public Apartment Apartment { get; set; }

        public Resident Resident { get; set; }
    }
}