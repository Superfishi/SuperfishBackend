using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Azure.Mobile.Server.Authentication;
using Microsoft.Azure.Mobile.Server.Config;

namespace SuperfishBackendService.Controllers
{
    [Authorize]
    [MobileAppController]
    public class AuthenticatedController : ApiController
    {

        public async Task<ProviderCredentials> Get()
        {
            var claimsPrincipal = this.User as ClaimsPrincipal;
            return await this.User.GetAppServiceIdentityAsync<AzureActiveDirectoryCredentials>(this.Request);
        }

    }
}
