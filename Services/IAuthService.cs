using Ecotrack.Net.Models;
using Ecotrack.Net.ViewModel;

namespace Ecotrack.Api.Net.Services
{
    public interface IAuthService
    {
        string Authenticate(LoginViewModel login);
    }
}
