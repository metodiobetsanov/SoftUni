namespace TORSHIA.Services.Contracts
{
    using TORSHIA.Models;
    using TORSHIA.ViewModels;

    public interface IUsersService
    {
        User LoginUser(LoginViewModel model);

        User RegisterUser(RegisterViewModel model);
    }
}