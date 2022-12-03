using System.Threading.Tasks;

namespace Mandegar.Utilities.Interfaces
{
    public interface ISendMail
    {
        Task<bool> SendAsync();
        Task<bool> SendAsync(string to, string subject, string body);
    }
}
