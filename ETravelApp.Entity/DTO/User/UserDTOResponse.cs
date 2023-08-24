using TravelApp.Entity.DTO.User;

namespace TravelApp.Entity.DTO.UserDTO
{
    public class UserDTOResponse:UserDTOBase
    {
        public Guid? Guid { get; set; }
    }
}
