using ngcd4.Models;
using ngcd4.ViewModels.Client.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ngcd4.Services.Client.User
{
    public interface IUserService
    {
        Task<Dbuser> Login(UserLoginViewModel userLoginViewModel);

        Task<int> Register(UserRegisterViewModel userRegisterViewModel);
    }
}
