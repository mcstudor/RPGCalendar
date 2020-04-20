namespace RPGCalendar.Identity
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;

    public interface IAuthenticationService
    {
        Task<string?> Login(LoginModel model);
        Task<string?> Register(RegistrationModel model);
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
        public async Task<string?> Login(LoginModel model)
        {
            if (model.Email is null && model.Username is null)
                return null;
            string? userId = null;
            if (model.Username is { })
            {
                var result = await _signInManager.PasswordSignInAsync(model.Username,
                    model.Password, model.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                    userId = (await _userManager.Users.FirstAsync(ur => ur.UserName == model.Username)).Id;
            }
            else if(model.Email is { })
            {
                var user = await _userManager.Users.FirstAsync(ur => ur.Email == model.Email);
                var result = await _signInManager.PasswordSignInAsync(user.UserName,
                    model.Password, model.RememberMe, lockoutOnFailure: false);
                userId = user.Id;
            }

            return userId;
        }

        public async Task<string?> Register(RegistrationModel model)
        {
            var user = new ApplicationUser { UserName = model.Username, Email = model.Email };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
                return null;
            

            await _signInManager.SignInAsync(user, isPersistent: false);
            return user.Id;


        }
    }
}
