using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BLL.ViewModels.Authorization
{
    public class LogoutViewModel
    {
        [BindNever]
        public string RequestId { get; set; }
    }
}
