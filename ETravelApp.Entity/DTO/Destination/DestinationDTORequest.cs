namespace TravelApp.Entity.DTO.Destination
{
    public class DestinationDTORequest : DestinationDTOBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
    }
}
