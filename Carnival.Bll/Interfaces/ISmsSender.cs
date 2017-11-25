using System.Threading.Tasks;

namespace Carnival.Bll.Interfaces
{
    public interface ISmsSender
    {
        Task SendSmsAsync(string number, string message);
    }
}
