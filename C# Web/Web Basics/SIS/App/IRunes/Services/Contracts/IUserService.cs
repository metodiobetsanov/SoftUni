namespace IRunes.Services.Contracts
{
    using IRunes.Models;
    using IRunes.ViewModels;

    public interface IUserService
    {
        User GetUser(Login model);

        bool RegisterUser(Register model);

        bool CheckUserExist(User user);
    }
}