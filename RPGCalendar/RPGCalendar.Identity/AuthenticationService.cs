using System;
using System.Collections.Generic;
using System.Text;

namespace RPGCalendar.Identity
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Identity;

    public interface IAuthenticationService
    {
        Task<bool> Login(LoginModel model);
        Task<bool> Register(RegistrationModel model);
    }

    public class AuthenticationService : IAuthenticationService
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public AuthenticationService(SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }
        public async Task<bool> Login(LoginModel model)
        {

            var result = await _signInManager.PasswordSignInAsync(model.Email,
                model.Password, model.RememberMe, lockoutOnFailure: false);
            return result.Succeeded;
        }

        public async Task<bool> Register(RegistrationModel model)
        {
            var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, isPersistent: false);
                return true;
            }

            return false;



        }
    }
}
