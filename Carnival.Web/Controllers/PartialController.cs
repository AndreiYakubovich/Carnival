using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;

namespace Carnival.Web.Controllers
{
    [SwaggerIgnore]
    public class PartialController : Controller
    {
        public IActionResult AboutComponent() => PartialView();

        public IActionResult AppComponent() => PartialView();

        public IActionResult ContactComponent() => PartialView();

        public IActionResult IndexComponent() => PartialView();

        public IActionResult LoginComponent() => PartialView();

        public IActionResult RegisterComponent() => PartialView();

        public IActionResult ManageComponent() => PartialView();

        public IActionResult ChangePasswordComponent() => PartialView();

        public IActionResult ProfileComponent() => PartialView();
    }
}
