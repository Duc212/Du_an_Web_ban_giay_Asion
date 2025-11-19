using Microsoft.JSInterop;
using System.Net.Http.Headers;

namespace AdminWeb.Services
{
    public class AuthorizationMessageHandler : DelegatingHandler
    {
        private readonly IJSRuntime _jsRuntime;

        public AuthorizationMessageHandler(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            try
            {
                // Lấy token từ localStorage
                var token = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", "admin_access_token");

                if (!string.IsNullOrEmpty(token))
                {
                    // Thêm token vào Authorization header
                    request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
                }
            }
            catch (Exception ex)
            {
                // Log error if needed
                Console.WriteLine($"Error getting token: {ex.Message}");
            }

            return await base.SendAsync(request, cancellationToken);
        }
    }
}
