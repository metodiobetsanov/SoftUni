namespace IRunes.Services
{
    using IRunes.Data;
    using IRunes.Models;
    using IRunes.Services.Contracts;
    using IRunes.ViewModels;
    using SIS.FRAMEWORK.Services.Contracts;
    using System;
    using System.Linq;

    public class UserService : IUserService
    {
        protected IRunesDbContext Context { get; set; }

        protected IHashService HashService { get; set; }

        protected IUserCookieService UserCookieService { get; set; }

        public UserService(IHashService hashService, IUserCookieService userCookieService)
        {
            this.HashService = hashService;
            this.UserCookieService = userCookieService;
            this.Context = new IRunesDbContext();
        }

        public User GetUser(Login model)
        {
            string passwordHashed = this.HashService.Hash(model.Password);
            User user = null;
            using (Context)
            {
                user = Context.Users
                    .FirstOrDefault(u => u.Username == model.Username && u.Password == passwordHashed);
            }

            return user;
        }

        public bool RegisterUser(Register model)
        {
            string password = this.HashService.Hash(model.Password);
            string confirmPassword = this.HashService.Hash(model.ConfirmPassword);

            if (password != confirmPassword)
            {
                return false;
            }

            User user = new User()
            {
                Username = model.Username,
                Password = password,
                Email = model.Email
            };

            if (this.CheckUserExist(user))
            {
                return false;
            }

            try
            {
                Context.Users.Add(user);
                Context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw new InvalidOperationException("Something went wrong with db request to save user");
            }
        }

        public bool CheckUserExist(User user)
        {
            return this.Context.Users.Any(u => u.Username == user.Username || u.Email == user.Email && u.Password == user.Password);
        }
    }
}