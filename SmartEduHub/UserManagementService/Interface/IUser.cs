using UserManagementService.Dtos;
using UserManagementService.Repos;

namespace UserManagementService.Interface
{
    public interface IUser
    {
        Task<RegisterResponsedto> Register(RegisterDto objReg);
    }
}
