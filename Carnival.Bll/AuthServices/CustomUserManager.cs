using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Carnival.Data;
using Carnival.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Carnival.Bll.AuthServices
{
    public class CustomUserManager:UserManager<User>
    {
        private readonly CarnivalContext _context;

        public CustomUserManager(IUserStore<User> store, IOptions<IdentityOptions> optionsAccessor, IPasswordHasher<User> passwordHasher, IEnumerable<IUserValidator<User>> userValidators, IEnumerable<IPasswordValidator<User>> passwordValidators, ILookupNormalizer keyNormalizer, IdentityErrorDescriber errors, IServiceProvider services, ILogger<UserManager<User>> logger, CarnivalContext context) : base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services, logger)
        {
            _context = context;
        }

        public override Task<IdentityResult> CreateAsync(User user, string password)
        {
//            Task<IdentityResult> result = base.CreateAsync(user, password);
//            if (result.Result.Succeeded)
//            {
//                _context.Profiles.AddAsync(new UserProfile(result))
//            }
            return base.CreateAsync(user, password);
        }
    }
}