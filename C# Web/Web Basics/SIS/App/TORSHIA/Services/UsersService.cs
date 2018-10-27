using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TORSHIA.Data;
using TORSHIA.Models;
using TORSHIA.Models.Enums;
using TORSHIA.Services.Contracts;
using TORSHIA.ViewModels;

namespace TORSHIA.Services
{
    public class UsersService : IUsersService
    {
        private readonly TorshiaContext context;

        public UsersService(TorshiaContext context)
        {
            this.context = context;
        }
        public User LoginUser(LoginViewModel model)
        {
            return this.context.Users.FirstOrDefault(u => u.Username == model.Username && u.Password == model.Password);
        }

        public User RegisterUser(RegisterViewModel model)
        {
                Role role = this.context.Users.Any() ? Role.User : Role.Admin;

                User user = new User()
                {
                    Username = model.Username,
                    Password = model.Password,
                    Email = model.Email,
                    Role = role
                };

                context.Users.Add(user);
                context.SaveChangesAsync();

                return user;
        }
    }
}
