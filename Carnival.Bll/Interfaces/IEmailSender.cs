using System.Threading.Tasks;

namespace Carnival.Bll.Interfaces
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
