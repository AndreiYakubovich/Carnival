using Carnival.Bll.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Carnival.Web.Controllers
{
    public class ProfileController : Controller
    {
        private IProfileService _profileService;

        public ProfileController(IProfileService profileService)
        {
            _profileService = profileService;
        }


        public IActionResult Index()
        {
            return View();
        }

        public ViewResult Profile(string id)
        {
            var profile = _profileService.GetProfile(id);
            return View(profile);
        }
    }
}