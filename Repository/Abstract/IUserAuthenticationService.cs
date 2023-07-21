using TheChampions.Models.DTO;

namespace TheChampions.Repository.Abstract
{
    public interface IUserAuthenticationService
    {
        Task<Status> LoginAsync(LoginModel model);
        Task LogoutAsync();
        //Task<Status> RegisterAsync(RegistrationModel model);
        Task<Status> RegistrationAsync(RegistrationModel model);
        Task<Status> ChangePasswordAsync(ChangePasswordModel model, string username);
    }
}
