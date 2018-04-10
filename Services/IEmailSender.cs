using System.Threading.Tasks;

namespace Redoak.Backoffice.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
