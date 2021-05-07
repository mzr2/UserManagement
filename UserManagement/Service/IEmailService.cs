using System.Threading.Tasks;
using UserManagement.Models;

namespace UserManagement.Service
{
    public interface IEmailService
    {
        Task SendTestEmail(UserEmailOptions userEmailOptions);
    }
}