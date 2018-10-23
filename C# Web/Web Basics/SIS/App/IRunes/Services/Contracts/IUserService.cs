namespace IRunes.Services.Contracts
{
    using IRunes.Models;
    using IRunes.ViewModels;

    public interface IUserService
    {
        User GetUser(LoginViewModel model);

        bool RegisterUser(RegisterViewModel model);

        bool CheckUserExist(User user);
    }
}