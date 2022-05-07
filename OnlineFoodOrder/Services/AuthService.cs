
using Microsoft.AspNetCore.Identity;
//using Microsoft.Extensions.Options;
using static OnlineFoodOrder.Models.AuthClass;
using OnlineFoodOrder.Models;

namespace OnlineFoodOrder.Services
{
    public class AuthService
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        // private readonly HttpContext _httpContext;


        public AuthService(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            this._signInManager = signInManager;
            this._userManager = userManager;
            //  this._httpContext = _httpContext;
            //, HttpContext _httpContext

        }
        //<IdentityResult>
        public async Task<IdentityResult> RegisterUser(Register register)
        {
            string temp = string.Empty;
            var registerNewUser = new IdentityUser() { UserName = register.UserName, Email = register.Email };
            // Create User
            var result = await _userManager.CreateAsync(registerNewUser, register.Password);

            return result;
        }

        public async Task<requestType> LoginUser(Login login)
        {
            int loginResult = (int)requestType.Sucessfull;
            var user = await _userManager.FindByEmailAsync(login.Email);
            var allUser = _userManager.Options.User.ToString();
            if (user == null)
            {
                loginResult = (int)requestType.InvalidEmail;
                return (requestType)(int)requestType.InvalidEmail;
            }
            //_httpContext.Session.SetString("CurrentUser", user.UserName);
            var result = await _signInManager.PasswordSignInAsync(user.UserName, login.Password, false, lockoutOnFailure: true);
            if (!result.Succeeded)
            {
                loginResult = (int)requestType.InvalidPassword;
               
            }
            return (requestType)(int)requestType.InvalidPassword;

        }
    }
}

