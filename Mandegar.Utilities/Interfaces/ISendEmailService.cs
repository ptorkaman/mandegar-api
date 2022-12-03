using System.Threading.Tasks;

namespace Mandegar.Utilities.Interfaces
{
    public interface ISendEmailService
    {
        Task SendAsync(string to, string subject, string body);
    }
}
