using System.Security.Claims;
using System.Threading.Tasks;
using BLL.ViewModels.Account;
using Carnival.Bll.Interfaces;
using Carnival.Data;
using Carnival.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace Carnival.Bll.Services
{
    public class AccountService:IAccountService
    {
        private readonly CarnivalContext _context;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;


        private static bool _databaseChecked;

        public AccountService(CarnivalContext context, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public Task<SignInResult> Login(LoginViewModel model)
        {
            return _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);
        }

        public async Task SignIn(User model, bool isPersistent)
        {
            await _signInManager.SignInAsync(model, isPersistent: isPersistent);
        }

        public async Task LogOff()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<User> GetCurrentUserAsync(ClaimsPrincipal user)
        {
            return await _userManager.GetUserAsync(user);
        }

        private static void EnsureDatabaseCreated(CarnivalContext context)
        {
            if (!_databaseChecked)
            {
                _databaseChecked = true;
                context.Database.EnsureCreated();
            }
        }

        public async Task<IdentityResult> Register(User user, RegisterViewModel model)
        {
           Task<IdentityResult> result = _userManager.CreateAsync(user, model.Password);
           return await result;
        }
    }
}