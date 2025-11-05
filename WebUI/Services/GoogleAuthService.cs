using Microsoft.JSInterop;
using System.Text.Json;
using WebUI.Models;
using WebUI.Constants;

namespace WebUI.Services
{
    public class GoogleAuthService
    {
        private readonly IJSRuntime _jsRuntime;
        private readonly HttpClient _httpClient;
        private readonly ConfigurationService _configService;
        
        public GoogleAuthService(IJSRuntime jsRuntime, HttpClient httpClient, ConfigurationService configService)
        {
            _jsRuntime = jsRuntime;
            _httpClient = httpClient;
            _configService = configService;
        }

        public async Task<string> InitiateGoogleLogin(string baseUri)
        {
            var googleSettings = await _configService.GetGoogleAuthSettingsAsync();
            var redirectUri = "https://localhost:7173/authentication/login-callback";
            var state = Guid.NewGuid().ToString();
            
            await _jsRuntime.InvokeVoidAsync("localStorage.setItem", LocalStorageKeys.GoogleAuthState, state);
            
            var authUrl = $"{googleSettings.AuthUrl}?" +
                $"client_id={Uri.EscapeDataString(googleSettings.ClientId)}&" +
                $"redirect_uri={Uri.EscapeDataString(redirectUri)}&" +
                $"response_type=code&" +
                $"scope={Uri.EscapeDataString("openid email profile")}&" +
                $"state={Uri.EscapeDataString(state)}";

            return authUrl;
        }

        public async Task<GoogleUserInfo?> GetUserInfoFromAccessToken(string accessToken)
        {
            try
            {
                var googleSettings = await _configService.GetGoogleAuthSettingsAsync();
                
                _httpClient.DefaultRequestHeaders.Authorization = 
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);

                var response = await _httpClient.GetAsync(googleSettings.UserInfoUrl);
                
                if (response.IsSuccessStatusCode)
                {
                    var jsonContent = await response.Content.ReadAsStringAsync();
                    var userInfo = JsonSerializer.Deserialize<GoogleUserInfo>(jsonContent, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
                    
                    return userInfo;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[GoogleAuth] Error getting user info: {ex.Message}");
            }
            
            return null;
        }

        public async Task<bool> ValidateState(string receivedState)
        {
            try
            {
                var storedState = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", LocalStorageKeys.GoogleAuthState);
                return storedState == receivedState;
            }
            catch
            {
                return false;
            }
        }

        public async Task ClearAuthState()
        {
            await _jsRuntime.InvokeVoidAsync("localStorage.removeItem", LocalStorageKeys.GoogleAuthState);
        }
    }

    public class GoogleUserInfo
    {
        public string Id { get; set; } = "";
        public string Email { get; set; } = "";
        public string Name { get; set; } = "";
        public string Picture { get; set; } = "";
        public string Given_Name { get; set; } = "";
        public string Family_Name { get; set; } = "";
        public bool Verified_Email { get; set; }
    }
}