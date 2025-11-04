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

            // Nếu có token và chưa có Authorization header
            if (!string.IsNullOrEmpty(token) && !request.Headers.Contains("Authorization"))
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
                Console.WriteLine($"[AuthHandler] Added token to request: {request.RequestUri}");
            }
            else if (string.IsNullOrEmpty(token))
            {
                Console.WriteLine($"[AuthHandler] No token available for request: {request.RequestUri}");
            }

            return await base.SendAsync(request, cancellationToken);
        }
    }
}
