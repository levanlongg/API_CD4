using Microsoft.EntityFrameworkCore;
using ngcd4.Models;
using ngcd4.ViewModels.Client.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ngcd4.Services.Client.User
{
    public class UserServices : IUserService
    {
        //private readonly UserManager<Dbuser> _userManager;
        //private readonly SignInManager<Dbuser> _signInManager;
        //private readonly RoleManager<Dbuser> _roleManager;

        private readonly CoreDbContext _context;

        public UserServices(CoreDbContext context)
        {
            _context = context;
        }

        //public UserServices(UserManager<Dbuser> userManager, SignInManager<Dbuser> signInManager, RoleManager<Dbuser> roleManager)
        //{
        //    _userManager = userManager;
        //    _signInManager = signInManager;
        //    _roleManager = roleManager;
        //}
        public async Task<Dbuser> Login(UserLoginViewModel userLoginViewModel)
        {
            var user = await _context.Dbuser.FirstOrDefaultAsync(u => u.AcountName == userLoginViewModel.AcountName && u.UserPassword == userLoginViewModel.UserPassword);
            return user;
            //throw new NotImplementedException();
        }

        //public async Task<Dbuser> IUserService.Login(UserLoginViewModel request)
        //{

        //    var user = await _userManager.FindByNameAsync(request.AcountName);
        //    if (user == null)
        //    {
        //        return null;
        //    }
        //    var result = await _signInManager.CheckPasswordSignInAsync(user, request.UserPassword, true);
        //    {
        //        if (result.Succeeded)
        //        {
        //            return null;
        //        }
        //    }
        //    var role = await _userManager.GetRolesAsync(user);
        //    var Clames = new[]
        //    {
        //        new Claim(ClaimTypes.Email, user.Email),
        //        new Claim(ClaimTypes.GivenName, user.Fullname),
        //    };

        //    //throw new NotImplementedException();
        //}

        public async Task<int> Register(UserRegisterViewModel userRegisterViewModel)
        {
            Dbuser user = new Dbuser()
            {
                Id = userRegisterViewModel.Id,
                Fullname = userRegisterViewModel.Fullname,
                DateOfBirth = userRegisterViewModel.DateOfBirth,
                UserAddress = userRegisterViewModel.UserAddress,
                Email = userRegisterViewModel.Email,
                PhoneNumber = userRegisterViewModel.PhoneNumber,
                AcountName = userRegisterViewModel.AcountName,
                UserPassword = userRegisterViewModel.UserPassword,
                ReturnPassword = userRegisterViewModel.ReturnPassword,
            };
            _context.Dbuser.Add(user);
            int res = await _context.SaveChangesAsync();
            return res;
            //throw new NotImplementedException();
        }
    }
}
