using System.Security.Claims;
using System.Threading.Tasks;
using BLL.ViewModels.Account;
using Carnival.Data.Models;
using Microsoft.AspNetCore.Identity;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace Carnival.Bll.Interfaces
{
    public interface IAccountService
    {
        Task<IdentityResult> Register(User user, RegisterViewModel model);
        Task<SignInResult> Login(LoginViewModel model);
        Task SignIn(User model, bool isPersistent);
        Task LogOff();
        Task<User> GetCurrentUserAsync(ClaimsPrincipal user);
    }
}
