using BackEnd_Zahri.DTO;

namespace BackEnd_Zahri.Interface
{
    public interface IUser
    {
        Task Registration(CreateUserDTO createUserDTO);
        Task<ReadUserDTO> Authenticate(string username, string password);
        Task<IEnumerable<ReadUserDTO>> GetAll();
        Task<CreateUserDTO> Update(CreateUserDTO obj);


    }
}
