using System.Net.Http.Headers;
using WebUI.Services.Interfaces;

namespace WebUI.Services
{
    /// <summary>
    /// HTTP Message Handler để tự động thêm JWT token vào Authorization header
    /// </summary>
    public class AuthorizationMessageHandler : DelegatingHandler
    {
        private readonly IAuthService _authService;

        public AuthorizationMessageHandler(IAuthService authService)
        {
            _authService = authService;
        }

        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            // Lấy token hiện tại
            var token = _authService.CurrentToken;

            if (!string.IsNullOrEmpty(token) && !request.Headers.Contains("Authorization"))
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }

            return await base.SendAsync(request, cancellationToken);
        }
    }
}
